using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Passwarden;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
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

    // Вспомогательный метод для поиска родительского элемента
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