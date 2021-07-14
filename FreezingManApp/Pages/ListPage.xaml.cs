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

namespace FreezingManApp.Pages
{
    using Base;

    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public ListPage()
        {
            InitializeComponent();

            var types = AppData.GetContext().Type.ToList();
            types.Insert(0, new Type { Name = "All" });
            ComboTypes.ItemsSource = types;
            ComboTypes.SelectedIndex = 0;

            UpdateList();
        }

        /// <summary>
        /// Обновление списка лагерей
        /// </summary>
        private void UpdateList()
        {
            var camps = AppData.GetContext().Camp.ToList();

            if (ComboTypes.SelectedIndex > 0)
                camps = camps.Where(p => p.Type == ComboTypes.SelectedItem as Type).ToList();

            ListCamp.ItemsSource = camps;
        }

        /// <summary>
        /// Был выбран тип для поиска
        /// </summary>
        private void ComboTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        /// <summary>
        /// Изменился текст в поисковике
        /// </summary>
        private void TextTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        /// <summary>
        /// Нажатие на лагерь
        /// </summary>
        private void ListCamp_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(ListCamp, e.OriginalSource as DependencyObject) as ListBoxItem;

            if (item != null)
            {
                Navigation.MainFrame.Navigate(new CardPage(item.DataContext as Camp));
            }
        }
    }
}
