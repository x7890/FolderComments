using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderComments
{
    public class RegPath
    {
        // HKCR
        public static readonly string[] itemEdit = new string[]{
            @"Folder\shell\FolderComments_Edit", "编辑备注(&X)"};
        public static readonly string[] itemEditCmd = new string[]{
            @"Folder\shell\FolderComments_Edit\command", "\"{0}\" \"%1\""};

        public static readonly string[] backEdit = new string[]{
            @"Directory\Background\shell\FolderComments_Edit", "编辑备注(&X)"};
        public static readonly string[] backEditCmd = new string[]{
            @"Directory\Background\shell\FolderComments_Edit\command", "\"{0}\" \"%v\""};

    }

}
