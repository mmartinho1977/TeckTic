
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeckTicForm.web.Utils;

namespace TeckTicForm.web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string smtp = Application["SMTP"].ToString().TrimEnd();
            string emailFrom = Application["Email"].ToString().TrimEnd();
            string subject;
            string body;
            string pdfFileName;
            string htmlFileName;
            string logoFileName;
            string emailTo;
            string processNumberFilePath;
            int processNumber;
            string returnUrlQueryString;
            bool result = true;
            FormClient form;

            processNumberFilePath = HttpContext.Current.Server.MapPath(@"~/Resources/files/processNumber.txt");
            processNumber = Utils.Utils.GetProcessNumber(processNumberFilePath) + 1;
            subject = "PR" + processNumber.ToString("0000");
            
            pdfFileName = HttpContext.Current.Server.MapPath(@"~/Resources/files/requisicao" + processNumber + ".pdf");
            htmlFileName = HttpContext.Current.Server.MapPath(@"~/FormFile.html");
            logoFileName = HttpContext.Current.Server.MapPath(@"~/Resources/images/logo.png");

            form = new FormClient
            {
                ProcessNumber = subject,
                LogoPath = logoFileName,
                NIF = TextBoxNif.Text,
                Name = TextBoxName.Text,
                Address = TextBoxAddress.Text,
                PostalCode = TextBoxPostalCode.Text,
                City = TextBoxCity.Text,
                Phone = TextBoxPhone.Text,
                Mobile = TextBoxMobile.Text,
                Email = TextBoxEmail.Text,
                Brand = TextBoxBrand.Text,
                Model = TextBoxModel.Text,
                Serial = TextBoxSerial.Text,
                Type = TextBoxType.Text,
                Items = TextBoxItems.Text,
                Problem = TextBoxProblem.Text,
                Reproduce = TextBoxReproduce.Text

            };

            Utils.Utils.ConvertHtmlToPdf(htmlFileName, pdfFileName, form);

            
            body = string.Format("O seu processo foi registado com o número {0}.\n Rencaminhe o documento em anexo para apoio.cliente@techtic.pt", subject);
            emailTo = TextBoxEmail.Text.Trim();

            try
            {
                Utils.Utils.ConvertHtmlToPdf(htmlFileName, pdfFileName, form);

                result = Utils.Utils.SendEmail(smtp, emailFrom, emailTo, Application["Email"].ToString().TrimEnd(), Application["Password"].ToString().TrimEnd(), subject, body, pdfFileName);

                if (result)
                {
                    Utils.Utils.SaveProcessNumber(processNumber, processNumberFilePath);
                }

                Utils.Utils.DeletePDF(HttpContext.Current.Server.MapPath(@"~/Resouces/files/requisicao"), processNumber);

            }
            catch (Exception)
            {

                result = false;
            }
            finally
            {
                returnUrlQueryString = string.Format("returnUrl={0}&result={1}", Server.UrlEncode(Request.AppRelativeCurrentExecutionFilePath), result);

                Response.Redirect(string.Format("{0}?{1}?", Application["MessagePage"].ToString().TrimEnd(), returnUrlQueryString), true);
            }






        }

        

       
    }
}