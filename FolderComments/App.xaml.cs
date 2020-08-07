using System;
using System.Windows;

namespace FolderComments
{

    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        public void Start(object sender, StartupEventArgs e)
        {
            
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length == 1)
            {
                // 设置
                new SettingsWindow().Show();
            }
            else if (args.Length == 2)
            {
                // 编辑备注
                new MainWindow(args[1]).Show();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}
