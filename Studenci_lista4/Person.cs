using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Studenci_lista4
{
    public class Person
    {
        [XmlAttribute("id")]
        public int PersonId { get; set; }

        [XmlAttribute("imie")]
        public string FirstName { get; set; }

        [XmlAttribute("nazwisko")]
        public string LastName { get; set; }

        [XmlAttribute("wiek")]
        public int Age { get; set; }

        [XmlAttribute("pesel")]
        public long Pesel { get; set; }

        public Person(int nPersonId, string sFirstName, string sLastName, int nAge, long lPesel)
        {
            PersonId = nPersonId;
            FirstName = sFirstName;
            LastName = sLastName;
            Age = nAge;
            Pesel = lPesel;
        }

        public Person()
        {
            PersonId = 0;
            FirstName = "Janusz";
            LastName = "Januszewski";
            Age = 120;
            Pesel = 999909090;
        }
    }
}
