using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace ReadInSoutions
{
    public class Columns
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool? nn { get; set; }
    }

    public class Database
    {
        public string name { get; set; }
        public List<int> pos { get; set; }
        public List<List<string>> uq { get; set; }
        public List<Columns> cols { get; set; }
    }
    public class SolutionDatabase
    {
        public Database database { get; set; }
        public int grade { get; set; }
        public int solId { get; set; }

        public SolutionDatabase(Database d, int g, int s)
        {
            database = d;
            grade = g;
            solId = s;
        }
    }
    public class functions
    {
        NpgsqlConnection conn;

        public functions()
        {
            conn = new NpgsqlConnection("Host=127.0.0.1;Port=5432;Username=postgres;Password=hello;Database=562Project");
        
        }
        public int addSubmission(string json)
        {
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("addSubmission", conn);
            command.CommandType = CommandType.StoredProcedure;

            var parameter = command.CreateParameter();
            parameter.ParameterName = "AssignmentId";
            parameter.DbType = System.Data.DbType.Int32;
            parameter.Value = 2;
            command.Parameters.Add(parameter);

            var parameter2 = command.CreateParameter();
            parameter2.ParameterName = "StudentId";
            parameter2.DbType = System.Data.DbType.Int32;
            parameter2.Value = 1;
            command.Parameters.Add(parameter2);

            var parameter3 = command.CreateParameter();
            parameter3.ParameterName = "JSonString";
            parameter3.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            //parameter3.DbType = System.Data.DbType.AnsiString;
            parameter3.Value = json;
            command.Parameters.Add(parameter3);
            command.ExecuteNonQuery();
            conn.Close();
            return Grade(json, 2);
        }
        public int Grade(string json, int assignmentID)
        {
            List<SolutionDatabase> solutions = getSolutions(assignmentID);
            List<Columns> submissionColumns = getSubmissionColumns(json);
            List<Tuple<int, int>> differences = new List<Tuple<int, int>>();

            int match;
            int bestMatchIndex = -1;
            int currentIndex;

            for(int m = 0; m < solutions.Count; m++)
            {
                match = 0;
                for (int i = 0; i < solutions[m].database.cols.Count; i++)
                {
                    
                    for (int k = 0; k < submissionColumns.Count; k++)
                    {
                        if (solutions[m].database.cols[i].id == submissionColumns[k].id)
                        {
                            match++;
                        }

                    }
                }
                if (match == solutions[m].database.cols.Count && match == submissionColumns.Count)
                {
                    bestMatchIndex = m;
                }
                else
                {
                    differences.Add(new Tuple<int, int>(m, (Math.Abs(solutions[m].database.cols.Count - match) + Math.Abs(submissionColumns.Count - solutions[m].database.cols.Count))));
                }
              
            }
           
            if (bestMatchIndex == -1)
            {
                bestMatchIndex = findClosestMatch(differences);
            }
            addGrade(bestMatchIndex, solutions[bestMatchIndex]);
            return solutions[bestMatchIndex].grade;
        }
        public void addGrade(int index, SolutionDatabase s)
        {
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("addGrade", conn);
            command.CommandType = CommandType.StoredProcedure;

            var parameter = command.CreateParameter();
            parameter.ParameterName = "Graded_Against_SolutionId";
            parameter.DbType = System.Data.DbType.Int32;
            parameter.Value = s.solId;
            command.Parameters.Add(parameter);

            var parameter2 = command.CreateParameter();
            parameter2.ParameterName = "SubmissionId";
            parameter2.DbType = System.Data.DbType.Int32;
            parameter2.Value = 1;
            command.Parameters.Add(parameter2);

            var parameter3 = command.CreateParameter();
            parameter3.ParameterName = "Grade";
            parameter3.DbType = System.Data.DbType.Int32;
            parameter3.Value = s.grade;
            command.Parameters.Add(parameter3);

            var parameter4 = command.CreateParameter();
            parameter4.ParameterName = "GradeComments";
            parameter4.DbType = System.Data.DbType.AnsiString;
            parameter4.Value = string.Empty;
            command.Parameters.Add(parameter4);
            command.ExecuteNonQuery();
            conn.Close();
        }
        public List<SolutionDatabase> getSolutions(int assignmentID)
        {
            conn.Open();
            List<SolutionDatabase> solutions = new List<SolutionDatabase>();
            NpgsqlCommand command = new NpgsqlCommand("getSolution", conn);
            command.CommandType = CommandType.StoredProcedure;

            var parameter = command.CreateParameter();
            parameter.ParameterName = "AssnId";
            parameter.DbType = System.Data.DbType.Int32;
            parameter.Value = assignmentID;
            command.Parameters.Add(parameter);

            //NpgsqlCommand command = new NpgsqlCommand("select * from solutions s where s.AssignmentId = " + assignmentID, conn);

            NpgsqlDataReader dr = command.ExecuteReader();


            while (dr.Read())
            {
                string check = dr[2].ToString();
                Database d = JsonConvert.DeserializeObject<Database>(dr[2].ToString());
                solutions.Add(new SolutionDatabase(d, (int)dr[1], (int)dr[0]));
            }


            conn.Close();
            return solutions;
        }
        public List<Columns> getSubmissionColumns(string json)
        {
            Database d = JsonConvert.DeserializeObject<Database>(json);
            return d.cols;
        }
        public int findClosestMatch(List<Tuple<int, int>> differences)
        {
            int closestDifference = Int32.MaxValue;
            int closestIndex = -1;
            foreach (Tuple<int, int> t in differences)
            {
                if (t.Item2 < closestDifference)
                {
                    closestDifference = t.Item2;
                    closestIndex = t.Item1;
                }
            }
            return closestIndex;
        }
        public void addSolutions()
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


            foreach (Solution s in solutions)
            {

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
                command.ExecuteNonQuery();

            }
        }
        public void CloseConnections()
        {
            conn.Close();
        }
    }


}
