using Microsoft.Win32;
using System;
using System.Windows;

namespace FolderComments
{
    /// <summary>
    /// SettingsWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();

            cbAddItemEditReg.IsChecked =
                Registry.ClassesRoot.OpenSubKey(RegPath.itemEdit[0])?.GetValue(null, null) != null;
            cbAddBackEditReg.IsChecked =
                Registry.ClassesRoot.OpenSubKey(RegPath.backEdit[0])?.GetValue(null, null) != null;

        }

        private void 关闭_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private bool modifyReg(bool state, string[] father, string[] child)
        {   // 添加注册表或删除注册表，返回执行后的状态
            if (state)
            {
                try
                {
                    Registry.ClassesRoot.CreateSubKey(father[0], true)
                        .SetValue(null, father[1]);
                    Registry.ClassesRoot.CreateSubKey(child[0], true)
                       .SetValue(null, String.Format(child[1], Application.ResourceAssembly.Location));
                    return state;
                }
                catch
                {
                    MessageBox.Show("添加注册表项失败，请以管理员权限运行");
                    return !state;
                }
            }
            else
            {
                try
                {
                    Registry.ClassesRoot.DeleteSubKeyTree(father[0], true);
                    return state;
                }
                catch
                {
                    MessageBox.Show("删除注册表项失败，请以管理员权限运行");
                    return !state;
                }
            }
        }

        private void cbAddItemEditReg_Click(object sender, RoutedEventArgs e)
        {
            cbAddItemEditReg.IsChecked =
                modifyReg(cbAddItemEditReg.IsChecked == true, RegPath.itemEdit, RegPath.itemEditCmd);
        }

        private void cbAddBackEditReg_Click(object sender, RoutedEventArgs e)
        {
            cbAddBackEditReg.IsChecked =
                modifyReg(cbAddBackEditReg.IsChecked == true, RegPath.backEdit, RegPath.backEditCmd);
        }

    }
}
