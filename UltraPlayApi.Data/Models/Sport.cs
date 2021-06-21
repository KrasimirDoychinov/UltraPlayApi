using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace UltraPlayApi.Data.Models
{
    public class Sport 
	{
		[Key]
		public int Id { get; set; }

		[XmlElement(ElementName = "Event")]
		public virtual List<Event> Events { get; set; }

		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "ID")]
		public int UniqueId { get; set; }
	}
}
