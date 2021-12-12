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
using System.Speech.Synthesis;

namespace GameEngine
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Dictionary<String, Object>> gameObjects;
        public SpeechSynthesizer debugger;

        public MainWindow()
        {
            InitializeComponent();

            gameObjects = new List<Dictionary<String, Object>>();
            debugger = new SpeechSynthesizer();

        }

        private void ToggleGameObjectHandler(object sender, MouseButtonEventArgs e)
        {
            TextBlock gameObjectToggler = ((TextBlock)(sender));
            bool isGameObjectDrop = gameObjectToggler.Text == "⮮";
            if (isGameObjectDrop)
            {
                gameObjectToggler.Text = "⮫";
            }
            else if (!isGameObjectDrop)
            {
                gameObjectToggler.Text = "⮮";
            }
        }

        private void CreateGameObjectHandler(object sender, RoutedEventArgs e)
        {
            Dictionary<String, Object> newGameObject = new Dictionary<String, Object>();
            int gameObjectId = gameObjects.Count + 1;
            newGameObject.Add("id", gameObjectId);
            gameObjects.Add(newGameObject);
            debugger.Speak(gameObjects.Count.ToString());

            hierarchyGameObjects.Children.RemoveRange(0, hierarchyGameObjects.Children.Count);
            foreach (Dictionary<String, Object> gameObject in gameObjects)
            {
                StackPanel newHierarchyGameObject = new StackPanel();
                newHierarchyGameObject.Orientation = Orientation.Horizontal;
                newHierarchyGameObject.Background = System.Windows.Media.Brushes.LightGray;
                newHierarchyGameObject.Height = 35;
                TextBlock newHierarchyGameObjectToggler = new TextBlock();
                newHierarchyGameObjectToggler.Text = "⮫";
                newHierarchyGameObjectToggler.Margin = new Thickness(5, 0, 5, 0);
                TextBlock newHierarchyGameObjectLabel = new TextBlock();
                newHierarchyGameObjectLabel.Text = "Игровой объект №" + gameObject["id"].ToString();
                newHierarchyGameObject.Children.Add(newHierarchyGameObjectToggler);
                newHierarchyGameObject.Children.Add(newHierarchyGameObjectLabel);
                hierarchyGameObjects.Children.Add(newHierarchyGameObject);
            }
        }

    }
}
