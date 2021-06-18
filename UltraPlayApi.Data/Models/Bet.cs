using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace UltraPlayApi.Data.Models
{
	[XmlRoot(ElementName = "Bet")]
	public class Bet
	{
		[Key]
		public int Id { get; set; }

		[XmlElement(ElementName = "Odd")]
		public virtual List<Odd> Odds { get; set; }

		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "IsLive")]
		public bool IsLive { get; set; }

		[XmlAttribute(AttributeName = "ID")]
		public int UniqueId { get; set; }

		public int MatchId { get; set; }

		public virtual Match Match { get; set; }

	}
}
