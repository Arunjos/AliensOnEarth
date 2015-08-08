using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.IO;
using System.Text;

namespace export_as_text
{
    public class export_as_text
    {

        public static bool checkfile(List<List<string>> AlienDB)
        {
            var a = System.Console.ReadLine();
            int count = 0; 
            FileStream fstream;
            StreamWriter fwriter;
            TextWriter txtout = Console.Out;
            String path;
            Console.WriteLine("\nEnter the folder path to create file\n");
            path = Console.ReadLine();
            Random rand = new Random();
            int RandValue = rand.Next(1, 1000);
            String filename = @path + @"\Alien_on_earth" + RandValue + ".txt";
            try
            {
                fstream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                fwriter = new StreamWriter(fstream);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nThe Following error will occur in creating file\n"+e);
                return (false); 
            }
            
            foreach (var listtemp in AlienDB)
            {
                
                Console.SetOut(fwriter);
                Console.WriteLine("\t Alien Data "+ ++count);
                Console.WriteLine("Name             : " + listtemp[0]);
                Console.WriteLine("Home Planet      : " + listtemp[1]);
                Console.WriteLine("Blood Color      : " + listtemp[2]);
                Console.WriteLine("No of Antennas   : " + listtemp[3]);
                Console.WriteLine("No. of Legs      : " + listtemp[4]);
                
                Console.SetOut(txtout);
                //System.Console.WriteLine();
            }
            
            fwriter.Close();
            fstream.Close();
            Console.WriteLine("Text File Created Succesfully \nFile Location    :"+filename+"\n");
            
            return (true);
        }         
    }
}
