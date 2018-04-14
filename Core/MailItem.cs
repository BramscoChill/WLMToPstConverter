namespace WLMToPst
{
    public class MailItem
    {
        public MailItem(string fullPath)
        {
            FullPath = fullPath;
        }

        public string FullPath { get; set; } //folder name
    }
}