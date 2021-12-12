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
using Microsoft.Win32;
using System.IO;

namespace GameEngine
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Dictionary<String, Object>> gameObjects;
        public List<Dictionary<String, Object>> assets;
        public SpeechSynthesizer debugger;

        public MainWindow()
        {
            InitializeComponent();

            gameObjects = new List<Dictionary<String, Object>>();
            assets = new List<Dictionary<String, Object>>();
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
            foreach (Dictionary<String, Object> gameObject in gameObjects)
            {
                gameObject["isSelected"] = false;
            }
            Dictionary<String, Object> newGameObject = new Dictionary<String, Object>();
            int gameObjectId = gameObjects.Count + 1;
            newGameObject.Add("id", gameObjectId);
            newGameObject.Add("isSelected", true);
            List<Dictionary<String, Object>> localComponents = new List<Dictionary<String, Object>>();
            newGameObject.Add("components", localComponents);
            gameObjects.Add(newGameObject);

            hierarchyGameObjects.Children.RemoveRange(0, hierarchyGameObjects.Children.Count);
            foreach (Dictionary<String, Object> gameObject in gameObjects)
            {
                StackPanel newHierarchyGameObject = new StackPanel();
                newHierarchyGameObject.Orientation = Orientation.Horizontal;
                if (((bool)(gameObject["isSelected"])))
                {
                    newHierarchyGameObject.Background = System.Windows.Media.Brushes.LightSlateGray;
                }
                else {
                    newHierarchyGameObject.Background = System.Windows.Media.Brushes.LightGray;
                }
                newHierarchyGameObject.Height = 35;
                TextBlock newHierarchyGameObjectToggler = new TextBlock();
                newHierarchyGameObjectToggler.Text = "⮫";
                newHierarchyGameObjectToggler.Margin = new Thickness(5, 0, 5, 0);
                newHierarchyGameObjectToggler.Width = 15;
                newHierarchyGameObjectToggler.MouseLeftButtonUp += ToggleGameObjectHandler;
                TextBlock newHierarchyGameObjectLabel = new TextBlock();
                newHierarchyGameObjectLabel.Text = "Игровой объект №" + gameObject["id"].ToString();
                newHierarchyGameObject.Children.Add(newHierarchyGameObjectToggler);
                newHierarchyGameObject.Children.Add(newHierarchyGameObjectLabel);
                hierarchyGameObjects.Children.Add(newHierarchyGameObject);
                newHierarchyGameObject.MouseLeftButtonUp += SelectGameObjectHandler;
            }

            selectedAddedComponent.Visibility = Visibility.Visible;
            addComponentBtn.Visibility = Visibility.Visible;

            components.Children.RemoveRange(0, components.Children.Count); 
            TextBlock notFoundComponents = new TextBlock();
            notFoundComponents.Text = "Нет прикрепленных компонентов";
            notFoundComponents.Margin = new Thickness(0, 5, 0, 5);
            components.Children.Add(notFoundComponents);

        }

        private void SelectGameObjectHandler(object sender, MouseButtonEventArgs e)
        {
            foreach (StackPanel hierarchyGameObject in hierarchyGameObjects.Children)
            {
                hierarchyGameObject.Background = System.Windows.Media.Brushes.LightGray;
                gameObjects[hierarchyGameObjects.Children.IndexOf(hierarchyGameObject)]["isSelected"] = false;
            }
            StackPanel currentGameObject = ((StackPanel)(sender));
            currentGameObject.Background = System.Windows.Media.Brushes.LightSlateGray;
            Dictionary<String, Object> selectedGameObject = gameObjects[hierarchyGameObjects.Children.IndexOf(currentGameObject)];
            selectedGameObject["isSelected"] = true;

            List<Dictionary<String, Object>> localComponents = ((List<Dictionary<String, Object>>)(selectedGameObject["components"]));
            components.Children.RemoveRange(0, components.Children.Count);
            if (localComponents.Count >= 1)
            {
                foreach (Dictionary<String, Object> component in localComponents)
                {
                    debugger.Speak("Обнаружен компонент " + component["name"].ToString());
                    StackPanel inspectorComponent = new StackPanel();
                    inspectorComponent.Orientation = Orientation.Horizontal;
                    inspectorComponent.Margin = new Thickness(10, 10, 10, 10);
                    TextBlock inspectorComponentIcon = new TextBlock();
                    inspectorComponentIcon.Margin = new Thickness(5, 0, 5, 0);
                    if (component["name"].ToString() == "Физика")
                    {
                        inspectorComponentIcon.Text = "⚛";
                    }
                    else if (component["name"].ToString() == "Свет")
                    {
                        inspectorComponentIcon.Text = "💡";
                    }
                    else if (component["name"].ToString() == "Система частиц")
                    {
                        inspectorComponentIcon.Text = "💦";
                    }
                    CheckBox inspectorComponentIsEnabled = new CheckBox();
                    inspectorComponentIsEnabled.Margin = new Thickness(5, 0, 5, 0);
                    inspectorComponentIsEnabled.IsChecked = true;
                    TextBlock inspectorComponentLabel = new TextBlock();
                    inspectorComponentLabel.Margin = new Thickness(5, 0, 5, 0);
                    inspectorComponentLabel.Text = component["name"].ToString();
                    inspectorComponent.Children.Add(inspectorComponentIcon);
                    inspectorComponent.Children.Add(inspectorComponentIsEnabled);
                    inspectorComponent.Children.Add(inspectorComponentLabel);
                    components.Children.Add(inspectorComponent);
                }
            } else if (localComponents.Count <= 0) {
                TextBlock notFoundComponents = new TextBlock();
                notFoundComponents.Text = "Нет прикрепленных компонентов";
                notFoundComponents.Margin = new Thickness(0, 5, 0, 5);
                components.Children.Add(notFoundComponents);
            }

        }

        private void AddComponentHandler(object sender, RoutedEventArgs e)
        {
            Dictionary<String, Object> selectedGameObject = null;
            foreach (Dictionary<String, Object> gameObject in gameObjects)
            {
                if (((bool)(gameObject["isSelected"])))
                {
                    selectedGameObject = gameObject;
                }
            }
            List<Dictionary<String, Object>> localComponents = ((List<Dictionary<String, Object>>)(selectedGameObject["components"]));
            Dictionary<String, Object> newComponent = new Dictionary<String, Object>();
            /*newComponent.Add("name", "Физика");*/
            newComponent.Add("name", selectedAddedComponent.SelectionBoxItem.ToString());
            localComponents.Add(newComponent);
            // debugger.Speak("Добавляю компонент " + components.Count.ToString());

            components.Children.RemoveRange(0, components.Children.Count);
            if (localComponents.Count >= 1)
            {
                foreach (Dictionary<String, Object> component in localComponents)
                {
                    debugger.Speak("Обнаружен компонент " + component["name"].ToString());
                    StackPanel inspectorComponent = new StackPanel();
                    inspectorComponent.Orientation = Orientation.Horizontal;
                    inspectorComponent.Margin = new Thickness(10, 10, 10, 10);
                    TextBlock inspectorComponentIcon = new TextBlock();
                    inspectorComponentIcon.Margin = new Thickness(5, 0, 5, 0);
                    if (component["name"].ToString() == "Физика")
                    {
                        inspectorComponentIcon.Text = "⚛";
                    }
                    else if (component["name"].ToString() == "Свет")
                    {
                        inspectorComponentIcon.Text = "💡";
                    }
                    else if (component["name"].ToString() == "Система частиц")
                    {
                        inspectorComponentIcon.Text = "💦";
                    }
                    CheckBox inspectorComponentIsEnabled = new CheckBox();
                    inspectorComponentIsEnabled.Margin = new Thickness(5, 0, 5, 0);
                    inspectorComponentIsEnabled.IsChecked = true;
                    TextBlock inspectorComponentLabel = new TextBlock();
                    inspectorComponentLabel.Margin = new Thickness(5, 0, 5, 0);
                    inspectorComponentLabel.Text = component["name"].ToString();
                    inspectorComponent.Children.Add(inspectorComponentIcon);
                    inspectorComponent.Children.Add(inspectorComponentIsEnabled);
                    inspectorComponent.Children.Add(inspectorComponentLabel);
                    components.Children.Add(inspectorComponent);
                }
            } else if (localComponents.Count <= 0) {
                TextBlock notFoundComponents = new TextBlock();
                notFoundComponents.Text = "Нет прикрепленных компонентов";
                notFoundComponents.Margin = new Thickness(0, 5, 0, 5);
                components.Children.Add(notFoundComponents);
            }

            selectedAddedComponent.SelectedIndex = 0;

        }

        private void ImportAssetHanler(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".png";
            ofd.Filter = "Png images (.png)|*.png";
            bool? res = ofd.ShowDialog();
            if (res != false)
            {
                Stream myStream;
                if ((myStream = ofd.OpenFile()) != null)
                {

                    projectAssets.Children.RemoveRange(0, projectAssets.Children.Count);

                    string file_name = ofd.FileName;
                    string file_text = File.ReadAllText(file_name);

                    Dictionary<String, Object> newAsset = new Dictionary<String, Object>();
                    int assetId = assets.Count + 1;
                    newAsset.Add("id", assetId);
                    newAsset.Add("isSelected", false);
                    assets.Add(newAsset);

                    foreach (Dictionary<String, Object> asset in assets)
                    {
                        StackPanel projectAsset = new StackPanel();
                        projectAsset.Margin = new Thickness(10, 10, 10, 10);
                        projectAsset.HorizontalAlignment = HorizontalAlignment.Left;
                        projectAsset.Width = 45;
                        if (((bool)(asset["isSelected"]))) {
                            projectAsset.Background = System.Windows.Media.Brushes.LightBlue;
                        }
                        TextBlock projectAssetIcon = new TextBlock();
                        projectAssetIcon.Text = "🖿";
                        // projectAssetIcon.Margin = new Thickness(5, 5, 5, 5);
                        projectAssetIcon.HorizontalAlignment = HorizontalAlignment.Center;
                        projectAssetIcon.FontSize = 36;
                        projectAssetIcon.Foreground = System.Windows.Media.Brushes.BlueViolet;
                        TextBlock projectAssetLabel = new TextBlock();
                        projectAssetLabel.Text = file_name;
                        // projectAssetLabel.Margin = new Thickness(5, 5, 5, 5);
                        projectAssetLabel.HorizontalAlignment = HorizontalAlignment.Center; 
                        projectAsset.Children.Add(projectAssetIcon);
                        projectAsset.Children.Add(projectAssetLabel);
                        projectAsset.MouseLeftButtonUp += SelectAssetHandler;
                        projectAssets.Children.Add(projectAsset);
                    }

                }
            }
            debugger.Speak("Ресурсов " + assets.Count.ToString());

        }

        private void SelectAssetHandler(object sender, RoutedEventArgs e)
        {
            foreach (Dictionary<String, Object> asset in assets)
            {
                asset["isSelected"] = false;
            }
            foreach (StackPanel projectAsset in projectAssets.Children)
            {
                projectAsset.Background = System.Windows.Media.Brushes.Transparent;
            }
            StackPanel selectedAsset = ((StackPanel)(sender));
            assets[projectAssets.Children.IndexOf(selectedAsset)]["isSelected"] = true;
            selectedAsset.Background = System.Windows.Media.Brushes.LightBlue;
        }

    }

}
