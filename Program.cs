using System;
using System.IO;

namespace ConsoleApplication
{
    public class Program
    {
        private const string svnroot = "/Users/yuta/Development/svn";
        private const string targetroot = "/Users/yuta/Desktop";
        private const string separator = "/";
        
        public static void Main(string[] args)
        {
            string src = args[0].ToString();
            
            // Genarate src path
            string srcpath = String.Empty;
            // if (src.Substring(1, 2) != @":\")
            if (src.Substring(0, 1) != @"/")
                srcpath = Directory.GetCurrentDirectory() + separator + src;
            else
                srcpath = src;
                
            // Guard not svn control file
            if (!srcpath.Contains(svnroot))
            {
                Console.WriteLine("this file is not svn.");
                return;
            }
            
            // Get svn dir
            string mkdir = srcpath.Replace(svnroot, String.Empty);
            
            // Get file name
            var srcArray = src.Split('/');
            string filename = srcArray[srcArray.Length - 1];

            // Get target file path
            string targetFpath = targetroot + mkdir;
            string targetpath = targetFpath.Replace(filename, String.Empty);
            
            // If not exists folder then create folder and copy
            if (!Directory.Exists(targetpath))
                Directory.CreateDirectory(targetpath);
            File.Copy(srcpath, targetFpath, true);
            
            Console.WriteLine($"filename: {filename}");
            Console.WriteLine($"mkdir: {mkdir}");
            Console.WriteLine($"src: {srcpath}");
            Console.WriteLine($"target: {targetFpath}");
        }
    }
}
