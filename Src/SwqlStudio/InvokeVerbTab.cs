using System;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web.UI;
using System.Windows.Forms;
using System.Xml;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    public partial class InvokeVerbTab : TabTemplate, IConnectionTab
    {
        public InvokeVerbTab()
        {
            InitializeComponent();
        }

        private int locationX = 0;
        private int locationY = 0;

        private Verb verb;
        public Verb Verb
        {
            get { return verb; }
            set
            {
                verb = value;
                FillTextBox();
            }
        }

        private void FillTextBox()
        {
            var buffer = new StringWriter();
            using (var html = new HtmlTextWriter(buffer))
            {
                html.RenderBeginTag("html");
                html.RenderBeginTag(HtmlTextWriterTag.Head);

                html.RenderBeginTag(HtmlTextWriterTag.Style);
                html.BeginRender();
                html.Write(Properties.Resources.ResizableTextAreaStyle);
                html.EndRender();
                html.RenderEndTag();//style

                html.RenderEndTag();//head
                html.RenderBeginTag("body");

                html.RenderBeginTag("h1");
                html.WriteEncodedText(string.Format("{0}.{1}", verb.EntityName, verb.Name));
                html.RenderEndTag();

                html.RenderBeginTag("table");
                html.RenderBeginTag("tbody");

                foreach (var verbArgument in verb.Arguments)
                {
                    html.RenderBeginTag("tr");

                    html.RenderBeginTag("td");
                    html.WriteEncodedText(verbArgument.Name);
                    html.RenderEndTag();

                    html.RenderBeginTag("td");
                    switch (verbArgument.Type.ToLowerInvariant())
                    {
                        case "system.string":
                        case "system.int64":
                        case "system.int32":
                        case "system.int16":
                        case "system.byte":
                        case "system.boolean":
                        case "system.datetime":
                            html.AddAttribute(HtmlTextWriterAttribute.Id, "arg" + verbArgument.Position);
                            html.AddAttribute(HtmlTextWriterAttribute.Type, "text");
                            html.RenderBeginTag(HtmlTextWriterTag.Input);
                            html.RenderEndTag();
                            break;

                        default:
                            html.AddAttribute(HtmlTextWriterAttribute.Name, "outerDiv");
                            html.AddAttribute(HtmlTextWriterAttribute.Class, "outerDiv");
                            html.RenderBeginTag(HtmlTextWriterTag.Div);

                            html.AddAttribute(HtmlTextWriterAttribute.Class, "txtArea");
                            html.AddAttribute(HtmlTextWriterAttribute.Id, "arg" + verbArgument.Position);
                            html.RenderBeginTag(HtmlTextWriterTag.Textarea);
                            html.WriteEncodedText(verbArgument.XmlTemplate ?? "No template available");
                            html.RenderEndTag();//textarea

                            html.AddAttribute(HtmlTextWriterAttribute.Class, "corner");
                            html.RenderBeginTag(HtmlTextWriterTag.Div);
                            html.RenderEndTag(); //innerdiv

                            html.RenderEndTag();//outerdiv
                            break;
                    }

                    html.RenderEndTag();

                    html.RenderBeginTag("td");
                    html.WriteEncodedText(verbArgument.Type);
                    html.RenderEndTag();

                    html.RenderEndTag(); // tr
                }

                html.RenderEndTag(); // tbody
                html.RenderEndTag(); // table

                html.AddAttribute(HtmlTextWriterAttribute.Type, "button");
                html.AddAttribute(HtmlTextWriterAttribute.Id, "invoke");
                html.AddAttribute(HtmlTextWriterAttribute.Value, "Invoke");
                html.RenderBeginTag(HtmlTextWriterTag.Input);
                html.RenderEndTag();

                html.RenderEndTag(); // body
                html.RenderEndTag(); // html
            }

            webBrowser1.DocumentText = buffer.ToString();
        }

        private void Invoke_Click(object sender, HtmlElementEventArgs e)
        {
            if (ConnectionInfo == null)
                return;

            bool argumentParsingFailed = false;

            XmlElement[] parameters = verb.Arguments.Select(argument =>
            {
                try
                {
                    return GetValue(argument);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error while parsing argument {argument.Name}, invocation won't happen:\n\n{ex.Message}",
                        ex.GetType().Name,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    argumentParsingFailed = true;
                    return null;
                }
            }).ToArray();

            if (argumentParsingFailed)
                return;

            var doc = new XmlDocument();
            try
            {
                XmlElement result = ConnectionInfo.Proxy.Invoke(verb.EntityName, verb.Name, parameters);
                doc.AppendChild(doc.ImportNode(result, true));
            }
            catch (FaultException ex)
            {
                using (XmlWriter appendChild = doc.CreateNavigator().AppendChild())
                    ex.CreateMessageFault().WriteTo(appendChild, EnvelopeVersion.Soap12);
            }
            catch (Exception ex)
            {
                doc.AppendChild(doc.CreateElement("exception"));
                doc.DocumentElement.AppendChild(doc.CreateCDataSection(ex.ToString()));
            }
            xmlBrowser1.XmlDocument = doc;
        }

        private XmlElement GetValue(VerbArgument arg)
        {
            var doc = new XmlDocument();
            string text = webBrowser1.Document.GetElementById("arg" + arg.Position).GetAttribute("value");
            switch (arg.Type.ToLowerInvariant())
            {
                case "system.string":
                case "system.int64":
                case "system.int32":
                case "system.int16":
                case "system.byte":
                case "system.boolean":
                case "system.datetime":
                    XmlElement elt = doc.CreateElement("arg");
                    elt.InnerText = text;
                    return elt;

                default:
                    doc.InnerXml = text;
                    
                    if (arg.Type.StartsWith("System.Collections.Generic.Dictionary", StringComparison.OrdinalIgnoreCase))
                    {
                        var valueElements = doc.DocumentElement.GetElementsByTagName("Value");

                        foreach (XmlNode valueElement in valueElements)
                        {
                            ReplaceTextWithCData(valueElement);
                        }
                    }
                    
                    return doc.DocumentElement;
            }
        }

        private void ReplaceTextWithCData(XmlNode node)
        {
            if (node.HasChildNodes)
            {
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.NodeType == XmlNodeType.Text)
                    {
                        XmlDocument doc = node.OwnerDocument;
                        XmlCDataSection cdata = doc.CreateCDataSection(childNode.OuterXml);

                        XmlNode parent = childNode.ParentNode;
                        parent.ReplaceChild(cdata, childNode);
                    }
                }
            }
        }
        
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElementCollection divs = webBrowser1.Document.GetElementsByTagName("div");
            foreach (HtmlElement div in divs)
            {
                if (div.Name == "outerDiv")
                    DragCorner(div);
            }

            webBrowser1.Document.GetElementById("invoke").Click += Invoke_Click;
        }

        private void DragCorner(HtmlElement container)
        {
            HtmlElement handle = container.GetElementsByTagName("div")[0];
            HtmlElement txtarea = container.GetElementsByTagName("textarea")[0];
            HtmlElementEventHandler handler = (sender, args) => MoveListener(sender, (HtmlElementEventArgs)args, container, txtarea);

            /* Listen for 'mouse down' on handle to start the move listener */
            handle.MouseDown += (mdSender, mdArgs) =>
                {
                    locationX = mdArgs.ClientMousePosition.X;
                    locationY = mdArgs.ClientMousePosition.Y;
                    /* Start listening for mouse move on body */
                    webBrowser1.Document.MouseMove += handler;
                };

            /* Listen for 'mouse up' to cancel 'move' listener */
            webBrowser1.Document.MouseUp +=
                (sender, e) =>
                    {
                        webBrowser1.Document.MouseMove -= handler;
                    };
        }

        private void MoveListener(object sender, HtmlElementEventArgs e, HtmlElement container, HtmlElement txtarea)
        {

            /* Calculate how far the mouse moved */
            int x = e.ClientMousePosition.X - locationX;
            int y = e.ClientMousePosition.Y - locationY;

            /* Reset container's x/y utility property */
            locationX = e.ClientMousePosition.X;
            locationY = e.ClientMousePosition.Y;

            int height = container.OffsetRectangle.Height;
            int width = container.OffsetRectangle.Width;

            /* Update container's size */
            container.Style = string.Format("height:{0}; width:{1};",
                                            (container.OffsetRectangle.Height + y).ToString() + "px",
                                            (container.OffsetRectangle.Width + x).ToString() + "px");

            txtarea.Style = string.Format("height:{0}; width:{1};",
                                       (txtarea.OffsetRectangle.Height + y).ToString() + "px",
                                       (txtarea.OffsetRectangle.Width + x).ToString() + "px");
        }
    }
}
