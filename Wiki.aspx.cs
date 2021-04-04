using System;
using System.Xml.Linq;
using System.Web.UI;
using System.Data;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using ArcheWay_Site.App_Code;

namespace ArcheWay_Site
{
    public partial class Wiki : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void gameRuleCats12_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            XElement doc = XElement.Load(Server.MapPath("~/Wiki_Resource/Rules_Archeage1.2.xml"));
            IEnumerable<XElement> rules = doc.Descendants("rule");
            foreach (XElement rule in rules)
            {
                XElement server = (XElement)rule.FirstNode;
                sb.AppendLine("<button class=\"accordion\">" + server.FirstAttribute.Value + "</button>"); //List the port # as a category
                sb.AppendLine("<div class=\"subCat\">");
                XElement nextNode = (XElement)server.NextNode;
                while (nextNode != null)
                {
                    //These links, when clicked, will show broad content
                    sb.AppendLine("<a class=\"catLink\" href=\"" + string.Concat("#", nextNode.Name.LocalName, server.FirstAttribute.Value) + "\">" + nextNode.Name.LocalName.ToUpper() + "</a>");
                    nextNode = (XElement)nextNode.NextNode;
                }
                sb.AppendLine("</div>");
            }
            gameRuleCats12.Text = sb.ToString();
        }

        protected void gameRules12_Load(object sender, EventArgs e)
        {

            StringBuilder packetTables = new StringBuilder();
            StringBuilder packetContent = new StringBuilder();
            XElement doc = XElement.Load(Server.MapPath("~/Wiki_Resource/Rules_Archeage1.2.xml"));
            IEnumerable<XElement> rules = doc.Descendants("rule");
            foreach (XElement rule in rules)
            {
                #region Load Tables First
                XElement server = (XElement)rule.FirstNode;
                XElement nextNode = (XElement)server.NextNode;
                while (nextNode != null)
                {
                    XElement temp = nextNode.Element("packet");
                    if (temp != null && temp.HasAttributes) //Move forward if we have packets in the rule set
                    {
                        packetTables.AppendLine("<div class=\"catContent\"  id=\"" + string.Concat(nextNode.Name.LocalName, server.FirstAttribute.Value) + "\">");
                        packetTables.AppendLine("<table>");
                        packetTables.AppendLine("<tr>");

                        //Table Headers
                        foreach (XAttribute attr in temp.Attributes())
                            packetTables.AppendLine("<th>" + attr.Name.LocalName.ToUpper() + "</th>");
                        packetTables.AppendLine("</tr>");

                        //Table Content
                        IEnumerable<XElement> tempPackets = nextNode.Descendants("packet");
                        foreach (XElement packet in tempPackets)
                        {
                            packetTables.AppendLine("<tr>");
                            foreach (XAttribute attr in packet.Attributes())
                            {
                                if (attr.Name.LocalName == "name")
                                    packetTables.AppendLine("<td><a class=\"contentLink\" href=" + string.Concat("#", attr.Value) + ">" + attr.Value + "</a></td>"); //Hyperlinks for going to a more specific page
                                else
                                    packetTables.AppendLine("<td>" + attr.Value + "</td>");
                            }
                            packetTables.AppendLine("</tr>");
                        }
                        packetTables.AppendLine("</table>");
                        packetTables.AppendLine("</div>");
                    }


                    nextNode = (XElement)nextNode.NextNode;
                }
                #endregion

                #region Load all Packet Contents
                IEnumerable<XElement> packets = rule.Descendants("packet");
                foreach (XElement packet in packets)
                {
                    IEnumerable<XElement> chunks = packet.Elements("chunk");
                    string packetName = packet.Attribute("name").Value;
                    packetContent.AppendLine("<div style=\"width:50%;\" class=\"catContent\"  id=\"" + packet.Attribute("name").Value + "\">");

                    packetContent.AppendLine("<ul class=\"tab\">");
                    packetContent.AppendLine("<li><a class=\"tablinks\" href=\"#" + packetName + "Table\">Table</a></li>");
                    packetContent.AppendLine("<li><a class=\"tablinks\" href=\"#" + packetName + "C\">C#</a></li>");
                    packetContent.AppendLine("<li><a class=\"tablinks\" href=\"#" + packetName + "Java\">Java</a></li>");
                    packetContent.AppendLine("</ul>");


                    #region Table Tab
                    XElement tempChunk = (XElement)packet.FirstNode;
                    if (tempChunk != null)
                    {
                        packetContent.AppendLine("<div id=\"" + packetName + "Table\" class=\"tabcontent\">");
                        packetContent.AppendLine("<table>");

                        //Table Header
                        packetContent.AppendLine("<tr>");
                        foreach (XAttribute attr in tempChunk.Attributes())
                            packetContent.AppendLine("<th>" + attr.Name.LocalName.ToUpper() + "</th>");
                        packetContent.AppendLine("</tr>");

                        //Table Data
                        foreach (XElement chunk in chunks)
                        {
                            packetContent.AppendLine("<tr>");
                            packetContent.AppendLine("<td>"+ chunk.Attribute("type").Value +"</td>");
                            packetContent.AppendLine("<td>" + chunk.Attribute("name").Value + "</td>");
                            packetContent.AppendLine("<tr>");
                        }
                        packetContent.AppendLine("</table>");
                        packetContent.AppendLine("</div>");
                    }
                    #endregion

                    #region C# Tab
                    //TODO
                    #endregion

                    #region Java Tab
                    //TODO
                    #endregion
                    packetContent.AppendLine("</div>");
                }
                #endregion
            }
            gameRules12.Text = string.Empty;
            gameRules12.Text += packetTables.ToString();
            gameRules12.Text += packetContent.ToString();
        }
    }
}