using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameEngine.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для AssetPickerDialog.xaml
    /// </summary>
    public partial class AssetPickerDialog : Window
    {
        
        public List<Dictionary<String, Object>> localAssets;
        public string assetsType;
        public SpeechSynthesizer debugger;

        public AssetPickerDialog(List<Dictionary<String, Object>> localAssets, string assetsType)
        {
            InitializeComponent();
            
            debugger = new SpeechSynthesizer();

            this.localAssets = localAssets;
            this.assetsType = assetsType;
            if (localAssets.Where(localAsset => ((Dictionary<String, Object>)(localAsset))["type"].ToString() == assetsType).Count() >= 1) {
                foreach (Dictionary<String, Object> asset in localAssets.Where(localAsset => ((Dictionary<String, Object>)(localAsset))["type"].ToString() == assetsType))
                {

                    StackPanel localAsset = new StackPanel();
                    localAsset.Height = 100;
                    localAsset.Width = 100;
                    localAsset.Margin = new Thickness(15, 15, 15, 15);
                    localAsset.Background = System.Windows.Media.Brushes.LightGray;
                    TextBlock localAssetIcon = new TextBlock();
                    if (assetsType == "audio")
                    {
                        localAssetIcon.Text = "🎵";
                    }
                    else if (assetsType == "script")
                    {
                        localAssetIcon.Text = "🗎";
                    }
                    else if (assetsType == "image")
                    {
                        localAssetIcon.Text = "🖼";
                    }
                    else
                    {
                        localAssetIcon.Text = "🖿";
                    }
                    localAssetIcon.Margin = new Thickness(5, 5, 5, 5);
                    localAssetIcon.HorizontalAlignment = HorizontalAlignment.Center;
                    localAssetIcon.FontSize = 36;
                    localAsset.Children.Add(localAssetIcon);
                    TextBlock localAssetLabel = new TextBlock();
                    localAssetLabel.Text = asset["name"].ToString();
                    localAssetLabel.Margin = new Thickness(5, 5, 5, 5);
                    localAssetLabel.HorizontalAlignment = HorizontalAlignment.Center;
                    localAsset.MouseLeftButtonUp += PickAssetHandler;
                    localAsset.Children.Add(localAssetLabel);
                    assets.Children.Add(localAsset);
                }
            } else if (localAssets.Count <= 0)
            {
                TextBlock notFoundAssets = new TextBlock();
                notFoundAssets.Text = "Не найдено ресурсов";
                notFoundAssets.Margin = new Thickness(15, 15, 15, 15);
                notFoundAssets.HorizontalAlignment = HorizontalAlignment.Center;
                assets.Children.Add(notFoundAssets);
            }

        }

        private void PickAssetHandler(object sender, RoutedEventArgs e)
        {
            StackPanel pickedAsset = ((StackPanel)(sender));
            // string pickedAssetName = ((TextBlock)(pickedAsset.Children[1])).Text;
            // assetPicker.DataContext = pickedAssetName;
            // debugger.Speak(pickedAssetName);

            // string pickedAssetPath = ((Dictionary<String, Object>)(localAssets[assets.Children.IndexOf(pickedAsset)]["data"]))["path"].ToString();
            // string pickedAssetPath = ((Dictionary<String, Object>)(((List<Dictionary<String, Object>>)(localAssets.Where(localAsset => ((Dictionary<String, Object>)(localAsset))["type"].ToString() == assetsType)))[assets.Children.IndexOf(pickedAsset)]["data"]))["path"].ToString();
            List<Dictionary<String, Object>> neededAssets = new List<Dictionary<String, Object>>();
            foreach (Dictionary<String, Object> neededAsset in localAssets)
            {
                if (neededAsset["type"].ToString() == assetsType) {
                    neededAssets.Add(neededAsset);
                }
            }
            string pickedAssetPath = ((Dictionary<String, Object>)(neededAssets[assets.Children.IndexOf(pickedAsset)]["data"]))["path"].ToString();
            // debugger.Speak(pickedAssetPath);
            assetPicker.DataContext = pickedAssetPath; 
            this.Close();
         }

    }
}
