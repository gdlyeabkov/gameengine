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
using System.Windows.Shapes;

namespace GameEngine.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для Console.xaml
    /// </summary>
    public partial class Console : Window
    {

        public List<Dictionary<String, Object>> localLogs;

        public Console(List<Dictionary<String, Object>> localLogs)
        {
            InitializeComponent();

            this.localLogs = localLogs;
            foreach (Dictionary<String, Object> log in localLogs)
            {
                StackPanel localLog = new StackPanel();
                TextBlock localLogType = new TextBlock();
                localLogType.Text = log["message"].ToString();
                localLogType.FontSize = 18;
                localLogType.Margin = new Thickness(15, 5, 15, 5);
                TextBlock localLogMessage = new TextBlock();
                localLogType.Margin = new Thickness(15, 0, 15, 0);
                if (log["type"].ToString() == "warning")
                {
                    localLogMessage.Text = "⚠";
                } else
                {
                    localLogMessage.Text = "⚠";
                }
                localLog.Children.Add(localLogType);
                localLog.Children.Add(localLogMessage);
                logs.Children.Add(localLog);
            }

        }
    }
}
