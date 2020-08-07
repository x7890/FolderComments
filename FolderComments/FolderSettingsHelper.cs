using System;
using System.Runtime.InteropServices;

namespace FolderComments
{
    class FolderSettingsHelper
    {
        // 参考来源：
        // https://stackoverflow.com/questions/9277492/folder-icon-change
        // https://docs.microsoft.com/en-us/windows/win32/api/shlobj_core/ns-shlobj_core-shfoldercustomsettings
        // https://www.cnblogs.com/xingboy/p/9779284.html
        // https://zhuanlan.zhihu.com/p/29161824
        // https://docs.microsoft.com/zh-cn/dotnet/framework/interop/default-marshaling-for-strings
        // https://docs.microsoft.com/zh-cn/dotnet/framework/interop/marshaling-classes-structures-and-unions#outarrayofstructs-sample

        [DllImport("shell32", CharSet = CharSet.Unicode)]
        static extern UInt32 SHGetSetFolderCustomSettings(
            ref SHFOLDERCUSTOMSETTINGS pfcs, string pszPath, UInt32 dwReadWrite);

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFOLDERCUSTOMSETTINGS
        {
            public UInt32 dwSize;
            public UInt32 dwMask;
            public IntPtr pvid;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszWebViewTemplate;
            public UInt32 cchWebViewTemplate;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszWebViewTemplateVersion;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszInfoTip;
            public UInt32 cchInfoTip;
            public IntPtr pclsid;
            public UInt32 dwFlags;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszIconFile;
            public UInt32 cchIconFile;
            public int iIconIndex;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszLogo;
            public UInt32 cchLogo;
        }


        // 刷新图标
        public static void RefresSettings(string folderPath)
        {
            const int BUFSIZE = 4096;
            SHFOLDERCUSTOMSETTINGS fcs = new SHFOLDERCUSTOMSETTINGS();
            //fcs.dwFlags = 0;
            fcs.dwSize = (uint)Marshal.SizeOf(fcs);
            fcs.dwMask = 0x00000010; // FCSM_ICONFILE
            fcs.pszIconFile = new String(' ', BUFSIZE);
            fcs.cchIconFile = BUFSIZE;

            if (0 != SHGetSetFolderCustomSettings(ref fcs, folderPath, 0x00000001)) // FCS_READ
            {
                fcs.pszIconFile = @"C:\Windows\system32\SHELL32.dll";
                fcs.iIconIndex = 4;
            }

            fcs.dwMask = 0x00000010; // FCSM_ICONFILE
            SHGetSetFolderCustomSettings(ref fcs, folderPath, 0x00000002); // FCS_FORCEWRITE

        }
    }
}
