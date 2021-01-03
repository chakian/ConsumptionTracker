using ConTrk.Business;
using ConTrk.Entities;
using System;
using System.Collections;
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

namespace ConTrk.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CategoryList_1.DataContext = new CategoryList();
        }

        private void CategoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int currentLevel = 0;
            string currentLevelName = ((ListBox)e.Source).Name;
            if (currentLevelName.IndexOf("CategoryList_") >= 0)
            {
                currentLevelName = currentLevelName.Replace("CategoryList_", "");
                int.TryParse(currentLevelName, out currentLevel);
            }
            var items = e.AddedItems;

            if (currentLevel <= 0)
            {
                items = null;
            }

            CategorySelectionChanged(currentLevel, items);
        }

        private void CategorySelectionChanged(int sourceLevel, IList items)
        {
            //(Category)items[0]
            var dockPanel = CategoryDockPanel;

            #region Find all stackpanels for levels bigger than the current one
            Dictionary<int, StackPanel> nextLevels = new Dictionary<int, StackPanel>();
            foreach (var item in dockPanel.Children)
            {
                if (item is StackPanel)
                {
                    string itemName = ((StackPanel)item).Name;
                    if (itemName.IndexOf("StackPanel_") >= 0)
                    {
                        itemName = itemName.Replace("StackPanel_", "");
                        int itemLevel;
                        if (int.TryParse(itemName, out itemLevel) && itemLevel > sourceLevel)
                        {
                            nextLevels.Add(itemLevel, (StackPanel)item);
                        }
                    }
                }
            }
            // remove all those next level stack panels
            foreach (var item in nextLevels)
            {
                dockPanel.Children.Remove(item.Value);
            }
            #endregion

            if (items != null && items.Count > 0 && ((Category)items[0]).Children.Count > 0)
            {
                int nextLevel = sourceLevel + 1;
                StackPanel nextStackPanel = new StackPanel();
                nextStackPanel.Name = $"StackPanel_{nextLevel}";
                DockPanel.SetDock(nextStackPanel, Dock.Right);

                Label label = new Label();
                label.Content = $"Kategori - {nextLevel}";

                ListBox listBox = new ListBox();
                listBox.Name = $"CategoryList_{nextLevel}";

                var selectionHandler = new SelectionChangedEventHandler(CategoryList_SelectionChanged);
                listBox.SelectionChanged += selectionHandler;

                //listBox.DataContext = ((Category)items[0]).Children;
                listBox.ItemsSource = ((Category)items[0]).Children;

                nextStackPanel.Children.Add(label);
                nextStackPanel.Children.Add(listBox);

                dockPanel.Children.Add(nextStackPanel);
            }
        }
    }
}
