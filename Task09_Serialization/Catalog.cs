using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task09_Serialization
{
    class Catalog
    {
        [XmlElement("Book")]
        public List<Book> Books { get; set; }
    }

    class Book
    {
        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("genre")]
        public Genre Genre { get; set; }

        [XmlElement("publisher")]
        public string Publisher { get; set; }

        [XmlElement("publish_date")]
        public DateTime PublishDate { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("registration_date")]
        public DateTime RegistrationDate { get; set; }
    }

    enum Genre
    {
        Computer,
        Fantasy,
        Romance,
        Horror,
        ScienceFiction
    }
}
