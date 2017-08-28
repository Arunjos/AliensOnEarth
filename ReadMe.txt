-> Done this project as part of my assignment

->Here I am take c#.net as my programming language and Visual Studio 2010 as IDE.

->The Project has 2 parts:
 *) 'Alien_on_earth' :- which control all the actions of Alien 	Registerstion Process.It contains classes for installing plugin,Insert Aliens Details,Display details,Export as files

 *)'Plugins':-It contains 2 plugins one for exporting data as text file and other for exporting data as pdf file. 

->'Plugins' Should follow the following rules:

1)Plugin projects must be CLASS LIBRARY projects of visual studio which generate .dll assemblies.	

2)The Name of PLUGIN FOLDER,PLUGIN DLL FILE,NAMESPACE and CLASS must be same.

3)The Class must have a starting Function which shown as below

namespace export_as_pdf //(must be same as plugin FOLDER NAME)
{
    public class export_as_pdf //(must be same as plugin FOLDER NAME)
    {
        
   public static bool checkfile(List<List<string>> AlienDB)
        {
          //Here Your code can be start
        }   

    }
}

4)The parameter is a multidimensional list(Here 'AlienDB') which contains the registered data of Aliens.Below code will give you a clear idea about how it can parse.


	foreach (var listtemp in AlienDB)
            {
		  Console.WriteLine("\t Alien Data "+ ++count);
                Console.WriteLine("Name             : " + listtemp[0]);
                Console.WriteLine("Home Planet      : " + listtemp[1]);
                Console.WriteLine("Blood Color      : " + listtemp[2]);
                Console.WriteLine("No of Antennas   : " + listtemp[3]);
                Console.WriteLine("No. of Legs      : " + listtemp[4]);
            }

->Thats all about my code you will get a clear idea after the first run

/********************A PROBLEM*********************************/
"In my code I am failed to dynamically add supporting .dll files(pdfsharp files) of my plugin (export_as_pdf).So I resolved it by adding those files directly to project.Kindly give me a good solution for this problem after the evaluvation THANK UU"