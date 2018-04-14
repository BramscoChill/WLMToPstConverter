using System.Collections.Generic;

namespace WLMToPst
{
    public class FolderMailItem
    {
        public FolderMailItem()
        {
            
        }

        public FolderMailItem(string name, List<FolderMailItem> folders, List<MailItem> files)
        {
            Name = name;
            Folders = folders;
            Files = files;
        }

        public string Name { get; set; } //folder name 
        private List<FolderMailItem> _folders;

        public List<FolderMailItem> Folders
        {
            get
            {
                if (_folders == null)
                {
                    _folders = new List<FolderMailItem>();
                }
                return _folders;
            }
            set { if(value != null) {_folders = value;} }
        }

        public List<MailItem> Files { get; set; }
    }
}