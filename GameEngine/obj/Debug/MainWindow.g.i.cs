// Updated by XamlIntelliSenseFileGenerator 17.12.2021 16:45:48
#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4EE85F36271F8EA499BF840A90FD7FEE771EC8549DA8CA8CFC35F664465DDDAD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using GameEngine;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace GameEngine
{


    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 10 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement soundTracker;

#line default
#line hidden


#line 11 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel menuString;

#line default
#line hidden


#line 29 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel hierarchy;

#line default
#line hidden


#line 35 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel hierarchyGameObjects;

#line default
#line hidden


#line 62 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel inspector;

#line default
#line hidden


#line 63 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel components;

#line default
#line hidden


#line 96 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox selectedAddedComponent;

#line default
#line hidden


#line 103 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addComponentBtn;

#line default
#line hidden


#line 106 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel project;

#line default
#line hidden


#line 113 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel projectAssets;

#line default
#line hidden


#line 138 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel scene;

#line default
#line hidden


#line 144 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button graphicModeToggler;

#line default
#line hidden


#line 147 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Viewport3D space;

#line default
#line hidden


#line 150 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Media3D.PerspectiveCamera mainCamera;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GameEngine;component/mainwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.app = ((GameEngine.MainWindow)(target));

#line 8 "..\..\MainWindow.xaml"
                    this.app.KeyUp += new System.Windows.Input.KeyEventHandler(this.GlobalHotKeysHandler);

#line default
#line hidden

#line 8 "..\..\MainWindow.xaml"
                    this.app.MouseMove += new System.Windows.Input.MouseEventHandler(this.GlobalMouseMoveHandler);

#line default
#line hidden

#line 8 "..\..\MainWindow.xaml"
                    this.app.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.GlobalMouseDownHandler);

#line default
#line hidden

#line 8 "..\..\MainWindow.xaml"
                    this.app.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GlobalMouseUpHandler);

#line default
#line hidden
                    return;
                case 2:
                    this.soundTracker = ((System.Windows.Controls.MediaElement)(target));
                    return;
                case 3:
                    this.menuString = ((System.Windows.Controls.StackPanel)(target));
                    return;
                case 4:

#line 14 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ImportAssetHanler);

#line default
#line hidden
                    return;
                case 5:

#line 17 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ImportAssetHanler);

#line default
#line hidden
                    return;
                case 6:

#line 20 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ImportAssetHanler);

#line default
#line hidden
                    return;
                case 7:

#line 23 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ImportAssetHanler);

#line default
#line hidden
                    return;
                case 8:

#line 24 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenConsoleHanler);

#line default
#line hidden
                    return;
                case 9:
                    this.hierarchy = ((System.Windows.Controls.StackPanel)(target));
                    return;
                case 10:

#line 32 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateGameObjectHandler);

#line default
#line hidden
                    return;
                case 11:
                    this.hierarchyGameObjects = ((System.Windows.Controls.StackPanel)(target));
                    return;
                case 12:
                    this.inspector = ((System.Windows.Controls.StackPanel)(target));
                    return;
                case 13:
                    this.components = ((System.Windows.Controls.StackPanel)(target));
                    return;
                case 14:
                    this.selectedAddedComponent = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 15:
                    this.addComponentBtn = ((System.Windows.Controls.Button)(target));

#line 103 "..\..\MainWindow.xaml"
                    this.addComponentBtn.Click += new System.Windows.RoutedEventHandler(this.AddComponentHandler);

#line default
#line hidden
                    return;
                case 16:
                    this.project = ((System.Windows.Controls.StackPanel)(target));
                    return;
                case 17:

#line 109 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ImportAssetHanler);

#line default
#line hidden
                    return;
                case 18:

#line 110 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateScriptAssetHanler);

#line default
#line hidden
                    return;
                case 19:
                    this.projectAssets = ((System.Windows.Controls.WrapPanel)(target));
                    return;
                case 20:
                    this.scene = ((System.Windows.Controls.StackPanel)(target));
                    return;
                case 21:

#line 141 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PlayHandler);

#line default
#line hidden
                    return;
                case 22:

#line 142 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PauseHandler);

#line default
#line hidden
                    return;
                case 23:

#line 143 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SeekHandler);

#line default
#line hidden
                    return;
                case 24:
                    this.graphicModeToggler = ((System.Windows.Controls.Button)(target));

#line 144 "..\..\MainWindow.xaml"
                    this.graphicModeToggler.Click += new System.Windows.RoutedEventHandler(this.ToggleGraphicModeHandler);

#line default
#line hidden
                    return;
                case 25:
                    this.space = ((System.Windows.Controls.Viewport3D)(target));
                    return;
                case 26:
                    this.mainCamera = ((System.Windows.Media.Media3D.PerspectiveCamera)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Window app;
    }
}

