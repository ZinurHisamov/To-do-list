using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Список_дел.Models;
using Список_дел.Servis;

namespace Список_дел
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";
        private BindingList<TodoModel> _TodoDateList;
        private FileInput _FileInput;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _FileInput = new FileInput(PATH);
            try
            {
                _TodoDateList = _FileInput.LoadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            dgTodoList.ItemsSource = _TodoDateList;
            _TodoDateList.ListChanged += _TodoDateList_ListChanged;
        }

        private void _TodoDateList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType==ListChangedType.ItemAdded||e.ListChangedType==ListChangedType.ItemDeleted||e.ListChangedType==ListChangedType.ItemChanged)
            {
                try
                {
                    _FileInput.SaveData(sender);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
           
        }
    }
}
