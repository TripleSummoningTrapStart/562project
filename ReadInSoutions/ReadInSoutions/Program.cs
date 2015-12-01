using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using Npgsql;



namespace ReadInSoutions
{
    class Program
    {
        
        static void Main(string[] args)
        {

            string input = File.ReadAllLines(@"E:\School\Senior Semester 1\CIS 562\562project\jsonText.txt")[0];
            input = input.Substring(1, input.Length - 2);
            functions f = new functions();
            int grade = f.addSubmission(input);
            //f.CloseConnections();
            Console.WriteLine("Your Grade is: "+ grade + "\r\nDone");
            Console.ReadLine();
        }
    }
}
