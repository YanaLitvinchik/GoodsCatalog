using System;
using System.Collections.Generic;
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
using System.Xml.Linq;

namespace GoodsCatalog
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string name = category.Text;
            if(String.IsNullOrEmpty(name))
            {
                MessageBox.Show("Вы не ввели название категории",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string path = @"..\..\Data\Categories.xml";
                XDocument doc = XDocument.Load(path);
                var root = doc.Element("root");
                var categories = root.Elements("category");
                int k = categories.Count();

                XElement elem = new XElement("category", 
                    new XAttribute("id", 4), 
                    new XAttribute("name", name));
                root.Add(elem);
                doc.Save(path);

                MessageBox.Show("Категория успешно добавлена",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;

            }
        }
    }
}
