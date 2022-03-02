using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

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
    // Use this control if you want a webBrowser which has been extended 
    // to allow for Xml Rendering
    public partial class XmlBrowser : WebBrowser, IDisposable
    {
        #region Types/Private Variables
        /// <summary>
        /// Type to determine which XSL/XSLT to use in transformation
        /// </summary>
        public enum XslTransformType
        {
            XSL,
            XSLT10,
            XSLT10RegExp,
            XSLT10Basic,
            XSLT10Cdata
        }
        // XmlDocument to store Xml data for rendering
        private XmlDocument _xmlDocument;
        // XslDocument to use when rendering Xml
        private XslTransformType _xslTransformType;
        #endregion

        #region Constructor
        public XmlBrowser()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        #region XmlText
        /// <summary>
        /// Property to set Xml Text for webbrowser
        /// </summary>
        [Category("XmlData")]
        [Description("Use this property to set the XmlText for rendering in the webbrowser.")]
        public string XmlText
        {
            set
            {
                if (value != string.Empty)
                {
                    _xmlDocument = new XmlDocument();
                    _xmlDocument.LoadXml(value);
                    string rtn = RenderXmlToHtml.Render(_xmlDocument, _xslTransformType, this);
                    if (!string.IsNullOrEmpty(rtn))
                        DocumentText = rtn;
                }
            }
            get
            {
                if (_xmlDocument == null)
                    return string.Empty;
                else
                    return _xmlDocument.OuterXml;
            }
        }
        #endregion

        #region XmlDocument
        /// <summary>
        /// Property to set XmlDocument for webbrowser
        /// </summary>
        [Category("XmlData")]
        [Description("Use this property in your code to set the System.Xml.XmlDocument for rendering in the webbrowser.")]
        public XmlDocument XmlDocument
        {
            get
            {
                return _xmlDocument;
            }
            set
            {
                if (value != null)
                {
                    _xmlDocument = value;
                    string rtn = RenderXmlToHtml.Render(_xmlDocument, _xslTransformType, this);
                    if (!string.IsNullOrEmpty(rtn))
                        DocumentText = rtn;
                }
            }
        }
        #endregion

        #region XmlDocumentTransformType
        /// <summary>
        /// Change this to determine which transform type to use
        /// </summary>
        [Category("XmlData")]
        [Description("Use this property to specify to use either the XSL or XSLT 1.0 compliant stylesheet for rendering.")]
        public XslTransformType XmlDocumentTransformType
        {
            get
            {
                return _xslTransformType;
            }
            set
            {
                _xslTransformType = value;
            }
        }
        #endregion

        #endregion

    }
}
