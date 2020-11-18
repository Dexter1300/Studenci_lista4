using Microsoft.Win32;
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
    /// Interaction logic for win2.xaml
    /// </summary>
    public partial class win2 : Window
    {
        private string sciezka = "";
        private List<Person> m_oPersonList = null;
        public win2()
        {
            InitializeComponent();
            InitBinding();
        }

        private void InitBinding()
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

        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            m_oPersonList.Add(new Person(m_oPersonList.Count + 1, imie.Text, nazwisko.Text, Convert.ToInt16(wiek.Text), Convert.ToInt64(Pesel.Text),sciezka));
            MessageBox.Show("Dodano nową osobę");
            var serializer = new XmlSerializer(m_oPersonList.GetType());
            using (var writer = XmlWriter.Create("PersonList.xml"))
            {
                serializer.Serialize(writer, m_oPersonList);
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Filses(*.jpg; *.jpeg; *.gif; .bmp;)|.jpg; *.jpeg; *.gif; *.bmp; *.png;";

            if (openFileDialog.ShowDialog() == true)
            {
                sciezka = openFileDialog.FileName;
                Uri fileUri = new Uri(openFileDialog.FileName);
                Picture.Source = new BitmapImage(fileUri);
            }
        }
    }
}
