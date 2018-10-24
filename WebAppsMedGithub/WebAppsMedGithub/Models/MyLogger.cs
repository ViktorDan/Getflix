using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAppsMedGithub.Models
{
    public class MyLogger
    {
        public void Log(string component, string message)
        {
            Console.WriteLine("Component: {0} Message: {1} ", component, message);
        }

        static async void WriteCharacters()
        {
            using (System.IO.StreamWriter writer = File.CreateText("newfile.txt"))
            {
                await writer.WriteLineAsync("First line of example");
                await writer.WriteLineAsync("and second line");
            }
        }
    }
}