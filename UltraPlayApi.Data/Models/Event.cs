using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace UltraPlayApi.Data.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [XmlElement(ElementName = "Match")]
        public virtual List<Match> Matches { get; set; }

        [XmlAttribute(AttributeName = "CategoryID")]
        public string CategoryId { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "IsLive")]
        public bool IsLive { get; set; }

        [XmlAttribute(AttributeName = "ID")]
        public int UniqueId { get; set; }

        public int SportId { get; set; }

        public virtual Sport Sport { get; set; }


    }

}
