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

namespace preparation
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Деталь _currentDetail = new Деталь();

        public AddEditPage(Деталь selectedDetail)
        {
            if (selectedDetail != null) 
            _currentDetail = selectedDetail;    
            InitializeComponent();
            CategoryCB.ItemsSource = rusmetEntities1.GetContext().Категория.ToList();
            DataContext = _currentDetail;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentDetail.Название))
                errors.AppendLine("Введите Название");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;           
            }

            if (_currentDetail.Id_детали == 0)
            {
                rusmetEntities1.GetContext().Деталь.Add(_currentDetail);
            }

            try
            {
                rusmetEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
