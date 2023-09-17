using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BG3_Tools.Models
{
    [XmlRoot(ElementName = "version")]
    public class Version
    {

        [XmlAttribute(AttributeName = "major")]
        public int Major { get; set; }

        [XmlAttribute(AttributeName = "minor")]
        public int Minor { get; set; }

        [XmlAttribute(AttributeName = "revision")]
        public int Revision { get; set; }

        [XmlAttribute(AttributeName = "build")]
        public int Build { get; set; }
    }

    [XmlRoot(ElementName = "node")]
    public class Node
    {

        [XmlElement(ElementName = "attribute")]
        public List<Attribute> Attribute { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "children")]
        public Children Children { get; set; }
    }

    [XmlRoot(ElementName = "attribute")]
    public class Attribute
    {

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "children")]
    public class Children
    {

        [XmlElement(ElementName = "node")]
        public List<Node> Node { get; set; }
    }

    [XmlRoot(ElementName = "region")]
    public class Region
    {

        [XmlElement(ElementName = "node")]
        public Node Node { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "save")]
    public class Save
    {

        [XmlElement(ElementName = "version")]
        public Version Version { get; set; }

        [XmlElement(ElementName = "region")]
        public Region Region { get; set; }
    }
}
