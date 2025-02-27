using System.Windows;
using System.Windows.Controls;

namespace Passwarden
{
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
        }

        // Открыть Popup для ввода названия вкладки
        private void ShowPopup(object sender, RoutedEventArgs e)
        {
            TabNameInput.Text = ""; // Очищаем поле ввода
            TabNamePopup.IsOpen = true; // Показываем Popup
        }

        // Подтвердить создание вкладки
        private void ConfirmTabName(object sender, RoutedEventArgs e)
        {
            string tabName = TabNameInput.Text.Trim();

            if (!string.IsNullOrEmpty(tabName))
            {
                // Создаём новую вкладку
                TabItem newTab = new TabItem
                {
                    Header = tabName,
                    Content = new TextBlock
                    {
                        Text = $"Контент вкладки: {tabName}",
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
                    }
                };

                // Добавляем в TabControl
                TabControlMain.Items.Add(newTab);
                TabControlMain.SelectedItem = newTab; // Переключаемся на неё
            }

            TabNamePopup.IsOpen = false; // Закрываем Popup
        }

        // Закрыть Popup без создания вкладки
        private void CancelTabName(object sender, RoutedEventArgs e)
        {
            TabNamePopup.IsOpen = false;
        }
    }
}
