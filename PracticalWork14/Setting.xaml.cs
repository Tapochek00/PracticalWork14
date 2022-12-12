using LibMas;
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
using Пример_таблицы_WPF;

namespace PracticalWork14
{
    /// <summary>
    /// Логика взаимодействия для Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void Size_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int.TryParse(cols.Text, out Data1.ColumnCount);
                int.TryParse(rows.Text, out Data1.RowCount);

                StreamWriter sw = new StreamWriter("config.txt");
                sw.WriteLine(Convert.ToString(cols.Text));
                sw.WriteLine(rows.Text);
                sw.Close();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
