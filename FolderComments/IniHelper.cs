using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FolderComments
{
    class IniHelper
    {
        // 参考来源：
        // https://www.cnblogs.com/xiesong/p/10320893.html
        // https://docs.microsoft.com/zh-cn/dotnet/framework/interop/marshaling-strings

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(
            string lpSectionName, // 节
            string lpKeyName, // 键
            string lpDefaultValue, // 缺省返回值
            StringBuilder lpReturnedString, int nSize, // 返回值
            string lpFilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int WritePrivateProfileString(
            string lpSectionpName, // 节
            string lpKeyName, // 键
            string lpValue, // 值，null表示删除，和空不同
            string lpFilePath);

        public static string Read(string section, string key, string defaultValue, string filePath)
        {
            const int BUFSIZE = 4096;
            StringBuilder builder = new StringBuilder(BUFSIZE);
            GetPrivateProfileString(section, key, defaultValue, builder, BUFSIZE, filePath);
            return builder.ToString();
        }

        public static int Write(string section, string key, string value, string filePath)
        {
            return WritePrivateProfileString(section, key, value, filePath);
        }
    }
}
