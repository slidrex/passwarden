using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Passwarden;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var items = new List<ListItem>
            {
                new ListItem { Username = "user1", Password = "pass123", Priority = "High", Date = DateTime.Now },
                new ListItem { Username = "user2", Password = "qwerty", Priority = "Medium", Date = DateTime.Now.AddDays(-1) },
                new ListItem { Username = "user3", Password = "abc123", Priority = "Low", Date = DateTime.Now.AddDays(-2) }
            };

        // Привязываем коллекцию к ListView
        PrimaryList.ItemsSource = items;
    }
    
    private void CopyPassword_Click(object sender, RoutedEventArgs e)
    {
        // Получаем выбранный элемент
        var selectedItem = PrimaryList.SelectedItem as ListItem;
        if (selectedItem != null)
        {
            // Копируем пароль в буфер обмена
            Clipboard.SetText(selectedItem.Password);
        }
    }
    private void CloseTabButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is TabItem tabItem)
        {
            var tabControl = FindParent<TabControl>(tabItem);
            if (tabControl != null)
            {
                tabControl.Items.Remove(tabItem);
            }
        }
    }

    private void DeleteTabMenuItem_Click(object sender, RoutedEventArgs e)
    {
        if (sender is MenuItem menuItem && menuItem.Tag is TabItem tabItem)
        {
            var tabControl = FindParent<TabControl>(tabItem);
            if (tabControl != null)
            {
                tabControl.Items.Remove(tabItem);
            }
        }
    }
    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (PrimaryList.SelectedItem is ListItem selectedItem)
        {
            EditWindow editWindow = new EditWindow(selectedItem);
            if (editWindow.ShowDialog() == true)
            {
                PrimaryList.Items.Refresh();
            }
        }
    }

    private void RenameTabMenuItem_Click(object sender, RoutedEventArgs e)
    {
        if (sender is MenuItem menuItem && menuItem.Tag is TabItem tabItem)
        {
            var newName = Microsoft.VisualBasic.Interaction.InputBox("Введите новое имя вкладки:", "Переименовать", tabItem.Header.ToString());
            if (!string.IsNullOrEmpty(newName))
            { //todo
                tabItem.Header = newName;
            }
        }
    }

    private void AddTabButton_Click(object sender, RoutedEventArgs e)
    {
        var tabControl = FindParent<TabControl>((Button)sender);
        if (tabControl != null)
        {
            var newTab = new TabItem
            {
                Header = "Новая вкладка",
                Content = new TextBlock { Text = "Содержимое новой вкладки" }
            };
            tabControl.Items.Add(newTab);
        }
    }

    private T FindParent<T>(DependencyObject child) where T : DependencyObject
    {
        var parent = VisualTreeHelper.GetParent(child);
        while (parent != null && !(parent is T))
        {
            parent = VisualTreeHelper.GetParent(parent);
        }
        return parent as T;
    }
}
public class ListItem
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Priority { get; set; }
    public DateTime Date { get; set; }
}