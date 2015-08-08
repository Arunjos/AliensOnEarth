using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System.Reflection;

namespace export_as_pdf
{
    public class export_as_pdf
    {
        static PdfDocument pdf;
        static PdfPage pdfPage;
        static XGraphics graph;
        static XFont font;
        static XTextFormatter tf;

        public static bool PdfAddPage(String str)
        {
            pdfPage = pdf.AddPage();
            graph = XGraphics.FromPdfPage(pdfPage);
            font = new XFont("Verdana", 20, XFontStyle.Bold);
            tf = new XTextFormatter(graph);
            tf.DrawString(str, font, XBrushes.Black, new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            return (true);
        }
        
        public static bool checkfile(List<List<string>> AlienDB)
        {
          
                int count = 0;
                String path;
                String PdfStr = "";
                Console.WriteLine("\nEnter the folder path to create file\n");
                path = Console.ReadLine();
                Random rand = new Random();
                int RandValue = rand.Next(1, 1000);
                String filename = @path + @"\Alien_on_earth" + RandValue + ".pdf";
                try
                {
                    pdf = new PdfDocument();
                    pdf.Info.Title = "Alien Registeration";
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nThe Following error will occur in creating pdf document\n" + e);
                    return (false);
                }
                
                    foreach (var listtemp in AlienDB)
                    {
                        string str = "----- Alien Data" + ++count + " ----- \n Name:  " + listtemp[0] + "\n Home Planet      : " + listtemp[1] + "\n Blood Color      : " + listtemp[2] + "\n No of Antennas   : " + listtemp[3] + "\nNo. of Legs      : " + listtemp[4] + "\n\n";
                        PdfStr = PdfStr + str;
                        if (count % 4 == 0)
                        {
                            PdfAddPage(PdfStr);
                            PdfStr = "";
                        }


                    }

                    if (count % 4 != 0)
                    {
                        PdfAddPage(PdfStr);
                        PdfStr = "";
                    }

                    try
                    {
                        pdf.Save(filename);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\nThe Following error will occur in creating pdf document file\n" + e);
                        return (false);
                    }

                    Console.WriteLine("\nText File Created Succesfully \nFile Location    :" + filename + "\n");
                
            return (true);
        }   

    }
}
