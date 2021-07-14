using System;
using System.IO;
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

namespace FreezingManApp.Pages
{
    using Base;
    using Microsoft.Win32;

    /// <summary>
    /// Логика взаимодействия для CardPage.xaml
    /// </summary>
    public partial class CardPage : Page
    {
        Camp currentCamp = new Camp();

        public CardPage(Camp camp)
        {
            InitializeComponent();

            currentCamp = camp;
            DataContext = currentCamp;

            ComboStatuses.ItemsSource = AppData.GetContext().Status.ToList();
        }

        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "Image Files (*.png; *.jpeg; *.jpg;) | *.png; *.jpeg; *.jpg"
            };

            if (fileDialog.ShowDialog() == true)
            {

            }
        }

        /// <summary>
        /// Удаление изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Удалить изображение лагеря?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                currentCamp.MainImagePath = null;

                MessageBox.Show("Изображение лагеря удалено!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Сохранение изменений
        /// </summary>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (currentCamp.StartWorkingTime > currentCamp.EndWorkingTime)
            {
                errors.AppendLine("Время окончания работы лагеря не может быть меньше времени начала");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                try
                {
                    AppData.GetContext().SaveChanges();

                    MessageBox.Show("Изменения успешно сохранены!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);

                    Navigation.MainFrame.Navigate(new ListPage());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Назад на список всех лагерей
        /// </summary>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new ListPage());
        }
    }
}
