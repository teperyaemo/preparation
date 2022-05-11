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
    /// Логика взаимодействия для AgentPage.xaml
    /// </summary>
    public partial class AgentPage : Page
    {
        public AgentPage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var SelectedDetails = DetailDG.SelectedItems.Cast<Agents>().ToList();

            if(MessageBox.Show("Вы уверены?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                try
                {
                    poprizhenokEntities.GetContext().Agents.RemoveRange(SelectedDetails);
                    poprizhenokEntities.GetContext().SaveChanges();
                    MessageBox.Show("Всё заебись");

                    DetailDG.ItemsSource = poprizhenokEntities.GetContext().Agents.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                poprizhenokEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DetailDG.ItemsSource = poprizhenokEntities.GetContext().Agents.ToList();
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Agents));
        }
    }
}
