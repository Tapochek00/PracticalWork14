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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Пример_таблицы_WPF;
using LibMas;
using Microsoft.Win32;
using System.IO;
using System.Data;

namespace PracticalWork14
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int[,] A;
        bool[] B;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowPassword pass = new WindowPassword();
            pass.Owner = this;
            pass.ShowDialog();
            Data1.RowCount = 5;
            Data1.ColumnCount = 6;
            A = new int[Data1.RowCount, Data1.ColumnCount];
            B = new bool[Data1.ColumnCount];
            dataGridA.ItemsSource = VisualArray.ToDataTable(A).DefaultView;
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №13 вариант 14\n\nДунаева М.И. ИСП-31\n\n" +
                "По массиву A(5,6)получить массив В(6), присвоив его j-элементу значение true," +
                "если все элементы j-столбца массива А нулевые, и значение false иначе");
        }

        private void btn_Count_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int j = Convert.ToInt32(jzn.Text) - 1;
                B[j] = Class1.ColumnOfZeros(A, j);
                dataGridB.ItemsSource = VisualArray.ToDataTable(B).DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Class2.ClearArr(ref A);
            Class2.ClearArr(ref B);
            dataGridA.ItemsSource = VisualArray.ToDataTable(A).DefaultView;
            dataGridB.ItemsSource = null;
        }

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class2.ClearArr(ref B);
                dataGridB.ItemsSource = null;
                int.TryParse(min.Text, out int minLim);
                int.TryParse(max.Text, out int maxLim);

                Class2.FillArr(ref A, minLim, maxLim);

                dataGridA.ItemsSource = VisualArray.ToDataTable(A).DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridA_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                Class2.ClearArr(ref B);
                dataGridB.ItemsSource = null;
                int indexColumn = e.Column.DisplayIndex, indexRow = e.Row.GetIndex();
                A[indexRow, indexColumn] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menu_Open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.DefaultExt = ".txt";
                open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
                open.FilterIndex = 2;
                open.Title = "Сохранение таблицы";

                if (open.ShowDialog() == true)
                {
                    StreamReader file = new StreamReader(open.FileName);

                    A = new int[5, 6];

                    for (int i = 0; i < 5; i++)
                        for (int j = 0; j < 6; j++) A[i, j] = Convert.ToInt32(file.ReadLine());

                    file.Close();

                    dataGridA.ItemsSource = VisualArray.ToDataTable(A).DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void menu_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.DefaultExt = ".txt";
                save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
                save.FilterIndex = 2;
                save.Title = "Сохранение таблицы";

                if (save.ShowDialog() == true)
                {
                    StreamWriter file = new StreamWriter(save.FileName);

                    for (int i = 0; i < 5; i++)
                        for (int j = 0; j < 6; j++) file.WriteLine(A[i, j]);
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearResult_Click(object sender, RoutedEventArgs e)
        {
            Class2.ClearArr(ref B);
            dataGridB.ItemsSource = null;
        }

        private void jzn_TextChanged(object sender, TextChangedEventArgs e)
        {
            Class2.ClearArr(ref B);
            dataGridB.ItemsSource = null;
        }

        private void minmaxTextChanged(object sender, TextChangedEventArgs e)
        {
            Class2.ClearArr(ref A);
            dataGridA.ItemsSource = VisualArray.ToDataTable(A).DefaultView;
        }

        private void dataGridA_GotFocus(object sender, RoutedEventArgs e)
        {
            int col = dataGridA.CurrentCell.Column.DisplayIndex;
            int row = dataGridA.SelectedIndex;
            status.Text = $"Выбрана ячейка: {col+1}:{row+1}";
            status2.Text = $"Размер таблицы: {Data1.RowCount}x{Data1.ColumnCount}";
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting opt = new Setting();
            opt.Owner = this;
            opt.ShowDialog();
            A = new int[Data1.RowCount, Data1.ColumnCount];
            B = new bool[Data1.ColumnCount];
            dataGridA.ItemsSource = VisualArray.ToDataTable(A).DefaultView;
            Class2.ClearArr(ref B);
            dataGridB.ItemsSource = null;
        }
    }
}
