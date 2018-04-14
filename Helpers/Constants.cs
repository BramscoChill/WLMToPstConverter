namespace WLMToPst
{
    public class Constants
    {
        public const string POSSIBLE_INBOX_FILENAME_REGEX = "inbox";
        public const string POSSIBLE_OUTBOX_FILENAME_REGEX = "outbox";
        public const string POSSIBLE_SEND_FILENAME_REGEX = "sen(t|d)[\\s]{0,10}item(s){0,1}";
        public const string POSSIBLE_DELETED_FILENAME_REGEX = "delete(t|d)[\\s]{0,10}item(s){0,1}";
        public const string POSSIBLE_JUNK_FILENAME_REGEX = "junk[\\s]{0,10}(e\\-mail|email)";
    }
}