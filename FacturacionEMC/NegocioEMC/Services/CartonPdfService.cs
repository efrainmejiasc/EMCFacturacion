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

        public byte[] GeneratePdfImagenes(List<List<int>> numberLists, string path)
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

                table.AddCell(GetImageBingo(numbers[0]));
                table.AddCell(GetImageBingo(numbers[1]));
                table.AddCell(GetImageBingo(numbers[2]));
                table.AddCell(GetImageBingo(numbers[3]));
                table.AddCell(emptyCell);
                table.AddCell(GetImageBingo(numbers[4]));
                table.AddCell(GetImageBingo(numbers[5]));
                table.AddCell(GetImageBingo(numbers[6]));
                table.AddCell(GetImageBingo(numbers[7]));

                table.AddCell(GetImageBingo(numbers[8]));
                table.AddCell(GetImageBingo(numbers[9]));
                table.AddCell(GetImageBingo(numbers[10]));
                table.AddCell(GetImageBingo(numbers[11]));
                table.AddCell(emptyCell);
                table.AddCell(GetImageBingo(numbers[12]));
                table.AddCell(GetImageBingo(numbers[13]));
                table.AddCell(GetImageBingo(numbers[14]));
                table.AddCell(GetImageBingo(numbers[15]));

                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);

                table.AddCell(GetImageBingo(numbers[16]));
                table.AddCell(GetImageBingo(numbers[17]));
                table.AddCell(GetImageBingo(numbers[18]));
                table.AddCell(GetImageBingo(numbers[19]));
                table.AddCell(emptyCell);
                table.AddCell(GetImageBingo(numbers[20]));
                table.AddCell(GetImageBingo(numbers[21]));
                table.AddCell(GetImageBingo(numbers[22]));
                table.AddCell(GetImageBingo(numbers[23]));

                table.AddCell(GetImageBingo(numbers[24]));
                table.AddCell(GetImageBingo(numbers[25]));
                table.AddCell(GetImageBingo(numbers[26]));
                table.AddCell(GetImageBingo(numbers[27]));
                table.AddCell(emptyCell);
                table.AddCell(GetImageBingo(numbers[28]));
                table.AddCell(GetImageBingo(numbers[29]));
                table.AddCell(GetImageBingo(numbers[30]));
                table.AddCell(GetImageBingo(numbers[31]));

                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);

                table.AddCell(GetImageBingo(numbers[32]));
                table.AddCell(GetImageBingo(numbers[33]));
                table.AddCell(GetImageBingo(numbers[34]));
                table.AddCell(GetImageBingo(numbers[35]));
                table.AddCell(emptyCell);
                table.AddCell(GetImageBingo(numbers[36]));
                table.AddCell(GetImageBingo(numbers[37]));
                table.AddCell(GetImageBingo(numbers[38]));
                table.AddCell(GetImageBingo(numbers[39]));

                table.AddCell(GetImageBingo(numbers[40]));
                table.AddCell(GetImageBingo(numbers[41]));
                table.AddCell(GetImageBingo(numbers[42]));
                table.AddCell(GetImageBingo(numbers[43]));
                table.AddCell(emptyCell);
                table.AddCell(GetImageBingo(numbers[44]));
                table.AddCell(GetImageBingo(numbers[45]));
                table.AddCell(GetImageBingo(numbers[46]));
                table.AddCell(GetImageBingo(numbers[47]));

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

        public byte[] GeneratePdfNumeros(List<List<int>> numberLists, string path)
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

        private PdfPCell GetImageBingo(int n)
        {
            var imagePath = string.Empty;

            PdfPCell cell = new PdfPCell();
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);
            cell.AddElement(image);

            return cell;
        }
    }
}
