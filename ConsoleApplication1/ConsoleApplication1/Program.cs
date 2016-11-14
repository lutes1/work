using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApplication1
{
     class Program
     {
          Program() { }
          public string transform(string str , double multiply)
          {
               char delimiter = 'd';
               string[] substrings = str.Split(delimiter);
               double temp = Int32.Parse(substrings[0]);
               
               temp *= multiply;
               return temp.ToString() + "dp"; ;
          }
          public static void Main(string[] args)
          {
               string chosen = "";
               double multiply = 0;
               string[] destination = new string[2] { "C:\\Users\\PeterPan\\Documents\\Visual Studio 2015\\Projects\\TestApp\\TestApp\\TestApp\\Resources\\values-large\\dimen.xml",
                                                      "C:\\Users\\PeterPan\\Documents\\Visual Studio 2015\\Projects\\TestApp\\TestApp\\TestApp\\Resources\\values-xlarge\\dimen.xml"};  
               int option;
               Console.WriteLine("1->Large\t\t 2->x-Large");
               option = Console.Read();
               if(option == 49)
               {
                    multiply = 1.57;
                    chosen = destination[0];
               }else if(option == 50)
               {
                    multiply = 2.1;
                    chosen = destination[1];
               }
               Program program = new Program();
               XDocument xdoc = XDocument.Load("C:\\Users\\PeterPan\\Documents\\Visual Studio 2015\\Projects\\TestApp\\TestApp\\TestApp\\Resources\\values\\dimen.xml");
               xdoc.Descendants("dimen").Select(p => new
               {
                    size = p.Value = program.transform(p.Value , multiply)

               }).ToList().ForEach(p =>
               {
                    Console.WriteLine(p.size);
               });
               xdoc.Save(chosen);
               Console.Read();               
          }
          
      }
}
