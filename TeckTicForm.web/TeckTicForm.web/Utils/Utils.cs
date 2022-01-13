using OpenHtmlToPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace TeckTicForm.web.Utils
{
    public class Utils
    {
        #region EMAIL

        /// <summary>
        /// 
        /// </summary>
        /// <param name="smtp"></param>
        /// <param name="emailFrom"></param>
        /// <param name="emailTo"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool SendEmail(string smtp, string emailFrom, string emailTo, string username, string password, string subject, string body, string fileName)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp);
                System.Net.Mail.Attachment attachment;

                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.CC.Add(emailFrom);
                mail.Subject = subject;
                mail.Body = body;

                attachment = new System.Net.Mail.Attachment(fileName);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(username, password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region PDF

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlPath"></param>
        /// <param name="pdfPathFile"></param>
        /// <param name="form"></param>
        public static void ConvertHtmlToPdf(string htmlPath, string pdfPathFile, FormClient form)
        {
            StringBuilder html = GetHTMLCode(htmlPath, form);

            var pdf = Pdf.From(html.ToString()).OfSize(PaperSize.A4);
            byte[] content = pdf.Content();

            //using (FileStream fs = File.Create(pdfPathFile))
            //{
            //    fs.Write(content, 0, content.Length);
            //}

            File.WriteAllBytes(pdfPathFile, content);

            //var myFile = File.Create(pdfPathFile);
            //myFile.Write(content, 0, content.Length);
            //myFile.Close();



        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        public static void DeletePDF(string filePath, int number)
        {
         
            try
            {
                for (int i = 1; i < number; i++)
                {
                    if (File.Exists(filePath + i.ToString() + ".pdf"))
                    {
                        File.Delete(filePath + i.ToString() + ".pdf");
                    }
                    
                }

                
            }
            catch (Exception)
            {

                
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="path"></param>
        public static void SaveProcessNumber(int number, string path)
        {
            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(path))
            {

                outputFile.WriteLine(number.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int GetProcessNumber(string path)
        {
            int processNumber;

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamReader outputFile = new StreamReader(path))
            {

                processNumber = int.Parse(outputFile.ReadLine());
            }

            return processNumber;
        }

        #endregion

        #region HTML


        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public static StringBuilder GetHTMLCode(string path, FormClient form)
        {
            StringBuilder htmlCode;

            using (StreamReader outputFile = new StreamReader(path))
            {
                htmlCode = new StringBuilder(outputFile.ReadToEnd());
            }

            htmlCode = ReplaceHTMLText(htmlCode, form);

            return htmlCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlCode"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public static StringBuilder ReplaceHTMLText(StringBuilder htmlCode, FormClient form)
        {
            htmlCode.Replace("#LOGO", form.LogoPath);
            htmlCode.Replace("#DATE", DateTime.Now.ToString("yyyy-MM-dd"));
            htmlCode.Replace("#NIF", form.NIF);
            htmlCode.Replace("#NAME", form.Name);
            htmlCode.Replace("#ADDRESS", form.Address);
            htmlCode.Replace("#POSTALCODE", form.PostalCode);
            htmlCode.Replace("#CITY", form.City);
            htmlCode.Replace("#PHONE", form.Phone);
            htmlCode.Replace("#MOBILE", form.Mobile);
            htmlCode.Replace("#EMAIL", form.Email);
            htmlCode.Replace("#BRAND", form.Brand);
            htmlCode.Replace("#MODEL", form.Model);
            htmlCode.Replace("#SERIAL", form.Serial);
            htmlCode.Replace("#TYPE", form.Type);
            htmlCode.Replace("#ITEMS", form.Items);
            htmlCode.Replace("#PROBLEM", form.Problem);
            htmlCode.Replace("#REPRODUCE", form.Reproduce);
            htmlCode.Replace("#PROCESSNUMBER", form.ProcessNumber);

            return htmlCode;
        }



        #endregion


       
    }
}