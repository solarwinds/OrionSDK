using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Xsl;
using MSXML2;

/*
COPYRIGHT © 2008 George Zabanah
Please feel free to use this code in your apps and distribute
but leave this header at the top.
I have one request - you may not sell this code or place on 
other websites without asking my permission first.
If you would like to contribute to improve this code, please let me know.
No warranty of any kind is implied by using this code.
Use at your own risk.
*/

namespace SwqlStudio.XmlRender
{
    /// <summary>
    /// This class has the methods required to render XML as pretty HTML.
    /// </summary>
    internal static class RenderXmlToHtml
    {
        #region Render(XmlDocument xmlToRender, XmlBrowser.XslTransformType xslTransformType)
        /// <summary>
        /// This method determines which output type to render
        /// </summary>
        /// <param name="xmlToRender">the xml string to render</param>
        /// <param name="xslTransformType"><see cref="XmlBrowser.XslTransformType"/></param>
        /// <returns>HTML string</returns>
        /// <seealso cref="XmlBrowser.XslTransformType"/>
        internal static string Render(XmlDocument xmlToRender, XmlBrowser.XslTransformType xslTransformType, XmlBrowser xmlBrowser)
        {
            if (xslTransformType == XmlBrowser.XslTransformType.XSL)
                return Render(xmlToRender.OuterXml);
            else if (xslTransformType == XmlBrowser.XslTransformType.XSLT10)
                return Render(xmlToRender, XmlRender.XmlToHtml10, false);
            else if (xslTransformType == XmlBrowser.XslTransformType.XSLT10RegExp)
                return Render(xmlToRender, XmlRender.XmlToHtml10Plus, false);
            else if (xslTransformType == XmlBrowser.XslTransformType.XSLT10Basic)
                return Render(xmlToRender, XmlRender.XmlToHtml10Basic, true);
            else if (xslTransformType == XmlBrowser.XslTransformType.XSLT10Cdata)
                return Render(xmlToRender, XmlRender.XmlToHtml10Cdata, false);

            return string.Empty;
        }
        #endregion

        #region Render(string xmlToRender)
        /// <summary>
        /// This method has to use the old XSL Processor because of the fact that the
        /// http://www.w3.org/TR/WD-xsl namespace is unsupported.
        ///
        /// The simplest way was to use the old xsl instead of re-inventing the wheel.
        /// I could not find a way to easily fully convert this to XSLT 1.0 due to 
        /// the lack of namespace and cdata 'selectability'.
        ///
        /// This brings back memories :)
        /// </summary>
        /// <param name="xmlToRender">the xml string to render</param>
        /// <returns>HTML string</returns>
        internal static string Render(string xmlToRender)
        {
            XSLTemplate oXSLT;
            FreeThreadedDOMDocument oStyleSheet;
            IXSLProcessor oXSLTProc;
            DOMDocument oXMLSource;

            try
            {
                oXSLT = new XSLTemplate();
                oStyleSheet = new FreeThreadedDOMDocument();
                oXMLSource = new DOMDocument();

                oStyleSheet.async = false;
                oStyleSheet.loadXML(XmlRender.XMLToHTML);

                oXSLT.stylesheet = oStyleSheet;

                oXSLTProc = oXSLT.createProcessor();

                oXMLSource.async = false;
                oXMLSource.loadXML(xmlToRender);
                oXSLTProc.input = oXMLSource;

                oXSLTProc.transform();

                return oXSLTProc.output.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                oXSLT = null;
                oStyleSheet = null;
                oXMLSource = null;
                oXSLTProc = null;
            }
        }
        #endregion

        #region Render(XmlDocument xmlToRender)
        /// <summary>
        /// This method uses the XsltCompiledTransform to transform XML to pretty HTML.
        /// Unfortunately, this method does require using EXSL/MSXML but it is XSLT 1.0 compliant.
        /// </summary>
        /// <param name="xmlToRender"><see cref="System.Xml.XmlDocument"/> to render</param>
        /// <param name="xsltDocument">XSLT Document to use for transformation</param>
        /// <returns>HTML string</returns>
        /// <seealso cref="System.Xml.XmlDocument"/>
        internal static string Render(XmlDocument xmlToRender, string xsltDocument, bool escapeCdata)
        {
            XslCompiledTransform xslCompiledTransform;
            XmlReader xmlReader = null;
            StringReader stringReader = null;
            StringBuilder stringBuilder;
            XmlWriter xmlWriter = null;
            XsltSettings xsltSettings;
            try
            {
                xslCompiledTransform = new XslCompiledTransform(true);
                stringReader = new StringReader(xsltDocument);
                xmlReader = XmlReader.Create(stringReader);
                xsltSettings = new XsltSettings(true, true);
                xslCompiledTransform.Load(xmlReader, xsltSettings, new XmlUrlResolver());
                stringBuilder = new StringBuilder();
                xmlWriter = XmlWriter.Create(stringBuilder);
                XsltArgumentList a = new XsltArgumentList();
                // Need to pass the xml string as an input parameter so
                // we can do some parsing for extra bits that XSLT won't do.
                a.AddParam("xmlinput", string.Empty, xmlToRender.OuterXml);
                if (escapeCdata)
                {
                    string xml = xmlToRender.OuterXml.Replace("<![CDATA[", "&lt;![CDATA[").Replace("]]>", "]]&gt;");
                    xml = Regex.Replace(xml, @"(&lt;!\[CDATA\[[^\]]*)(<)([^\]]*\]\]&gt;)", "$1&lt;$3");
                    xml = Regex.Replace(xml, @"(&lt;!\[CDATA\[[^\]]*)(>)([^\]]*\]\]&gt;)", "$1&gt;$3");
                    xmlToRender.LoadXml(xml);
                }
                xslCompiledTransform.Transform(xmlToRender, a, xmlWriter);
                string result = stringBuilder.ToString();
                xmlWriter.Close();
                return result;
            }
            catch (Exception e) { return e.Message; }
            finally
            {
                xslCompiledTransform = null;
                xmlReader.Close();
                xmlReader = null;
                stringReader.Close();
                stringReader = null;
                stringBuilder = null;
                if (xmlWriter != null) xmlWriter.Close();
                xmlWriter = null;
                xsltSettings = null;
            }
        }
        #endregion
    }
}
