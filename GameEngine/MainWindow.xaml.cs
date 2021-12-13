﻿using System;
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
using System.Windows.Media.Media3D;

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
            /*Dictionary<String, Object> defautlTransformComponent = new Dictionary<String, Object>();
            defautlTransformComponent.Add("name", "Трансформация");
            localComponents.Add(defautlTransformComponent);*/
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

            ModelVisual3D gameObjectMesh = new ModelVisual3D();
            MeshGeometry3D gameObjectMeshGeometry3D = new MeshGeometry3D();
            Point3DCollection gameObjectMeshPositions = new Point3DCollection();
            gameObjectMeshPositions.Add(new Point3D(-0.5, -0.5, 0.5));
            gameObjectMeshPositions.Add(new Point3D(0.5, -0.5, 0.5));
            gameObjectMeshPositions.Add(new Point3D(0.5, 0.5, 0.5));
            gameObjectMeshPositions.Add(new Point3D(0.5, 0.5, 0.5));
            gameObjectMeshPositions.Add(new Point3D(-0.5, 0.5, 0.5));
            gameObjectMeshPositions.Add(new Point3D(-0.5, -0.5, 0.5));
            gameObjectMeshGeometry3D.Positions = gameObjectMeshPositions;
            GeometryModel3D gameObjectMeshGeometryModel = new GeometryModel3D();
            gameObjectMeshGeometryModel.Geometry = gameObjectMeshGeometry3D;
            Transform3DGroup gameObjectMeshTransform = new Transform3DGroup();
            ScaleTransform3D gameObjectMeshTransformScale = new ScaleTransform3D();
            gameObjectMeshTransformScale.ScaleX = 0.1;
            gameObjectMeshTransformScale.ScaleY = 0.1;
            gameObjectMeshTransformScale.ScaleZ = 0.1;
            TranslateTransform3D gameObjectMeshTransformTranslate = new TranslateTransform3D();
            gameObjectMeshTransformTranslate.OffsetX = 0;
            gameObjectMeshTransformTranslate.OffsetY = 0;
            gameObjectMeshTransformTranslate.OffsetZ = 0;
            RotateTransform3D gameObjectMeshTransformRotate = new RotateTransform3D();
            gameObjectMeshTransformRotate.Rotation = new AxisAngleRotation3D(new Vector3D(0, 0, 0), 0);
            gameObjectMeshTransform.Children.Add(gameObjectMeshTransformTranslate);
            gameObjectMeshTransform.Children.Add(gameObjectMeshTransformScale);
            gameObjectMeshTransform.Children.Add(gameObjectMeshTransformRotate);
            gameObjectMeshGeometryModel.Transform = gameObjectMeshTransform;
            MaterialGroup gameObjectMeshMaterialGroup = new MaterialGroup();
            DiffuseMaterial gameObjectMeshDiffuseMaterial = new DiffuseMaterial();
            Color gameObjectMeshSolidColor = new Color();
            gameObjectMeshSolidColor.R = 255;
            gameObjectMeshSolidColor.G = 0;
            gameObjectMeshSolidColor.B = 0;
            gameObjectMeshDiffuseMaterial.Brush = System.Windows.Media.Brushes.Red;
            gameObjectMeshMaterialGroup.Children.Add(gameObjectMeshDiffuseMaterial);
            gameObjectMeshGeometryModel.Material = gameObjectMeshMaterialGroup;
            gameObjectMesh.Content = gameObjectMeshGeometryModel;
            space.Children.Add(gameObjectMesh);
            debugger.Speak(space.Children.Count.ToString());

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
                    StackPanel inspectorComponentHeader = new StackPanel();
                    inspectorComponentHeader.Orientation = Orientation.Horizontal;
                    inspectorComponentHeader.Margin = new Thickness(10, 10, 10, 10);
                    TextBlock inspectorComponentHeaderIcon = new TextBlock();
                    inspectorComponentHeaderIcon.Margin = new Thickness(5, 0, 5, 0);
                    if (component["name"].ToString() == "Трансформация")
                    {
                        inspectorComponentHeaderIcon.Text = "⤧";
                    }
                    else if (component["name"].ToString() == "Физика")
                    {
                        inspectorComponentHeaderIcon.Text = "⚛";
                    }
                    else if (component["name"].ToString() == "Свет")
                    {
                        inspectorComponentHeaderIcon.Text = "💡";
                    }
                    else if (component["name"].ToString() == "Система частиц")
                    {
                        inspectorComponentHeaderIcon.Text = "💦";
                    }
                    CheckBox inspectorComponentHeaderIsEnabled = new CheckBox();
                    inspectorComponentHeaderIsEnabled.Margin = new Thickness(5, 0, 5, 0);
                    inspectorComponentHeaderIsEnabled.IsChecked = true;
                    TextBlock inspectorComponentHeaderLabel = new TextBlock();
                    inspectorComponentHeaderLabel.Margin = new Thickness(5, 0, 5, 0);
                    inspectorComponentHeaderLabel.Text = component["name"].ToString();
                    inspectorComponentHeader.Children.Add(inspectorComponentHeaderIcon);
                    inspectorComponentHeader.Children.Add(inspectorComponentHeaderIsEnabled);
                    inspectorComponentHeader.Children.Add(inspectorComponentHeaderLabel);

                    StackPanel inspectorComponentBody = new StackPanel();
                    if (component["name"].ToString() == "Трансформация")
                    {
                        StackPanel inspectorComponentBodyItem = new StackPanel();
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        TextBlock inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "X";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        TextBox inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Y";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Z";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBody.Children.Add(inspectorComponentBodyItem);
                        inspectorComponentBodyItem = new StackPanel();
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "X";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Y";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Z";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBody.Children.Add(inspectorComponentBodyItem);
                        inspectorComponentBodyItem = new StackPanel();
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "X";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Y";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Z";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBody.Children.Add(inspectorComponentBodyItem);
                    }
                    else if (component["name"].ToString() == "Физика")
                    {
                        
                    }
                    else if (component["name"].ToString() == "Свет")
                    {
                        
                    }
                    else if (component["name"].ToString() == "Система частиц")
                    {
                        
                    }
                    inspectorComponent.Children.Add(inspectorComponentHeader);
                    inspectorComponent.Children.Add(inspectorComponentBody);
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
                    StackPanel inspectorComponentHeader = new StackPanel();
                    inspectorComponentHeader.Orientation = Orientation.Horizontal;
                    inspectorComponentHeader.Margin = new Thickness(10, 10, 10, 10);
                    TextBlock inspectorComponentHeaderIcon = new TextBlock();
                    inspectorComponentHeaderIcon.Margin = new Thickness(5, 0, 5, 0);
                    if (component["name"].ToString() == "Трансформация")
                    {
                        inspectorComponentHeaderIcon.Text = "⤧";
                    }
                    else if (component["name"].ToString() == "Физика")
                    {
                        inspectorComponentHeaderIcon.Text = "⚛";
                    }
                    else if (component["name"].ToString() == "Свет")
                    {
                        inspectorComponentHeaderIcon.Text = "💡";
                    }
                    else if (component["name"].ToString() == "Система частиц")
                    {
                        inspectorComponentHeaderIcon.Text = "💦";
                    }
                    CheckBox inspectorComponentHeaderIsEnabled = new CheckBox();
                    inspectorComponentHeaderIsEnabled.Margin = new Thickness(5, 0, 5, 0);
                    inspectorComponentHeaderIsEnabled.IsChecked = true;
                    TextBlock inspectorComponentHeaderLabel = new TextBlock();
                    inspectorComponentHeaderLabel.Margin = new Thickness(5, 0, 5, 0);
                    inspectorComponentHeaderLabel.Text = component["name"].ToString();
                    inspectorComponentHeader.Children.Add(inspectorComponentHeaderIcon);
                    inspectorComponentHeader.Children.Add(inspectorComponentHeaderIsEnabled);
                    inspectorComponentHeader.Children.Add(inspectorComponentHeaderLabel);

                    StackPanel inspectorComponentBody = new StackPanel();
                    if (component["name"].ToString() == "Трансформация")
                    {
                        StackPanel inspectorComponentBodyItem = new StackPanel();
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        TextBlock inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "X";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        TextBox inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Y";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Z";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBody.Children.Add(inspectorComponentBodyItem);
                        inspectorComponentBodyItem = new StackPanel();
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "X";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Y";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Z";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBody.Children.Add(inspectorComponentBodyItem);
                        inspectorComponentBodyItem = new StackPanel();
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "X";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Y";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Z";
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBody.Children.Add(inspectorComponentBodyItem);
                    }
                    else if (component["name"].ToString() == "Физика")
                    {
                        
                    }
                    else if (component["name"].ToString() == "Свет")
                    {
                        
                    }
                    else if (component["name"].ToString() == "Система частиц")
                    {
                        
                    }
                    inspectorComponent.Children.Add(inspectorComponentHeader);
                    inspectorComponent.Children.Add(inspectorComponentBody);
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

        private void GlobalHotKeysHandler(object sender, KeyEventArgs e)
        {
            if (gameObjects.Count >= 1) {
                Dictionary<String, Object> selectedGameObject = null;
                foreach (Dictionary<String, Object> gameObject in gameObjects)
                {
                    if (((bool)(gameObject["isSelected"])))
                    {
                        selectedGameObject = gameObject;
                    }
                }
                int gameObjectIndex = gameObjects.IndexOf(selectedGameObject);
                if ((Keyboard.Modifiers & ModifierKeys.Control) > 0)
                {
                    if (e.Key == Key.Left)
                    {
                        ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                        Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                        Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                        RotateTransform3D currentMeshTransformRotate = ((RotateTransform3D)(currentMeshTransform.Children[2]));
                        currentMeshTransformRotate.Rotation = new AxisAngleRotation3D(new Vector3D(0, 0, 1), ((AxisAngleRotation3D)(currentMeshTransformRotate.Rotation)).Angle - 15);
                    }
                    else if (e.Key == Key.Right)
                    {
                        ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                        Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                        Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                        RotateTransform3D currentMeshTransformRotate = ((RotateTransform3D)(currentMeshTransform.Children[2]));
                        currentMeshTransformRotate.Rotation = new AxisAngleRotation3D(new Vector3D(0, 0, 1), ((AxisAngleRotation3D)(currentMeshTransformRotate.Rotation)).Angle + 15);
                    }
                }
                else if ((Keyboard.Modifiers & ModifierKeys.Shift) > 0)
                {
                    if (e.Key == Key.Left)
                    {
                        ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                        Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                        Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                        ScaleTransform3D currentMeshTransformScale = ((ScaleTransform3D)(currentMeshTransform.Children[1]));
                        currentMeshTransformScale.ScaleX -= 0.1;
                        currentMeshTransformScale.ScaleY -= 0.1;
                        currentMeshTransformScale.ScaleZ -= 0.1;
                    }
                    else if (e.Key == Key.Right)
                    {
                        ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                        Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                        Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                        ScaleTransform3D currentMeshTransformScale = ((ScaleTransform3D)(currentMeshTransform.Children[1]));
                        currentMeshTransformScale.ScaleX += 0.1;
                        currentMeshTransformScale.ScaleY += 0.1;
                        currentMeshTransformScale.ScaleZ += 0.1;
                    }
                }
                else
                {
                    if (e.Key == Key.Left)
                    {
                        ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                        Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                        Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                        TranslateTransform3D currentMeshTransformTranslate = ((TranslateTransform3D)(currentMeshTransform.Children[0]));
                        currentMeshTransformTranslate.OffsetX -= 1;
                    }
                    else if (e.Key == Key.Right)
                    {
                        ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                        Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                        Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                        TranslateTransform3D currentMeshTransformTranslate = ((TranslateTransform3D)(currentMeshTransform.Children[0]));
                        currentMeshTransformTranslate.OffsetX += 1;
                    }
                    else if (e.Key == Key.Up)
                    {
                        ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                        Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                        Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                        TranslateTransform3D currentMeshTransformTranslate = ((TranslateTransform3D)(currentMeshTransform.Children[0]));
                        currentMeshTransformTranslate.OffsetY += 1;
                    }
                    else if (e.Key == Key.Down)
                    {
                        ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                        Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                        Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                        TranslateTransform3D currentMeshTransformTranslate = ((TranslateTransform3D)(currentMeshTransform.Children[0]));
                        currentMeshTransformTranslate.OffsetY -= 1;
                    }
                }
            }
        }
    }

}
