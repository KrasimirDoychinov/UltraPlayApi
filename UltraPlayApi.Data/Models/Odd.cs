using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Serialization;

namespace UltraPlayApi.Data.Models
{
    public class Odd
    {
        [Key]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }

        [XmlAttribute(AttributeName = "SpecialBetValue")]
        public string SpecialBetValue { get; set; }

        [XmlAttribute(AttributeName = "ID")]
        public int UniqueId { get; set; }

        public int BetId { get; set; }

        public virtual Bet Bet { get; set; }
    }
}
