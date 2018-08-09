using System;   
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace FooTheory.iTextSharpLibrary
{
    /// <summary>
    /// Example PDF Class
    /// </summary>
    public class FooTheoryPdf
    {
        /// <summary>
        /// Method that will utilize iTextSharp to write the <see cref="stringToWriteToPdf"/> to the 
        /// pdf on each page of the PDF.
        /// </summary>
        /// <param name="sourceFile">The PDf File</param>
        /// <param name="stringToWriteToPdf">The text to write to the pdf</param>
        /// <returns>The bytes of the newly updated PDF with <see cref="stringToWriteToPdf"/> in the pdf.</returns>
        public static byte[] WriteToPdf(FileInfo sourceFile, string stringToWriteToPdf)
        {
            PdfReader reader = new PdfReader(sourceFile.FullName);

            string name = "Name : Ayush";
            string regNo = "Registration ID: 13";
            string batch = " Batch Center : Delhi";

            //var con = String.Join(Environment.NewLine, name);

            using (MemoryStream memoryStream = new MemoryStream())
            {

                PdfStamper pdfStamper = new PdfStamper(reader, memoryStream);

                for (int i = 1; i <= reader.NumberOfPages; i++) // Must start at 1 because 0 is not an actual page.
                {

                    Rectangle pageSize = reader.GetPageSize(i);

                    PdfContentByte pdfPageContents = pdfStamper.GetUnderContent(i);
                    //PdfContentByte stuName = pdfStamper.GetUnderContent(i);
                    //PdfContentByte stuRegistration= pdfStamper.GetUnderContent(i);
                    //PdfContentByte stuID = pdfStamper.GetUnderContent(i);
                    PdfContentByte stuDetails = pdfStamper.GetUnderContent(i);
                    stuDetails.BeginText();
                    pdfPageContents.BeginText();
                    //stuName.BeginText();
                    //stuRegistration.BeginText();
                    //stuID.BeginText();

                    BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, Encoding.ASCII.EncodingName, false);
                    pdfPageContents.SetFontAndSize(baseFont, 10); // 40 point font
                    pdfPageContents.SetRGBColorFill(211, 211, 211); // Sets the color of the font, RED in this instance

                    //Todo
                    //BaseFont baseFont1 = BaseFont.CreateFont(BaseFont.COURIER, Encoding.ASCII.EncodingName, false);
                    //pdfPageContents1.SetFontAndSize(baseFont1, 20);
                    //pdfPageContents1.SetRGBColorFill(255, 191, 211); // Sets the color of the font, RED in this instance

                    //Todo

                    //
                    // Angle of the text. This will give us the angle so we can angle the text diagonally 
                    // from the bottom left corner to the top right corner through the use of simple trigonometry. 
                    //
                    float textAngle = 0;
                    //(float) FooTheoryMath.GetHypotenuseAngleInDegreesFrom(pageSize.Height, pageSize.Width);

                    //
                    // Note: The x,y of the Pdf Matrix is from bottom left corner. 
                    // This command tells iTextSharp to write the text at a certain location with a certain angle.
                    // Again, this will angle the text from bottom left corner to top right corner and it will 
                    // place the text in the middle of the page. 
                    //
                    pdfPageContents.ShowTextAligned(PdfContentByte.ALIGN_CENTER, stringToWriteToPdf,
                                                    pageSize.Width / 2,
                                                    pageSize.Height / 16,
                                                    textAngle);
                    //pdfPageContents.ShowTextAligned(PdfContentByte.ALIGN_CENTER, name,
                    //            pageSize.Width / 2,
                    //            pageSize.Height / 2,
                    //            textAngle);
                    //pdfPageContents1.ShowTextAligned(PdfContentByte.ALIGN_CENTER, stuinfo,
                    //            pageSize.Width / 2,
                    //            pageSize.Height / 2,
                    //            textAngle);
                    //pdfPageContents1.EndText();
                    pdfPageContents.EndText(); // Done working with text
                }
                for (int i = 1; i <= reader.NumberOfPages; i++) // Must start at 1 because 0 is not an actual page.
                {

                    Rectangle pageDim = reader.GetPageSize(i);

                    PdfContentByte stuDetails = pdfStamper.GetUnderContent(i);
                    stuDetails.BeginText();


                    BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, Encoding.ASCII.EncodingName, false);
                    stuDetails.SetFontAndSize(baseFont, 30); // 40 point font
                    stuDetails.SetRGBColorFill(211, 211, 211); // Sets the color of the font, RED in this instance


                    float textAngle = 15;

                    stuDetails.ShowTextAligned(PdfContentByte.ALIGN_CENTER, name,
                                                    pageDim.Width / 2,
                                                    (pageDim.Height /2)+50,
                                                    textAngle);
                    stuDetails.ShowTextAligned(PdfContentByte.ALIGN_CENTER, regNo,
                                pageDim.Width / 2,
                                (pageDim.Height / 2),
                                textAngle);
                    stuDetails.ShowTextAligned(PdfContentByte.ALIGN_CENTER, batch,
                                pageDim.Width / 2,
                                (pageDim.Height / 2)-50,
                                textAngle);

                    stuDetails.EndText(); // Done working with text
                }
                pdfStamper.FormFlattening = true; // enable this if you want the PDF flattened. 
                pdfStamper.Close(); // Always close the stamper or you'll have a 0 byte stream. 


                return memoryStream.ToArray();
            }
        }

        

    }
}