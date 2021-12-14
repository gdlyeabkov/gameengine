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
using System.Windows.Media.Media3D;
using FarseerPhysics;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace GameEngine
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Dictionary<String, Object>> gameObjects;
        public List<Dictionary<String, Object>> assets;
        public bool graphicMode = false;
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
            gameObjectMeshPositions.Add(new Point3D(0, 0, 0));
            gameObjectMeshPositions.Add(new Point3D(1, 0, 0));
            gameObjectMeshPositions.Add(new Point3D(1, 1, 0));
            gameObjectMeshPositions.Add(new Point3D(0, 1, 0));
            gameObjectMeshPositions.Add(new Point3D(0, 0, 1));
            gameObjectMeshPositions.Add(new Point3D(1, 0, 1));
            gameObjectMeshPositions.Add(new Point3D(1, 1, 1));
            gameObjectMeshPositions.Add(new Point3D(0, 1, 1));
            gameObjectMeshGeometry3D.Positions = gameObjectMeshPositions;
            Int32Collection gameObjectMeshTriangleIndices = new Int32Collection();
            gameObjectMeshTriangleIndices.Add(0);
            gameObjectMeshTriangleIndices.Add(1);
            gameObjectMeshTriangleIndices.Add(3);
            gameObjectMeshTriangleIndices.Add(1);
            gameObjectMeshTriangleIndices.Add(2);
            gameObjectMeshTriangleIndices.Add(3);
            gameObjectMeshTriangleIndices.Add(0);
            gameObjectMeshTriangleIndices.Add(4);
            gameObjectMeshTriangleIndices.Add(3);
            gameObjectMeshTriangleIndices.Add(4);
            gameObjectMeshTriangleIndices.Add(7);
            gameObjectMeshTriangleIndices.Add(3);
            gameObjectMeshTriangleIndices.Add(4);
            gameObjectMeshTriangleIndices.Add(6);
            gameObjectMeshTriangleIndices.Add(7);
            gameObjectMeshTriangleIndices.Add(4);
            gameObjectMeshTriangleIndices.Add(5);
            gameObjectMeshTriangleIndices.Add(6);
            gameObjectMeshTriangleIndices.Add(0);
            gameObjectMeshTriangleIndices.Add(4);
            gameObjectMeshTriangleIndices.Add(1);
            gameObjectMeshTriangleIndices.Add(1);
            gameObjectMeshTriangleIndices.Add(4);
            gameObjectMeshTriangleIndices.Add(5);
            gameObjectMeshTriangleIndices.Add(1);
            gameObjectMeshTriangleIndices.Add(2);
            gameObjectMeshTriangleIndices.Add(6);
            gameObjectMeshTriangleIndices.Add(6);
            gameObjectMeshTriangleIndices.Add(5);
            gameObjectMeshTriangleIndices.Add(1);
            gameObjectMeshTriangleIndices.Add(2);
            gameObjectMeshTriangleIndices.Add(3);
            gameObjectMeshTriangleIndices.Add(7);
            gameObjectMeshTriangleIndices.Add(7);
            gameObjectMeshTriangleIndices.Add(6);
            gameObjectMeshTriangleIndices.Add(2);
            gameObjectMeshGeometry3D.TriangleIndices = gameObjectMeshTriangleIndices;
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
            /*gameObjectMeshTransformRotate.Rotation = new QuaternionRotation3D(new Quaternion(0, 0, 0, 0));*/
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


            /*foreach (Dictionary<String, Object> asset in assets.Where<Dictionary<String, Object>>((Dictionary<String, Object> asset) => asset["type"] == "script")) {
                ComboBoxItem customComponent = new ComboBoxItem();
                customComponent.Content = asset["name"];
                selectedAddedComponent.Items.Add(customComponent);
            }*/

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
                    
                    int gameObjectIndex = gameObjects.IndexOf(selectedGameObject);
                    ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                    Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                    Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                    TranslateTransform3D currentMeshTransformTranslate = ((TranslateTransform3D)(currentMeshTransform.Children[0]));
                    RotateTransform3D currentMeshTransformRotate = ((RotateTransform3D)(currentMeshTransform.Children[2]));
                    ScaleTransform3D currentMeshTransformScale = ((ScaleTransform3D)(currentMeshTransform.Children[1]));

                    if (component["name"].ToString() == "Трансформация")
                    {

                        StackPanel inspectorComponentBodyItem = new StackPanel();
                        inspectorComponentBodyItem.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        TextBlock inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Положение";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBody.Children.Add(inspectorComponentBodyItem);

                        inspectorComponentBodyItem = new StackPanel();
                        inspectorComponentBodyItem.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "X";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        TextBox inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = currentMeshTransformTranslate.OffsetX.ToString();
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentTranslateXPropertyHandler;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Y";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = currentMeshTransformTranslate.OffsetY.ToString();
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentTranslateYPropertyHandler;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Z";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = currentMeshTransformTranslate.OffsetZ.ToString();
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentTranslateZPropertyHandler;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBody.Children.Add(inspectorComponentBodyItem);

                        inspectorComponentBodyItem = new StackPanel();
                        inspectorComponentBodyItem.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Поворот";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBody.Children.Add(inspectorComponentBodyItem);

                        inspectorComponentBodyItem = new StackPanel();
                        inspectorComponentBodyItem.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "X";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = "0";
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentRotateXPropertyHandler;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Y";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = "0";
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentRotateYPropertyHandler;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Z";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = ((AxisAngleRotation3D)(currentMeshTransformRotate.Rotation)).Angle.ToString();
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentRotateZPropertyHandler;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBody.Children.Add(inspectorComponentBodyItem);

                        inspectorComponentBodyItem = new StackPanel();
                        inspectorComponentBodyItem.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Масштаб";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBody.Children.Add(inspectorComponentBodyItem);

                        inspectorComponentBodyItem = new StackPanel();
                        inspectorComponentBodyItem.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "X";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = currentMeshTransformScale.ScaleX.ToString();
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentScaleXPropertyHandler;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Y";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = currentMeshTransformScale.ScaleY.ToString();
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentScaleYPropertyHandler;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Z";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = currentMeshTransformScale.ScaleZ.ToString();
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentScaleZPropertyHandler;
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
                        inspectorComponentBodyItem.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        TextBlock inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Положение";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBody.Children.Add(inspectorComponentBodyItem);

                        inspectorComponentBodyItem = new StackPanel();
                        inspectorComponentBodyItem.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "X";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        TextBox inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = "0";
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentTranslateXPropertyHandler;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Y";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = "0";
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentTranslateYPropertyHandler;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Z";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = "0";
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentTranslateZPropertyHandler;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBody.Children.Add(inspectorComponentBodyItem);

                        inspectorComponentBodyItem = new StackPanel();
                        inspectorComponentBodyItem.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Поворот";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBody.Children.Add(inspectorComponentBodyItem);

                        inspectorComponentBodyItem = new StackPanel();
                        inspectorComponentBodyItem.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "X";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = "0";
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentRotateXPropertyHandler; 
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Y";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = "0";
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentRotateYPropertyHandler;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Z";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = "0";
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentRotateZPropertyHandler;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBody.Children.Add(inspectorComponentBodyItem);

                        inspectorComponentBodyItem = new StackPanel();
                        inspectorComponentBodyItem.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Масштаб";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBody.Children.Add(inspectorComponentBodyItem);

                        inspectorComponentBodyItem = new StackPanel();
                        inspectorComponentBodyItem.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Orientation = Orientation.Horizontal;
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "X";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = "0.1";
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentScaleXPropertyHandler;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Y";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = "0.1";
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentScaleYPropertyHandler;
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemInput);
                        inspectorComponentBodyItemLabel = new TextBlock();
                        inspectorComponentBodyItemLabel.Text = "Z";
                        inspectorComponentBodyItemLabel.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItem.Children.Add(inspectorComponentBodyItemLabel);
                        inspectorComponentBodyItemInput = new TextBox();
                        inspectorComponentBodyItemInput.Width = 15;
                        inspectorComponentBodyItemInput.Margin = new Thickness(5, 5, 5, 5);
                        inspectorComponentBodyItemInput.Text = "0.1";
                        inspectorComponentBodyItemInput.KeyUp += SetTransformComponentScaleZPropertyHandler;
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
            /*ofd.DefaultExt = ".png";
            ofd.Filter = "Png images (.png)|*.png";*/
            bool? res = ofd.ShowDialog();
            if (res != false)
            {
                Stream myStream;
                if ((myStream = ofd.OpenFile()) != null)
                {

                    string file_name = ofd.FileName;
                    string file_ext = file_name.Split(new char[] { '.' })[1];
                    string assetType = "unknown";
                    if (file_ext == "png")
                    {
                        assetType = "image";
                    } else if (file_ext == "cs")
                    {
                        assetType = "script";
                    }
                    string file_text = File.ReadAllText(file_name);

                    if (assetType != "unknown") {
                        projectAssets.Children.RemoveRange(0, projectAssets.Children.Count);
                        Dictionary<String, Object> newAsset = new Dictionary<String, Object>();
                        int assetId = assets.Count + 1;
                        newAsset.Add("id", assetId);
                        newAsset.Add("name", file_name.Split(new char[] { '/', '\\' })[file_name.Split(new char[] { '/', '\\' }).Count() - 1].Split(new char[] { '.' })[0]);
                        newAsset.Add("isSelected", false);
                        newAsset.Add("type", assetType);
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
                            /*projectAssetLabel.Text = file_name;*/
                            projectAssetLabel.Text = asset["name"].ToString();
                            // projectAssetLabel.Margin = new Thickness(5, 5, 5, 5);
                            projectAssetLabel.HorizontalAlignment = HorizontalAlignment.Center; 
                            projectAsset.Children.Add(projectAssetIcon);
                            projectAsset.Children.Add(projectAssetLabel);
                            projectAsset.MouseLeftButtonUp += SelectAssetHandler;
                            projectAssets.Children.Add(projectAsset);
                        }

                        if (assetType == "script") {
                            /*for (int selectedAddedComponentItemIdx = 4; selectedAddedComponentItemIdx < selectedAddedComponent.Items.Count; selectedAddedComponentItemIdx++)
                            {
                                selectedAddedComponent.Items.RemoveAt(selectedAddedComponentItemIdx);
                            }
                            foreach (Dictionary<String, Object> asset in assets.Where<Dictionary<String, Object>>((Dictionary<String, Object> asset) => asset["type"].ToString() == "script"))
                            {
                                ComboBoxItem customComponent = new ComboBoxItem();
                                customComponent.Content = asset["name"];
                                selectedAddedComponent.Items.Add(customComponent);
                            }*/
                            ComboBoxItem customComponent = new ComboBoxItem();
                            customComponent.Content = assets[assets.Count - 1]["name"].ToString();
                            selectedAddedComponent.Items.Add(customComponent);
                        }
                        
                        debugger.Speak("Тип ресурса " + assets[assets.Count - 1]["type"]);

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
            /*if (gameObjects.Count >= 1) {
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
            }*/
        }
        private void SetTransformComponentTranslateXPropertyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) {
                TextBox settedProperty = ((TextBox)(sender));
                int settedPropertyValue = Int32.Parse(settedProperty.Text);
                Dictionary<String, Object> selectedGameObject = null;
                foreach (Dictionary<String, Object> gameObject in gameObjects)
                {
                    if (((bool)(gameObject["isSelected"])))
                    {
                        selectedGameObject = gameObject;
                    }
                }
                int gameObjectIndex = gameObjects.IndexOf(selectedGameObject);
                ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                TranslateTransform3D currentMeshTransformTranslate = ((TranslateTransform3D)(currentMeshTransform.Children[0]));
                currentMeshTransformTranslate.OffsetX = settedPropertyValue;
            }
        }

        private void SetTransformComponentTranslateYPropertyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox settedProperty = ((TextBox)(sender));
                int settedPropertyValue = Int32.Parse(settedProperty.Text);
                Dictionary<String, Object> selectedGameObject = null;
                foreach (Dictionary<String, Object> gameObject in gameObjects)
                {
                    if (((bool)(gameObject["isSelected"])))
                    {
                        selectedGameObject = gameObject;
                    }
                }
                int gameObjectIndex = gameObjects.IndexOf(selectedGameObject);
                ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                TranslateTransform3D currentMeshTransformTranslate = ((TranslateTransform3D)(currentMeshTransform.Children[0]));
                currentMeshTransformTranslate.OffsetY = settedPropertyValue;
            }
        }

        private void SetTransformComponentTranslateZPropertyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox settedProperty = ((TextBox)(sender));
                int settedPropertyValue = Int32.Parse(settedProperty.Text);
                Dictionary<String, Object> selectedGameObject = null;
                foreach (Dictionary<String, Object> gameObject in gameObjects)
                {
                    if (((bool)(gameObject["isSelected"])))
                    {
                        selectedGameObject = gameObject;
                    }
                }
                int gameObjectIndex = gameObjects.IndexOf(selectedGameObject);
                ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                TranslateTransform3D currentMeshTransformTranslate = ((TranslateTransform3D)(currentMeshTransform.Children[0]));
                currentMeshTransformTranslate.OffsetZ = settedPropertyValue;
            }
        }

        private void SetTransformComponentRotateXPropertyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox settedProperty = ((TextBox)(sender));
                int settedPropertyValue = Int32.Parse(settedProperty.Text);
                Dictionary<String, Object> selectedGameObject = null;
                foreach (Dictionary<String, Object> gameObject in gameObjects)
                {
                    if (((bool)(gameObject["isSelected"])))
                    {
                        selectedGameObject = gameObject;
                    }
                }
                int gameObjectIndex = gameObjects.IndexOf(selectedGameObject);
                ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                RotateTransform3D currentMeshTransformRotate = ((RotateTransform3D)(currentMeshTransform.Children[2]));
                currentMeshTransformRotate.Rotation = new AxisAngleRotation3D(new Vector3D(1, 0, 0), settedPropertyValue);
                /*currentMeshTransformRotate.Rotation = new QuaternionRotation3D(new Quaternion(settedPropertyValue, ((QuaternionRotation3D)(currentMeshTransformRotate.Rotation)).Quaternion.Y, ((QuaternionRotation3D)(currentMeshTransformRotate.Rotation)).Quaternion.Z, ((QuaternionRotation3D)(currentMeshTransformRotate.Rotation)).Quaternion.W));*/
            }
        }
        private void SetTransformComponentRotateYPropertyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox settedProperty = ((TextBox)(sender));
                int settedPropertyValue = Int32.Parse(settedProperty.Text);
                Dictionary<String, Object> selectedGameObject = null;
                foreach (Dictionary<String, Object> gameObject in gameObjects)
                {
                    if (((bool)(gameObject["isSelected"])))
                    {
                        selectedGameObject = gameObject;
                    }
                }
                int gameObjectIndex = gameObjects.IndexOf(selectedGameObject);
                ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                RotateTransform3D currentMeshTransformRotate = ((RotateTransform3D)(currentMeshTransform.Children[2]));
                currentMeshTransformRotate.Rotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), settedPropertyValue);
                /*currentMeshTransformRotate.Rotation = new QuaternionRotation3D(new Quaternion(((QuaternionRotation3D)(currentMeshTransformRotate.Rotation)).Quaternion.X, settedPropertyValue, ((QuaternionRotation3D)(currentMeshTransformRotate.Rotation)).Quaternion.Z, ((QuaternionRotation3D)(currentMeshTransformRotate.Rotation)).Quaternion.W));*/
            }
        }

        private void SetTransformComponentRotateZPropertyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox settedProperty = ((TextBox)(sender));
                int settedPropertyValue = Int32.Parse(settedProperty.Text);
                Dictionary<String, Object> selectedGameObject = null;
                foreach (Dictionary<String, Object> gameObject in gameObjects)
                {
                    if (((bool)(gameObject["isSelected"])))
                    {
                        selectedGameObject = gameObject;
                    }
                }
                int gameObjectIndex = gameObjects.IndexOf(selectedGameObject);
                ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                RotateTransform3D currentMeshTransformRotate = ((RotateTransform3D)(currentMeshTransform.Children[2]));
                currentMeshTransformRotate.Rotation = new AxisAngleRotation3D(new Vector3D(0, 0, 1), settedPropertyValue);
                /*currentMeshTransformRotate.Rotation = new QuaternionRotation3D(new Quaternion(((QuaternionRotation3D)(currentMeshTransformRotate.Rotation)).Quaternion.X, ((QuaternionRotation3D)(currentMeshTransformRotate.Rotation)).Quaternion.Y, settedPropertyValue, ((QuaternionRotation3D)(currentMeshTransformRotate.Rotation)).Quaternion.W));*/
            }
        }

        private void SetTransformComponentScaleXPropertyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox settedProperty = ((TextBox)(sender));
                int settedPropertyValue = Int32.Parse(settedProperty.Text);
                Dictionary<String, Object> selectedGameObject = null;
                foreach (Dictionary<String, Object> gameObject in gameObjects)
                {
                    if (((bool)(gameObject["isSelected"])))
                    {
                        selectedGameObject = gameObject;
                    }
                }
                int gameObjectIndex = gameObjects.IndexOf(selectedGameObject);
                ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                ScaleTransform3D currentMeshTransformScale = ((ScaleTransform3D)(currentMeshTransform.Children[1]));
                currentMeshTransformScale.ScaleX = settedPropertyValue;
            }
        }

        private void SetTransformComponentScaleYPropertyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox settedProperty = ((TextBox)(sender));
                int settedPropertyValue = Int32.Parse(settedProperty.Text);
                Dictionary<String, Object> selectedGameObject = null;
                foreach (Dictionary<String, Object> gameObject in gameObjects)
                {
                    if (((bool)(gameObject["isSelected"])))
                    {
                        selectedGameObject = gameObject;
                    }
                }
                int gameObjectIndex = gameObjects.IndexOf(selectedGameObject);
                ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                ScaleTransform3D currentMeshTransformScale = ((ScaleTransform3D)(currentMeshTransform.Children[1]));
                currentMeshTransformScale.ScaleY = settedPropertyValue;
            }
        }

        private void SetTransformComponentScaleZPropertyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox settedProperty = ((TextBox)(sender));
                int settedPropertyValue = Int32.Parse(settedProperty.Text);
                Dictionary<String, Object> selectedGameObject = null;
                foreach (Dictionary<String, Object> gameObject in gameObjects)
                {
                    if (((bool)(gameObject["isSelected"])))
                    {
                        selectedGameObject = gameObject;
                    }
                }
                int gameObjectIndex = gameObjects.IndexOf(selectedGameObject);
                ModelVisual3D currentMesh = ((ModelVisual3D)(space.Children[gameObjectIndex + 1]));
                Model3D currentMeshModel = ((Model3D)(currentMesh.Content));
                Transform3DGroup currentMeshTransform = ((Transform3DGroup)(currentMeshModel.Transform));
                ScaleTransform3D currentMeshTransformScale = ((ScaleTransform3D)(currentMeshTransform.Children[1]));
                currentMeshTransformScale.ScaleZ = settedPropertyValue;
            }
        }

        private void PlayHandler(object sender, RoutedEventArgs e)
        {
            /*Process.Start(@"C:\csScripts\GameManager.cs");*/
            /*Process proc = new Process();
            proc.StartInfo.FileName = "c:\\csScripts\\GameManager.cs";
            proc.StartInfo.WorkingDirectory = @"c:\csScripts\";
            proc.Start();*/
            // proc.WaitForExit();
            /*double s = CSharpScript.EvaluateAsync<double>("5 + 7").Result;*/
            /*int s = CSharpScript.EvaluateAsync<int>(@"
                using System;
                using System.Speech.Synthesis;
                class GameManager
                {
                    public SpeechSynthesizer debugger;
                    static int Main(string[] args)
	                {
		                debugger = new SpeechSynthesizer();
                        debegger.Speak(5.ToString());
                    }
                }
            ").Result;*/
            /*debugger.Speak("Выполняю скрипты " + s);*/
            /*foreach (Dictionary<String, Object> asset in assets.Where<Dictionary<String, Object>>((Dictionary<String, Object> asset) => asset["type"] == "script"))
            {
                debugger.Speak("Выполняю скрипты " + asset["name"]);
            }*/
            /*foreach (Dictionary<String, Object> asset in assets.Where<Dictionary<String, Object>>((Dictionary<String, Object> asset) => asset["type"] == "script"))
            {
                *//*debugger.Speak("Выполняю скрипты " + File.ReadAllText(@"C:\csScripts\" + asset["name"].ToString() + ".cs"));*//*
                int s = CSharpScript.EvaluateAsync<int>(File.ReadAllText(@"C:\csScripts\" + asset["name"].ToString() + ".cs")).Result;
                debugger.Speak("Выполняю скрипты " + s);
            }*/
            foreach(Dictionary<String, Object> gameObject in gameObjects)
            {
                foreach (Dictionary<String, Object> component in ((List<Dictionary<String, Object>>)(gameObject["components"])))
                {
                    try {
                        /*int s = CSharpScript.EvaluateAsync<int>(File.ReadAllText(@"C:\wpf_projects\GameEngine\GameEngine\Assets\" + component["name"].ToString() + ".cs")).Result;*/
                        int s = CSharpScript.EvaluateAsync<int>(File.ReadAllText(@"C:\csScripts\" + component["name"].ToString() + ".cs")).Result;
                        debugger.Speak("Выполняю скрипты " + component["name"].ToString() + " " + s);
                        /*debugger.Speak("Выполняю скрипты " + component["name"].ToString() + " " + s + " " + File.ReadAllText(@"C:\wpf_projects\GameEngine\GameEngine\Assets\" + component["name"].ToString() + ".cs"));*/
                    } catch
                    {
                        debugger.Speak("Ошибка чтения скрипта " + component["name"].ToString());
                    }
                }
            }
        }

        private void PauseHandler(object sender, RoutedEventArgs e)
        {

        }

        private void SeekHandler(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleGraphicModeHandler(object sender, RoutedEventArgs e)
        {
            graphicMode = !graphicMode;
            if (!graphicMode)
            {
                graphicModeToggler.Content = "2D";
                
            } else
            {
                graphicModeToggler.Content = "3D";
            }
        }
    }

}
