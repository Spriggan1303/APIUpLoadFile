using Microsoft.SharePoint.Client;
using NLog;
using System;
using System.IO;
using Microsoft.SharePoint;
using System.Security;

namespace UpLoadFileToSharePoint.Helper
{
	public class UpLoadFileToSharepointHelper
	{
		public static string UploadFileToSharePoint(string SiteUrl, string DocLibrary, string ClientSubFolder,
           string  FileName, string Login, string Password)
        {
           Logger logger = LogManager.GetLogger("fileLogger");
            try
            {
                #region ConnectToSharePoint
                var securePassword = new SecureString();
                foreach (char c in Password)
                { securePassword.AppendChar(c); }
                logger.Info("site url"+ SiteUrl);
                logger.Info("Login "+Login);
                logger.Info("securePassword: "+securePassword.ToString());
                logger.Info("securePassword: "+securePassword.Length);
                var onlineCredentials = new SharePointOnlineCredentials(Login, securePassword);
                logger.Info("Pass ");
                #endregion

                #region Insert the data
                using (ClientContext CContext = new ClientContext(SiteUrl))
                {

                    CContext.Credentials = onlineCredentials;
                    Web web = CContext.Web;
                    FileCreationInformation newFile = new FileCreationInformation();
                    byte[] FileContent = System.IO.File.ReadAllBytes(FileName);
                    newFile.ContentStream = new MemoryStream(FileContent);
                    newFile.Url = Path.GetFileName(FileName);
                    List DocumentLibrary = web.Lists.GetByTitle(DocLibrary);
                    //Folder folder = DocumentLibrary.RootFolder.Folders.GetByUrl(ClientSubFolder);
                    Folder Clientfolder = DocumentLibrary.RootFolder.Folders.Add(ClientSubFolder);
                    Clientfolder.Update();
                    Microsoft.SharePoint.Client.File uploadFile = Clientfolder.Files.Add(newFile);

                    CContext.Load(DocumentLibrary);
                    CContext.Load(uploadFile);
                    CContext.ExecuteQuery();
                }
                    #endregion
                    return "";
            }
            catch (Exception exp)
            {
                return exp.Message.ToString();
            }
        
        }

     
    }
}