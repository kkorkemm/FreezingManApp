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
    /// Логика взаимодействия для MapPage.xaml
    /// </summary>
    public partial class MapPage : Page
    {
        public MapPage()
        {
            InitializeComponent();

            var types = AppData.GetContext().Type.ToList();
            types.Insert(0, new Type { Name = "All" });
            ComboTypes.ItemsSource = types;
            ComboTypes.SelectedIndex = 0;

            var statuses = AppData.GetContext().Status.ToList();
            statuses.Insert(0, new Status { Name = "All" });
            ComboStatuses.ItemsSource = statuses;
            ComboStatuses.SelectedIndex = 0;


            UpdateList();
        }

        private void UpdateList()
        {
            var campList = AppData.GetContext().Camp.ToList();

            if (ComboStatuses.SelectedIndex > 0)
                campList = campList.Where(p => p.Status == ComboStatuses.SelectedItem as Status).ToList();

            if (ComboTypes.SelectedIndex > 0)
                campList = campList.Where(p => p.Type == ComboTypes.SelectedItem as Type).ToList();

            CampList.ItemsSource = campList;
        }

        private void ComboTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        private void ComboStatuses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        /// <summary>
        /// Нажатие на изображение лагеря
        /// </summary>
        private void ListView_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(CampList, e.OriginalSource as DependencyObject) as ListBoxItem;

            if (item != null)
            {
                Navigation.MainFrame.Navigate(new CardPage(item.DataContext as Camp));
            }
        }

        private void ScrollMap_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(this);
            TextX.Text = (Convert.ToInt32(position.X) - 1).ToString();
            TextY.Text = (Convert.ToInt32(position.Y) - 60).ToString();
        }
    }
}
