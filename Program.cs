using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace FolderComments
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    /// <summary>
    /// 注册表右键菜单管理
    /// </summary>
    static class ContextMenu
    {
        static readonly string root = "SOFTWARE\\Classes\\Folder";

        public static bool Query()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(root + "\\shell\\FolderComments"))
            {
                return key?.SubKeyCount > 0;
            }
        }

        public static void Register()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(root + "\\shell\\FolderComments", true))
            {
                key.SetValue(null, "文件夹备注(&X)");
            }
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(root + "\\shell\\FolderComments\\command", true))
            {
                key.SetValue(null, string.Format("\"{0}\" \"%1\"", Application.ExecutablePath));
            }
        }

        public static void UnRegister()
        {
            Registry.CurrentUser.DeleteSubKeyTree(root + "\\shell\\FolderComments", false);
            using (RegistryKey shellKey = Registry.CurrentUser.OpenSubKey(root + "\\shell", true))
            {
                if (shellKey?.SubKeyCount > 0) return;
            }
            Registry.CurrentUser.DeleteSubKey(root + "\\shell", false);
            using (RegistryKey rootKey = Registry.CurrentUser.OpenSubKey(root))
            {
                if (rootKey?.SubKeyCount > 0) return;
            }
            Registry.CurrentUser.DeleteSubKey(root, false);
        }
    }

    /// <summary>
    /// desktop.ini管理
    /// </summary>
    static class FolderInfo
    {
        static readonly int BUFSIZE = 8192;

        [DllImport("kernel32", CharSet = CharSet.Unicode)] static extern int GetPrivateProfileString(string lpSectionName, string lpKeyName, string lpDefaultValue, StringBuilder lpReturnedString, int nSize, string lpFilePath);
        [DllImport("kernel32", CharSet = CharSet.Unicode)] static extern int WritePrivateProfileString(string lpSectionpName, string lpKeyName, string lpValue, string lpFilePath);
        [DllImport("shell32", CharSet = CharSet.Unicode)] static extern UInt32 SHGetSetFolderCustomSettings(ref SHFOLDERCUSTOMSETTINGS pfcs, string pszPath, UInt32 dwReadWrite);
        [StructLayout(LayoutKind.Sequential)]
        struct SHFOLDERCUSTOMSETTINGS
        {
            public uint dwSize;
            public uint dwMask;
            public IntPtr pvid;
            [MarshalAs(UnmanagedType.LPWStr)] public string pszWebViewTemplate;
            public uint cchWebViewTemplate;
            [MarshalAs(UnmanagedType.LPWStr)] public string pszWebViewTemplateVersion;
            [MarshalAs(UnmanagedType.LPWStr)] public string pszInfoTip;
            public uint cchInfoTip;
            public IntPtr pclsid;
            public uint dwFlags;
            [MarshalAs(UnmanagedType.LPWStr)] public string pszIconFile;
            public uint cchIconFile;
            public int iIconIndex;
            [MarshalAs(UnmanagedType.LPWStr)] public string pszLogo;
            public uint cchLogo;
        }

        public static string ReadComment(string folder)
        {
            StringBuilder builder = new StringBuilder(BUFSIZE);
            GetPrivateProfileString(".ShellClassInfo", "InfoTip", "", builder, BUFSIZE, folder + "\\desktop.ini");
            return builder.ToString();
        }

        public static void UpdateComment(string folder, string comment)
        {
            const uint FCSM_ICONFILE = 0x00000010, FCS_READ = 0x00000001, FCS_FORCEWRITE = 0x00000002;
            // 写入或删除文件夹备注
            WritePrivateProfileString(".ShellClassInfo", "InfoTip", comment, folder + "\\desktop.ini");
            // 刷新图标
            SHFOLDERCUSTOMSETTINGS fcs = new SHFOLDERCUSTOMSETTINGS();
            fcs.dwSize = (uint)Marshal.SizeOf(fcs);
            fcs.dwMask = FCSM_ICONFILE;
            fcs.pszIconFile = new string(' ', BUFSIZE); //new StringBuilder(BUFSIZE);
            fcs.cchIconFile = (uint)BUFSIZE;
            if (SHGetSetFolderCustomSettings(ref fcs, folder, FCS_READ) != 0)
            {
                fcs.pszIconFile = "C:\\Windows\\system32\\SHELL32.dll"; // new StringBuilder("C:\\Windows\\system32\\SHELL32.dll", BUFSIZE);
                fcs.iIconIndex = 4;
            }
            fcs.dwMask = FCSM_ICONFILE;
            SHGetSetFolderCustomSettings(ref fcs, folder, FCS_FORCEWRITE);
        }
    }

    /// <summary>
    /// 用户PATH环境变量管理
    /// </summary>
    static class UserPath
    {
        static readonly uint HWND_BROADCAST = 0xffff;
        static readonly uint WM_SETTINGCHANGE = 0x001a;
        static readonly uint SMTO_ABORTIFHUNG = 0x0002;

        // https://learn.microsoft.com/zh-cn/windows/win32/winmsg/wm-settingchange
        // https://learn.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-sendmessagetimeouta
        [DllImport("user32", CharSet = CharSet.Unicode)] static extern int SendMessageTimeout(uint hWnd, uint Msg, IntPtr wParam, string lParam, uint fuFlags, uint uTimeout, IntPtr lpdwResult);

        public static bool Update(string test, bool toggle = false)
        {
            string path;
            bool contains;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Environment"))
            {
                path = key.GetValue("Path", "") as string + ';';
                contains = path.Contains(test);
            }
            if (toggle)
            {
                if (contains)
                {
                    path = path.Replace(test + ';', "");
                }
                else
                {
                    path = test + ';' + path;
                }
                path = path.Substring(0, path.Length - 1);
                path = path.Replace(";;", ";");
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Environment", true))
                {
                    key.SetValue("Path", path);
                }
            }
            SendMessageTimeout(HWND_BROADCAST, WM_SETTINGCHANGE, IntPtr.Zero, "Environment", SMTO_ABORTIFHUNG, 1000, IntPtr.Zero);
            return contains;
        }
    }

}
