using System.Windows;

namespace FolderComments
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        string folderPath;
        string iniPath;


        public MainWindow(string path)
        {
            InitializeComponent();
            folderPath = path;
            iniPath = folderPath + ".\\desktop.ini";

            string comment = IniHelper.Read(".ShellClassInfo", "InfoTip", "", iniPath);
            textComment.Text = comment;
            textComment.Focus();
            textComment.SelectAll();
        }

        private void 清空_Click(object sender, RoutedEventArgs e)
        {
            textComment.Text = "";
        }
        private void 确定_Click(object sender, RoutedEventArgs e)
        {
            // 获取注释
            string comment = textComment.Text.Replace('\n', ' ').Replace('\r', ' ').Trim();
            if (comment.Length == 0)
            {
                IniHelper.Write(".ShellClassInfo", "InfoTip", null, iniPath); // 删除
            }
            else
            {
                IniHelper.Write(".ShellClassInfo", "InfoTip", comment, iniPath);
            }

            // 刷新图标
            FolderSettingsHelper.RefresSettings(folderPath);

            Application.Current.Shutdown();
        }

        private void 取消_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
