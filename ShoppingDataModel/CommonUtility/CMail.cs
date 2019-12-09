using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDataModel.CommonUtility
{
    public class CMail
    {
        private const string MAILLOGNAME = "SiteAdmin\\Mail.txt";
        // string strServerName = HttpContext.Current.Request.ServerVariables.GetValues("SERVER_NAME")[0].ToString();


        public CMail()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public struct MAIL_DATA
        {
            public bool bHTMLFormat;
            public int iPriority;

            public string strTo;
            public string strFrom;
            public string strSubject;
            public string strMailBody;

            public string strUserFullName;
            public string strComments;

        }

        public static int SendSystemGeneratedMail(string strMailTo, string strSubject, string strBody, string strDisplayName, bool bIsBodyHTML)
        {
            MailMessage oMailMessage;
            // Check if To and From Fields have been provided
            try
            {
                if (strMailTo == "")
                {
                    return (int)CCommon.StatusCode.Fail;
                }

                oMailMessage = new MailMessage(new MailAddress(ConfigurationManager.AppSettings["from"].ToString(), ConfigurationManager.AppSettings["fromdisplayname"]), new MailAddress(strMailTo));

                oMailMessage.Priority = MailPriority.Normal;
                oMailMessage.Subject = strSubject;
                oMailMessage.Body = strBody;
                oMailMessage.IsBodyHtml = bIsBodyHTML;
                oMailMessage.ReplyTo = new MailAddress(ConfigurationManager.AppSettings["replyto"].ToString());
                string[] strBCCEmails = ConfigurationManager.AppSettings["bccaddress"].ToString().Split(CCommon.arrCategorySplitChars);
                foreach (string strMail in strBCCEmails)
                {
                    oMailMessage.Bcc.Add(strMail);
                }
                //oMailMessage.Headers.Add("Disposition-Notification-To", "catchall@rdassociates.co.in");
                oMailMessage.Headers.Add("Company", ConfigurationManager.AppSettings["companyname"]);
                oMailMessage.Priority = MailPriority.Normal;
                oMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                oMailMessage.DeliveryNotificationOptions = System.Net.Mail.DeliveryNotificationOptions.OnFailure;


                SmtpClient oClient = new SmtpClient(ConfigurationManager.AppSettings["smtp"]);
                oClient.UseDefaultCredentials = false;
                oClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
                oClient.Port = Convert.ToInt16(ConfigurationManager.AppSettings["port"]);
                oClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["ssl"]);
                oClient.DeliveryMethod = SmtpDeliveryMethod.Network;


                //oClient.SendCompleted();
                //oClient.EnableSsl = true;
                //SmtpClient client = new SmtpClient();

                oClient.Send(oMailMessage);
                //oClient.SendAsync(oMailMessage, null);
            }
            catch (Exception ex)
            {
                return (int)CCommon.StatusCode.Fail;
            }

            return (int)CCommon.StatusCode.Success;

        }

        public static int SendSystemGeneratedMailSync(string strMailTo, string strSubject, string strBody, string strDisplayName, bool bIsBodyHTML)
        {
            MailMessage oMailMessage;
            // Check if To and From Fields have been provided
            try
            {
                if (strMailTo == "")
                {
                    return (int)CError.ErrorType.Fail;
                }

                if (strMailTo == "")
                {
                    return (int)CError.ErrorType.Fail;
                }
                oMailMessage = new MailMessage(new MailAddress(ConfigurationManager.AppSettings["from"].ToString(), ConfigurationManager.AppSettings["fromdisplayname"]), new MailAddress(strMailTo));

                //oMailMessage = new MailMessage(ConfigurationManager.AppSettings["MailFrom"].ToString(), strMailTo);

                oMailMessage.Priority = MailPriority.Normal;
                oMailMessage.Subject = strSubject;
                oMailMessage.Body = strBody;
                oMailMessage.IsBodyHtml = bIsBodyHTML;
                oMailMessage.ReplyTo = new MailAddress(ConfigurationManager.AppSettings["replyto"].ToString());
                string[] strBCCEmails = ConfigurationManager.AppSettings["bccaddress"].ToString().Split(CCommon.arrCategorySplitChars);
                foreach (string strMail in strBCCEmails)
                {
                    oMailMessage.Bcc.Add(strMail);
                }
                //oMailMessage.Headers.Add("Disposition-Notification-To", "catchall@rdassociates.co.in");
                oMailMessage.Headers.Add("Company", ConfigurationManager.AppSettings["companyname"]);
                oMailMessage.Priority = MailPriority.Normal;
                oMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                oMailMessage.DeliveryNotificationOptions = System.Net.Mail.DeliveryNotificationOptions.OnFailure;


                SmtpClient oClient = new SmtpClient(ConfigurationManager.AppSettings["smtp"]);
                oClient.UseDefaultCredentials = false;
                oClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
                oClient.Port = Convert.ToInt16(ConfigurationManager.AppSettings["port"]);
                oClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["ssl"]);
                oClient.DeliveryMethod = SmtpDeliveryMethod.Network;


                //oClient.SendCompleted();
                //oClient.EnableSsl = true;
                //SmtpClient client = new SmtpClient();

                //oClient.Send(oMailMessage);

                //File.AppendAllText(HttpContext.Current.Server.MapPath("~/logs/email_logs" + DateTime.Now.ToString("yyyy-dd-MM") + ".txt"), "\n\r Request Send Time :" + DateTime.Now + "\n\r");
                //File.AppendAllText(HttpContext.Current.Server.MapPath("~/logs/email_logs" + DateTime.Now.ToString("yyyy-dd-MM") + ".txt"), "\n\r Email Send To :" + strMailTo + "\n\r");
                oClient.SendAsync(oMailMessage, null);
                //File.AppendAllText(HttpContext.Current.Server.MapPath("~/logs/email_logs" + DateTime.Now.ToString("yyyy-dd-MM") + ".txt"), "\n\r Request Completed Time :" + DateTime.Now + "\n\r");
                StringBuilder strError = new StringBuilder();
                strError.AppendFormat("Subject : \n\r " + strSubject);
                strError.AppendLine();
                strError.AppendFormat(" \n\r ------------------- \n\r Body : \n\r " + strBody + " \n\r ------------------- \n\r ");
                strError.AppendLine();
               // File.AppendAllText(HttpContext.Current.Server.MapPath("~/logs/Errorcheck_logs" + DateTime.Now.ToString("yyyy-dd-MM") + ".txt"), strError.ToString());

            }
            catch (Exception ex)
            {
                //IMP: please check "Async=true" 
                //File.AppendAllText(HttpContext.Current.Server.MapPath("~/logs/email_logs" + DateTime.Now.ToString("yyyy-dd-MM") + ".txt"), ex.ToString() + "\n\r" + "" + "" + "\n\r");
                //File.AppendAllText(HttpContext.Current.Server.MapPath("~/logs/email_logs" + DateTime.Now.ToString("yyyy-dd-MM") + ".txt"), "\n\r Email Send To :" + strMailTo + "\n\r");
                //File.AppendAllText(HttpContext.Current.Server.MapPath("~/logs/email_logs" + DateTime.Now.ToString("yyyy-dd-MM") + ".txt"), ex.ToString() + "\n\r Request Failed Time : " + "" + DateTime.Now + "\n\r");
                //HttpContext.Current.Response.Write(ex);

                StringBuilder strError = new StringBuilder();
                strError.AppendFormat("Subject : \n\r " + strSubject);
                strError.AppendLine();
                strError.AppendFormat(" \n\r ------------------- \n\r Body : \n\r " + strBody + " \n\r ------------------- \n\r ");
                strError.AppendLine();
            //    File.AppendAllText(HttpContext.Current.Server.MapPath("~/logs/Errorcheck_logs" + DateTime.Now.ToString("yyyy-dd-MM") + ".txt"), strError.ToString());
                return (int)CError.ErrorType.MailSendingFailed;
            }

            return (int)CError.ErrorType.MailSentSuccessfully;

        }

        public static int SendSystemGeneratedMailWithAttachmentsAndCC(string strMailTo, string strSubject, string strBody, string strDisplayName, string[] oAttachments, string[] oFileNames, bool bIsBodyHTML)
        {
            MailMessage oMailMessage;
            // Check if To and From Fields have been provided
            try
            {
                if (strMailTo == "")
                {
                    return (int)CError.ErrorType.Fail;
                }

                oMailMessage = new MailMessage(new MailAddress(ConfigurationManager.AppSettings["from"].ToString(), ConfigurationManager.AppSettings["fromdisplayname"]), new MailAddress(strMailTo));

                //oMailMessage = new MailMessage(ConfigurationManager.AppSettings["MailFrom"].ToString(), strMailTo);

                oMailMessage.Priority = MailPriority.Normal;
                oMailMessage.Subject = strSubject;
                oMailMessage.Body = strBody;
                oMailMessage.IsBodyHtml = bIsBodyHTML;
                oMailMessage.ReplyTo = new MailAddress(ConfigurationManager.AppSettings["replyto"].ToString());
                string[] strBCCEmails = ConfigurationManager.AppSettings["bccaddress"].ToString().Split(CCommon.arrCategorySplitChars);
                string[] strCCEmails = ConfigurationManager.AppSettings["ccaddress"].ToString().Split(CCommon.arrCategorySplitChars);
                foreach (string strMail in strBCCEmails)
                {
                    oMailMessage.Bcc.Add(strMail);
                }

                foreach (string strCCMail in strCCEmails)
                {
                    oMailMessage.CC.Add(strCCMail);
                }

                //Attachments
                int i = 0;
                Attachment oInlineAttachment;
                foreach (string strAttachment in oAttachments)
                {
                    oInlineAttachment = new Attachment(strAttachment, CCommon.GetMimeType(Path.GetExtension(strAttachment)));
                    oInlineAttachment.Name = oFileNames[i].ToString();
                    oMailMessage.Attachments.Add(oInlineAttachment);
                    i++;
                }

                //oMailMessage.Headers.Add("Disposition-Notification-To", "catchall@rdassociates.co.in");
                oMailMessage.Headers.Add("Company", ConfigurationManager.AppSettings["companyname"]);
                oMailMessage.Priority = MailPriority.Normal;
                oMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                oMailMessage.DeliveryNotificationOptions = System.Net.Mail.DeliveryNotificationOptions.OnFailure;


                SmtpClient oClient = new SmtpClient(ConfigurationManager.AppSettings["smtp"]);
                oClient.UseDefaultCredentials = false;
                oClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
                oClient.Port = Convert.ToInt16(ConfigurationManager.AppSettings["port"]);
                oClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["ssl"]);
                oClient.DeliveryMethod = SmtpDeliveryMethod.Network;


                //oClient.SendCompleted();
                //oClient.EnableSsl = true;
                //SmtpClient client = new SmtpClient();

                //oClient.Send(oMailMessage);

                //File.AppendAllText(HttpContext.Current.Server.MapPath("~/logs/email_logs" + DateTime.Now.ToString("yyyy-dd-MM") + ".txt"), "\n\r Request Send Time :" + DateTime.Now + "\n\r");
                //File.AppendAllText(HttpContext.Current.Server.MapPath("~/logs/email_logs" + DateTime.Now.ToString("yyyy-dd-MM") + ".txt"), "\n\r Email Send To :" + strMailTo + "\n\r");
                //oClient.SendAsync(oMailMessage, null);
                oClient.Send(oMailMessage);
               // File.AppendAllText(HttpContext.Current.Server.MapPath("~/logs/email_logs" + DateTime.Now.ToString("yyyy-dd-MM") + ".txt"), "\n\r Request Completed Time :" + DateTime.Now + "\n\r");

            }
            catch (Exception ex)
            {
                //IMP: please check "Async=true" 
                //File.AppendAllText(HttpContext.Current.Server.MapPath("~/logs/email_logs" + DateTime.Now.ToString("yyyy-dd-MM") + ".txt"), ex.ToString() + "\n\r" + "" + "" + "\n\r");
                //File.AppendAllText(HttpContext.Current.Server.MapPath("~/logs/email_logs" + DateTime.Now.ToString("yyyy-dd-MM") + ".txt"), "\n\r Email Send To :" + strMailTo + "\n\r");
                //File.AppendAllText(HttpContext.Current.Server.MapPath("~/logs/email_logs" + DateTime.Now.ToString("yyyy-dd-MM") + ".txt"), ex.ToString() + "\n\r Request Failed Time : " + "" + DateTime.Now + "\n\r");
                //HttpContext.Current.Response.Write(ex);
                return (int)CError.ErrorType.MailSendingFailed;
            }

            return (int)CError.ErrorType.MailSentSuccessfully;

        }

    }
}