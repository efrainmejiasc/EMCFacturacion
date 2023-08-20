using System.Collections.Generic;
using System.IO;
using iTextSharp.text.pdf;

namespace NegocioEMC.Services
{
    public  class CartonPdfService
    {
        public byte[] GeneratePdf(List<List<string>> imageLists)
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
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath); // Use the real image path
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

                document.NewPage(); // Add a new page for each list of images
                document.Add(table);
            }

            document.Close();
            writer.Close();
            var result = memoryStream.ToArray();
            return result;
        }
    }
}
