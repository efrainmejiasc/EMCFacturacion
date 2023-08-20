using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NegocioEMC.IServices;

namespace NegocioEMC.Services
{
    public  class CartonPdfService : ICartonPdfService
    {
     
        public CartonPdfService() 
        { 
        }

        public byte[] GeneratePdf(List<List<string>> imageLists, string path)
        {
            MemoryStream memoryStream = new MemoryStream();
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            document.Open();

            foreach (List<string> imagePaths in imageLists)
            {
                PdfPTable table = new PdfPTable(8);

                foreach (string imagePath in imagePaths)
                {
                    PdfPCell cell = new PdfPCell();
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);
                    cell.AddElement(image);
                    table.AddCell(cell);
                }

                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        table.AddCell("Celda " + (i * 8 + j + 1));
                    }
                }

                document.NewPage(); 
                document.Add(table);
            }

            document.Close();
            writer.Close();
            var result = memoryStream.ToArray();
            return result;
        }

        public byte[] GeneratePdf(List<List<int>> numberLists, string path)
        {
            MemoryStream memoryStream = new MemoryStream();
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            document.Open();

            foreach (List<int> numbers in numberLists)
            {
                PdfPTable table = new PdfPTable(8);

                foreach (int number in numbers)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(number.ToString())); 
                    table.AddCell(cell);
                }

                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        table.AddCell("Celda " + (i * 8 + j + 1));
                    }
                }

                document.NewPage(); 
                document.Add(table);
            }

            document.Close();
            writer.Close();

            var result = memoryStream.ToArray();
            string pdfFileName = "\\generated_pdf_" + Guid.NewGuid().ToString() + ".pdf";
            string pdfFilePath = path + pdfFileName;
            System.IO.File.WriteAllBytes(pdfFilePath,result);

            return result;
        }

    }
}
