using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BG3_Tools.Models
{
    [Serializable]
    [XmlRoot(ElementName = "content")]
    public class Content
    {
        public int index { get; set; }
        [XmlAttribute(AttributeName = "contentuid")]
        public string Contentuid { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }

        [XmlText]
        public string Text { get; set; }

        public string TextT { get; set; }

    }

    [Serializable]
    [XmlRoot(ElementName = "contentList")]
    public class ContentList
    {

        [XmlElement(ElementName = "content")]
        public List<Content> Content { get; set; }
    }

}
