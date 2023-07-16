using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderComments
{
    public partial class Form1 : Form
    {
        string folder = null;
        DirectoryInfo info;

        public Form1()
        {
            InitializeComponent();

            cbReg.Checked = FolderComments.ContextMenu.Query();
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length == 1)
            {
                // 直接运行
                dt1.Enabled = dt2.Enabled = dt3.Enabled = false;
                保存.Enabled = 取消.Enabled = 清空.Enabled = false;
                cbPath.Enabled = false;
            }
            else
            {
                // 编辑文件夹备注
                folder = args[1];
                text.Text = FolderInfo.ReadComment(folder).Replace("\t", "\r\n"); // 获取备注
                info = new DirectoryInfo(folder); // 获取文件夹信息
                dt1.Value = info.CreationTime;
                dt2.Value = info.LastWriteTime;
                dt3.Value = dt2.Value; // 只要访问该文件，访问日期便被自动修改，故将访问日期默认设置为修改日期
                cbPath.Checked = UserPath.Update(folder);
            }
        }

        private void 保存_Click(object sender = null, EventArgs e = null)
        {
            if (folder != null)
            {
                string comment = text.Text.Replace("\r\n", "\t").Trim();
                if (comment == "") comment = null;
                FolderInfo.UpdateComment(folder, comment);
                info.CreationTime = dt1.Value;
                info.LastWriteTime = dt2.Value;
                info.LastAccessTime = dt3.Value;
                Application.Exit();
            }
        }

        private void 取消_Click(object sender = null, EventArgs e = null)
        {
            Application.Exit();
        }

        private void 清空_Click(object sender, EventArgs e)
        {
            text.Text = "";
        }

        private void text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && Control.ModifierKeys == Keys.None)
            {
                e.Handled = true; // 屏蔽直接按下的回车键
            }
        }

        private void text_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                取消_Click();
            }
            else if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.None)
            {
                保存_Click();
            }
        }

        private void cbReg_CheckedChanged(object sender, EventArgs e)
        {
            if (cbReg.Checked)
            {
                FolderComments.ContextMenu.Register();
            }
            else
            {
                FolderComments.ContextMenu.UnRegister();
            }
        }

        private void cbPath_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPath.Focused) UserPath.Update(folder, true);
        }
    }
}
