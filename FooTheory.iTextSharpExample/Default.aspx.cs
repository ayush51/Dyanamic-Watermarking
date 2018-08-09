using System;
using System.IO;
using System.Web.UI;
using FooTheory.iTextSharpLibrary;

namespace FooTheory.iTextSharpExample
{
    public partial class _Default : Page
    {
        private FileInfo pdfFileInfo;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            pdfFileInfo = new FileInfo(Server.MapPath("App_Data/ExampleDocument.pdf"));
        }

        protected void generatedPdfButton_Click(object sender, EventArgs e)
        {
            byte[] fileBytes = FooTheoryPdf.WriteToPdf(pdfFileInfo, pdfTextTextBox.Text);
            SendPdfToUser(pdfFileInfo, fileBytes);
         
        }
       
    
       
        /// <summary>
        /// Sends the PDF to the user. 
        /// </summary>
        /// <param name="pdfFileInfo"></param>
        /// <param name="fileBytes"></param>
        private void SendPdfToUser(FileInfo pdfFileInfo, byte[] fileBytes)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/pdf";
            Context.Response.AppendHeader("content-disposition", "attachment; filename=" + pdfFileInfo.Name);
            Context.Response.BinaryWrite(fileBytes);
            Context.Response.Flush();
            Context.Response.End();
           
        }



    }
}