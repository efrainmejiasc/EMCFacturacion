using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NegocioEMC.Commons;
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
            string pdfFileName = "\\generated_pdf_" + Guid.NewGuid().ToString() + ".pdf";
            string pdfFilePath = path + pdfFileName;
            System.IO.File.WriteAllBytes(pdfFilePath, result);

            return result;
        }

        public byte[] GeneratePdf(List<List<int>> numberLists, string path)
        {
            MemoryStream memoryStream = new MemoryStream();
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            PdfPCell emptyCell = new PdfPCell(new Phrase(" "));
            emptyCell.Border = PdfPCell.NO_BORDER;
            

            document.Open();

            int n = 1;
            int indiceLista = 0;
            foreach (List<int> numbers in numberLists)
            {
                PdfPTable table = new PdfPTable(9);

                table.AddCell(numbers[0].ToString());
                table.AddCell(numbers[1].ToString());
                table.AddCell(numbers[2].ToString());
                table.AddCell(numbers[3].ToString());
                table.AddCell(emptyCell);
                table.AddCell(numbers[4].ToString());
                table.AddCell(numbers[5].ToString());
                table.AddCell(numbers[6].ToString());
                table.AddCell(numbers[7].ToString());

                table.AddCell(numbers[8].ToString());
                table.AddCell(numbers[9].ToString());
                table.AddCell(numbers[10].ToString());
                table.AddCell(numbers[11].ToString());
                table.AddCell(emptyCell);
                table.AddCell(numbers[12].ToString());
                table.AddCell(numbers[13].ToString());
                table.AddCell(numbers[14].ToString());
                table.AddCell(numbers[15].ToString());

                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);

                table.AddCell(numbers[16].ToString());
                table.AddCell(numbers[17].ToString());
                table.AddCell(numbers[18].ToString());
                table.AddCell(numbers[19].ToString());
                table.AddCell(emptyCell);
                table.AddCell(numbers[20].ToString());
                table.AddCell(numbers[21].ToString());
                table.AddCell(numbers[22].ToString());
                table.AddCell(numbers[23].ToString());

                table.AddCell(numbers[24].ToString());
                table.AddCell(numbers[25].ToString());
                table.AddCell(numbers[26].ToString());
                table.AddCell(numbers[27].ToString());
                table.AddCell(emptyCell);
                table.AddCell(numbers[28].ToString());
                table.AddCell(numbers[29].ToString());
                table.AddCell(numbers[30].ToString());
                table.AddCell(numbers[31].ToString());

                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);

                table.AddCell(numbers[32].ToString());
                table.AddCell(numbers[33].ToString());
                table.AddCell(numbers[34].ToString());
                table.AddCell(numbers[35].ToString());
                table.AddCell(emptyCell);
                table.AddCell(numbers[36].ToString());
                table.AddCell(numbers[37].ToString());
                table.AddCell(numbers[38].ToString());
                table.AddCell(numbers[39].ToString());

                table.AddCell(numbers[40].ToString());
                table.AddCell(numbers[41].ToString());
                table.AddCell(numbers[42].ToString());
                table.AddCell(numbers[43].ToString());
                table.AddCell(emptyCell);
                table.AddCell(numbers[44].ToString());
                table.AddCell(numbers[45].ToString());
                table.AddCell(numbers[46].ToString());
                table.AddCell(numbers[47].ToString());

                var titleParagraph = GetTableTitle(indiceLista);

                var salto = GetSaltoLineaPdf();

                if (n == 1)
                {
                    document.NewPage();
                    document.Add(titleParagraph);
                    document.Add(salto);
                    document.Add(table);
                    document.Add(salto);
                    document.Add(salto);
                    n++;
                }
                else if (n == 2)
                {
                    document.Add(titleParagraph);
                    document.Add(salto);
                    document.Add(table);
                    n = 1;
                }
                indiceLista++;
            }

            document.Close();
            writer.Close();

            var result = memoryStream.ToArray();
            string pdfFileName = "\\generated_pdf_" + DateTime.Now.ToString().
                                                     Replace("/", "").Replace("-", "").
                                                     Replace(" ", "").Replace(":", "").
                                                     Replace(".", "") + ".pdf";
            string pdfFilePath = path + pdfFileName;
            System.IO.File.WriteAllBytes(pdfFilePath, result);

            return result;
        }

        private Paragraph GetTableTitle(int n)
        {
            Paragraph titleParagraph = new Paragraph(EngineTool.SetSerieCartonBingo(n), 
                                                     new Font(Font.FontFamily.HELVETICA, 
                                                     14, 
                                                     Font.BOLD));

            titleParagraph.Alignment = Element.ALIGN_CENTER;

            return titleParagraph;
        }

        private Paragraph GetSaltoLineaPdf()
        {
            Paragraph lineBreak = new Paragraph();
            lineBreak.SpacingBefore = 10; 
            lineBreak.SpacingAfter = 10;  

            return lineBreak;
        }

        public List<int> InsertZerosAtPositions(List<int> numbers)
        {
            List<int> result = new List<int>();

            int[] positionsToAddZero = { 4, 13, 22, 31, 40 };
            int currentInsertIndex = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (currentInsertIndex < positionsToAddZero.Length && i == positionsToAddZero[currentInsertIndex])
                {
                    result.Add(0);
                    currentInsertIndex++;
                }
                result.Add(numbers[i]);
            }

            // Si quedaron posiciones por agregar, agregamos ceros al final
            while (currentInsertIndex < positionsToAddZero.Length)
            {
                result.Add(0);
                currentInsertIndex++;
            }

            return result;
        }


    }
}
