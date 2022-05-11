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
        private Agents _currentAgent = new Agents();

        public AddEditPage(Agents selectedDetail)
        {
            if (selectedDetail != null)
            _currentAgent = selectedDetail;    
            InitializeComponent();
            DataContext = _currentAgent;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentAgent.Наименование))
                errors.AppendLine("Введите Наименование");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;           
            }

            if (_currentAgent.ИН_Агента == 0)
            {
                poprizhenokEntities.GetContext().Agents.Add(_currentAgent);
            }

            try
            {
                poprizhenokEntities.GetContext().SaveChanges();
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
