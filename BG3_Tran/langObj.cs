using System.Collections.Generic;
using System.Xml.Serialization;

namespace BG3_Tran
{
    [XmlRoot(ElementName = "content")]
    public class Content
    {

        [XmlAttribute(AttributeName = "contentuid")]
        public string Contentuid;

        [XmlAttribute(AttributeName = "version")]
        public int Version;

        [XmlText]
        public string Text;
    }

    [XmlRoot(ElementName = "contentList")]
    public class ContentList
    {

        [XmlElement(ElementName = "content")]
        public List<Content> Content;

        [XmlAttribute(AttributeName = "date")]
        public string Date;

        [XmlText]
        public string Text;
    }

}
