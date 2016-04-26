using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task09_Serialization
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Serialization();
            Deserialization();
            Console.ReadLine();
        }


        private static void Serialization()
        {
            using (Stream file = new FileStream(@"books2.xml", FileMode.OpenOrCreate))
            {
                var serializer = new XmlSerializer(typeof(Catalog));
                //to remove redundant <Books> tag
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                var catalog = new Catalog
                {
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Author = "Mikita",
                            Description = "Awesome book",
                            Genre = Genre.Fantasy,
                            PublishDate = DateTime.Today.Date,
                            Publisher = "Tantik",
                            RegistrationDate = DateTime.Today - new TimeSpan(1, 0, 0, 0),
                            Title = "Abra-kadabra"
                        },
                        new Book
                        {
                            Author = "Zlata",
                            Description = "molecular biology",
                            Genre = Genre.Horror,
                            PublishDate = DateTime.Today.Date,
                            Publisher = "Ataraxia",
                            RegistrationDate = DateTime.Today - new TimeSpan(1, 0, 0, 0),
                            Title = "Abra-kadabra"
                        }
                    }
                };

                serializer.Serialize(file, catalog, ns);
            }
        }

        private static void Deserialization()
        {
            using (Stream file = new FileStream(@"books2.xml", FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof (Catalog));

                var catalogs = serializer.Deserialize(file) as Catalog;

                if (catalogs != null)
                {
                    foreach (var book in catalogs.Books)
                    {
                        Console.WriteLine(book.Author);
                        Console.WriteLine(book.Title);
                        Console.WriteLine(book.PublishDate);
                        Console.WriteLine();
                    }
                }
            }
        }

    }
}
