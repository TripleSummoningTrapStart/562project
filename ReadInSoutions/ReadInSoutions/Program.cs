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
            List<Solution> solutions = new List<Solution>();
            string[] lines = File.ReadAllLines(@"E:\School\Senior Semester 1\CIS 562\562project\Solutions.txt");
            int assignmentID = Convert.ToInt32(lines[0]);
            int num = 1;
            foreach (string s in lines)
            {
                if (num == 1)
                {
                    num++;
                }
                else
                {
                    string[] split = s.Split('|');
                    int percentage = Convert.ToInt32(split[0]);
                    string json = split[1];
                    solutions.Add(new Solution(percentage, json, assignmentID));
                }
            }

            var conn = new NpgsqlConnection("Host=127.0.0.1;Port=5432;Username=postgres;Password=hello;Database=562Project");
            
                conn.Open();

                foreach (Solution s in solutions)
                {
                    //NpgsqlTransaction tran = conn.BeginTransaction();

                    NpgsqlCommand command = new NpgsqlCommand("addSolution", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "percentage";
                    parameter.DbType = System.Data.DbType.Int32;
                    parameter.Value = s.percentage;
                    command.Parameters.Add(parameter);

                    var parameter2 = command.CreateParameter();
                    parameter2.ParameterName = "jsonString";
                    parameter2.DbType = System.Data.DbType.AnsiString;
                    parameter2.Value = s.json;
                    command.Parameters.Add(parameter2);

                    var parameter3 = command.CreateParameter();
                    parameter3.ParameterName = "AssnId";
                    parameter3.DbType = System.Data.DbType.Int32;
                    parameter3.Value = s.assignmentId;
                    command.Parameters.Add(parameter3);
                   // tran.Commit();
                    command.ExecuteNonQuery();

                }               
                conn.Close();
                Console.WriteLine("Done");
                Console.ReadLine();
        }
    }
}
