using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace Studenci_lista4
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public string idP;
        private List<Person> m_oPersonList = null;
        public Window3(string text)
        {
            string id = text;
            InitializeComponent();
            InitBinding(id);
        }

        private void InitBinding(string id)
        {
            m_oPersonList = new List<Person>();
            try
            {
                using (var reader = new StreamReader("PersonList.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Person>),
                        new XmlRootAttribute("ArrayOfPerson"));
                    m_oPersonList = (List<Person>)deserializer.Deserialize(reader);
                }
            }
            catch
            {
                MessageBox.Show("Brak pliku do załadowania!", "Uwaga", MessageBoxButton.OK);
            }
            Person oFoundPerson = m_oPersonList.Find(oElement => oElement.PersonId == Convert.ToInt32(id));
            imie.Text = oFoundPerson.FirstName;
            nazwisko.Text = oFoundPerson.LastName;
            wiek.Text = Convert.ToString(oFoundPerson.Age);
            Pesel.Text = Convert.ToString(oFoundPerson.Pesel);
            idP = id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            imie.IsEnabled = true;
            nazwisko.IsEnabled = true;
            wiek.IsEnabled = true;
            Pesel.IsEnabled = true;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Person oFoundPerson = m_oPersonList.Find(oElement => oElement.PersonId == Convert.ToInt32(idP));
            oFoundPerson.FirstName = imie.Text;
            oFoundPerson.LastName = nazwisko.Text;
            oFoundPerson.Age = Convert.ToInt32(wiek.Text);
            oFoundPerson.Pesel = Convert.ToInt64(Pesel.Text);
            MessageBox.Show("Edytowano dane");
            var serializer = new XmlSerializer(m_oPersonList.GetType());
            using (var writer = XmlWriter.Create("PersonList.xml"))
            {
                serializer.Serialize(writer, m_oPersonList);
            }
        }
    }
}
