using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Redemption;
using WLMToPst.Redemption;

namespace WLMToPst
{
    public delegate void UpdateConvertionThreadProgressHandlerDelegate(float i, float total);

    public class PSTGenerator
    {
        public UpdateConvertionThreadProgressHandlerDelegate UpdateConvertionThreadProgressHandler;

        private RDOSession session;

        public PSTGenerator()
        {
            
        }

        public void CreatePSTFromWindowsLiveMailFolder(string outputPstFullPath, string windowsLiveMailDirectory)
        {
            //http://www.dimastr.com/redemption/RDOMail.htm
            if (File.Exists(outputPstFullPath) == false && Directory.Exists(windowsLiveMailDirectory))
            {
                session = RedemptionLoader.new_RDOSession();
                session.LogonPstStore(outputPstFullPath);

                FolderMailItem rootFolderMap = GetFoldersFromWindowsLiveMailLocation(windowsLiveMailDirectory);
                if (rootFolderMap != null && rootFolderMap.Folders != null && rootFolderMap.Folders.Any())
                {
                    //add files to root folder
                    AddFilesToFolder(rootFolderMap.Files, session.Stores.DefaultStore.IPMRootFolder);

                    //folders in root folder
                    foreach (FolderMailItem rootFolderMailItem in rootFolderMap.Folders)
                    {
                        AddMailsToFolder(rootFolderMailItem);
                    }
                }
                session.Logoff();
            }
            session = null;
        }
        //suppose to have a folder structure like:
        //Deleted Items
        //Drafts
        //Inbox
        //Junk E-mail
        //Sent Items
        //SPAMfighter
        //the string[] are the eml files
        private FolderMailItem GetFoldersFromWindowsLiveMailLocation(string baseFolderLocation)
        {
            FolderMailItem result = null;
            if (Directory.Exists(baseFolderLocation))
            {
                result = new FolderMailItem();
                string fullPath = Path.GetFullPath(baseFolderLocation).TrimEnd(Path.DirectorySeparatorChar);
                string directoryName = fullPath.Split(Path.DirectorySeparatorChar).Last();
                result.Name = directoryName;
                result.Files = Directory.GetFiles(fullPath, "*.eml").Select(mailItemFullPath => new MailItem(mailItemFullPath)).ToList();
                //also subdirectories in directory
                foreach (string directory in Directory.GetDirectories(baseFolderLocation))
                {
                    var folderItem = GetFoldersFromWindowsLiveMailLocation(directory);
                    if (folderItem != null)
                    {
                        result.Folders.Add(folderItem);
                    }
                }
            }
            return result;
        }
        private void AddMailsToFolder(FolderMailItem folderMailItem, RDOFolder parent = null)
        {
            RDOFolder folder = GetFolder(folderMailItem.Name, parent);

            AddFilesToFolder(folderMailItem.Files, folder);
            
            if (folderMailItem.Folders != null && folderMailItem.Folders.Any())
            {
                foreach (FolderMailItem nestedFolderMailItem in folderMailItem.Folders)
                {
                    AddMailsToFolder(nestedFolderMailItem, folder);
                }
            }
        }

        private void AddFilesToFolder(List<MailItem> files, RDOFolder folder)
        {
            if (files != null && files.Any())
            {
                foreach (MailItem mailItem in files)
                {
                    RDOMail mail = folder.Items.Add("IPM.Mail");
                    mail.Sent = true;
                    mail.Import(mailItem.FullPath, 1024);
                    // folder.Items.Add(mail);
                    mail.Save();
                }
            }
        }

        private RDOFolder GetFolder(string folderName, RDOFolder parent = null)
        {
            //when the parent is null, we assume its about an folder in the root folder
            RDOFolder folder = null;
            if (parent == null)
            {
                if (Regex.IsMatch(folderName, Constants.POSSIBLE_INBOX_FILENAME_REGEX, RegexOptions.IgnoreCase))
                {
                    folder = GetDefaultFolder(rdoDefaultFolders.olFolderInbox, folderName);
                }
                else if (Regex.IsMatch(folderName, Constants.POSSIBLE_OUTBOX_FILENAME_REGEX, RegexOptions.IgnoreCase))
                {
                    folder = GetDefaultFolder(rdoDefaultFolders.olFolderOutbox, folderName);
                }
                else if (Regex.IsMatch(folderName, Constants.POSSIBLE_SEND_FILENAME_REGEX, RegexOptions.IgnoreCase))
                {
                    folder = GetDefaultFolder(rdoDefaultFolders.olFolderSentMail, folderName);
                }
                else if (Regex.IsMatch(folderName, Constants.POSSIBLE_DELETED_FILENAME_REGEX, RegexOptions.IgnoreCase))
                {
                    folder = GetDefaultFolder(rdoDefaultFolders.olFolderDeletedItems, folderName);
                }
                else if (Regex.IsMatch(folderName, Constants.POSSIBLE_JUNK_FILENAME_REGEX, RegexOptions.IgnoreCase))
                {
                    folder = GetDefaultFolder(rdoDefaultFolders.olFolderJunk, folderName);
                }
            }
            
            //an nested folder or an non default folder in the root
            if(folder == null)
            {
                RDOFolder folderToSearchIn = parent ?? session.Stores.DefaultStore.IPMRootFolder;
                //searches the non default folders for that name
                foreach (RDOFolder currentFolder in folderToSearchIn.Folders)
                {
                    if (currentFolder.Name.Equals(folderName, StringComparison.OrdinalIgnoreCase))
                    {
                        folder = currentFolder;
                        break;
                    }
                }
                //if the folder not exists, creates it
                if (folder == null)
                {
                    folder = folderToSearchIn.Folders.Add(folderName);
                    folder.Save();
                }
            }
            return folder;
        }

        private RDOFolder GetDefaultFolder(rdoDefaultFolders type, string name)
        {
            RDOFolder folder = null;
            try
            {
                folder = session.GetDefaultFolder(type);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                //if(e.Message.ToUpper().Contains("MAPI_E_NOT_FOUND"))
                folder = session.Stores.DefaultStore.IPMRootFolder.Folders.Add(name, type);
                folder.Save();
                
            }
            return folder;
        }

        private void UpdateProgress(float progress)
        {
            if (UpdateConvertionThreadProgressHandler != null)
            {
                UpdateConvertionThreadProgressHandler.Invoke(progress, 100);
            }
        }
    }
}