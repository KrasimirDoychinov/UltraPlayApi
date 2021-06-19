using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Serialization;
using UltraPlayApi.Data.Enums;

namespace UltraPlayApi.Data.Models
{
    public class Match
    {
        [Key]
        public int Id { get; set; }

        [XmlElement(ElementName = "Bet")]
        public virtual List<Bet> Bets { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "StartDate")]
        public string StartDate { get; set; }

        [XmlAttribute(AttributeName = "MatchType")]
        public MatchType MatchType { get; set; }

        [XmlAttribute(AttributeName = "ID")]
        public int UniqueId { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
