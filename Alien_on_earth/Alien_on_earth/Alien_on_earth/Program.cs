using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
namespace Alien_on_earth
{

    class RegisterAlien
    {
        protected static List<List<string>> AlienDB = new List<List<string>>();

        String temp;
        public void RegAlien()
        {
            List<string> AlienDBTemp = new List<string>();
            int check;
            System.Console.WriteLine("Enter The Code Name");
            AlienDBTemp.Add(Console.ReadLine());

            System.Console.WriteLine("Enter The Home Planet");
            AlienDBTemp.Add(Console.ReadLine());

            System.Console.WriteLine("Enter The Blood Color");
            AlienDBTemp.Add(Console.ReadLine());

            System.Console.WriteLine("Enter The Number of Antennas");
            temp = Console.ReadLine();

            while (!int.TryParse(temp, out check))
            {
                System.Console.WriteLine("Error:Not a valid Entry!!! Please enter a digit");
                temp = Console.ReadLine();
            }
            AlienDBTemp.Add(temp);

            System.Console.WriteLine("Enter The Number No. of Legs");
            temp = Console.ReadLine();
            while (!int.TryParse(temp, out check))
            {
                System.Console.WriteLine("Error:Not a valid Entry!!! Please enter a digit");
                temp = Console.ReadLine();
            }
            AlienDBTemp.Add(temp);
            AlienDB.Add(AlienDBTemp);
            System.Console.WriteLine("Do you want to Continue Registeration??  (y)yes   (n/any key)No");
            temp = Console.ReadLine();
            if (temp.Equals("y") || temp.Equals("Y"))
            {
                RegAlien();
            }


        }

        public void DisplayRegAlien()
        {
            int count = 0;
            System.Console.WriteLine("Registerd Aliens List:\n");
            foreach (var listtemp in AlienDB)
            {
                Console.WriteLine("\t Alien Data " + ++count);
                Console.WriteLine("Name             : " + listtemp[0]);
                Console.WriteLine("Home Planet      :  " + listtemp[1]);
                Console.WriteLine("Blood Color      : " + listtemp[2]);
                Console.WriteLine("No of Antennas   : " + listtemp[3]);
                Console.WriteLine("No. of Legs      : " + listtemp[4]);
                System.Console.WriteLine();
            }
        }
    }



    class ExportFIle : RegisterAlien
    {

        public void Export(string Dllpath)
        {

            String Name = Path.GetFileName(Dllpath);
            Assembly ExportFile = Assembly.LoadFile(@Dllpath + "\\" + Name + ".dll");
            Type type = ExportFile.GetType(Name + "." + Name);
            if (type != null)
            {
                MethodInfo methodinfo = type.GetMethod("checkfile");
                if (methodinfo != null)
                {
                    ParameterInfo[] parameteres = methodinfo.GetParameters();
                    Object classInstance = Activator.CreateInstance(type, null);
                    if (parameteres.Length != 0)
                    {
                        System.Object[] param = new System.Object[] { AlienDB };
                        //param[0] = 2;
                        methodinfo.Invoke(classInstance, param);

                    }
                    else
                        Console.WriteLine("Error: Invalid Function Parameters!! Please Check ReadMe.txt file");

                }
                else
                    Console.WriteLine("Error: Invalid Function Name!! Please Check ReadMe.txt file");

            }
            else
                Console.WriteLine("Error: Invalid Package or Class Name!! Please Check ReadMe.txt file");
            
        }
    }



    class PluginInstall
    {
        String PluginPath, FileName, DirectoryName;

        public void AddPlugin()
        {
            System.Console.WriteLine("Please Give the Directory Path of your Plugin for Install:\n");
            PluginPath = Console.ReadLine();
            DirectoryName = Path.GetFileName(PluginPath);
            FileName = DirectoryName + ".dll";
         if (File.Exists(@PluginPath + @"\" + FileName))
            {
                try
                {
                    String[] listfiles = Directory.GetFiles(@PluginPath);

                    Directory.CreateDirectory(@Directory.GetCurrentDirectory() + "\\plugins\\" + DirectoryName);
                    foreach (String format in listfiles)
                    {
                        File.Copy(@PluginPath + "\\" + Path.GetFileName(format), @Directory.GetCurrentDirectory() + "\\plugins\\" + DirectoryName + "\\" + Path.GetFileName(format));
                    }
                    Console.WriteLine("\nSuccessfully Installed\n");


                }
                catch (Exception e)
                {
                    Console.WriteLine("\nError: Already a plugin exist with same Name try another name\n");
                    AddPlugin();
                }
            }
            else
            {
                System.Console.WriteLine("Error:File Dosen't Exisst Please check the path!!!\n");
                AddPlugin();
            }

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int check;
            System.Console.WriteLine("______Alien Registeration Software_______\n");
            System.Console.WriteLine("Choose:- (1/any key)Register Alien   (2)Add New Plugin\n");
            var status = Console.ReadLine();
            if (status.Equals("2"))
            {
                PluginInstall newobj = new PluginInstall();
                newobj.AddPlugin();
                Main(null);
            }
            else
            {
                RegisterAlien newobj = new RegisterAlien();
                newobj.RegAlien();
                newobj.DisplayRegAlien();
                //Directory.GetDirectories
                String[] listdirect = Directory.GetDirectories(@Directory.GetCurrentDirectory() + "\\plugins\\");
                int key = 0;
                System.Console.WriteLine("------ Available Export File Formats ------\n");
                foreach (String format in listdirect)
                {
                    System.Console.WriteLine("(" + key++ + ") " + Path.GetFileName(format));
                }
                System.Console.WriteLine("\nSelect a File Format\n");
                var selected = Console.ReadLine();



                while (!int.TryParse(selected, out check) || !(0 <= Int32.Parse(selected) && Int32.Parse(selected) < listdirect.Length))
                {
                    System.Console.WriteLine("Error:Not a valid Format!!! Please enter a Correct One\n");
                    selected = Console.ReadLine();
                }
                ExportFIle obj = new ExportFIle();
                obj.Export(listdirect[Int32.Parse(selected)]);

                System.Console.WriteLine("\n\nDo you want to Continue??  (y)yes   (n/any key)No");
                var temp = Console.ReadLine();
                if (temp.Equals("y") || temp.Equals("Y"))
                {
                    Main(null);
                }

            }

        }
    }
}