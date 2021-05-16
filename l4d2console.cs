using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;


namespace L4D2MapExtractor
{
    class Program
    {
        //public static class ZipFile
       
        static void Main(string[] args)
        {
            Console.Title = "L4D2MapExtractor";
            //MessageBox.Show("File has been extracted to path: {0}");
            Console.Write("Append file to console!:>");
            string zipFilePath = Console.ReadLine();
            Console.WriteLine("Current file path {0}", zipFilePath);
            string extractPath = @"E:\SteamLibrary\steamapps\common\Left 4 Dead 2\left4dead2\addons\";
            


            if (Path.GetExtension(zipFilePath).Equals(".zip"))
            {
                //Console.WriteLine("HasExtension('{0}') returns {1}", zipFilePath, result);
                ZipFile.ExtractToDirectory(zipFilePath, extractPath);
                //Console.WriteLine("File has been extracted to path: {0}", extractPath);
                MessageBox.Show("File has been extracted to path:" + extractPath);
                //gamemaps_com.txt
                File.Delete(@"E:\SteamLibrary\steamapps\common\Left 4 Dead 2\left4dead2\addons\gamemaps_com.txt");


            }
            else
            {
                Console.WriteLine("The extension doesn't have a .zip!");
            }

            

            Console.WriteLine("");
            Console.Write("Do you wanna quit?:>");
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("Quitting program");
                Environment.Exit(0);
            }
            else { Console.WriteLine("no"); }
            Console.ReadLine();
            
        }
    }
}
