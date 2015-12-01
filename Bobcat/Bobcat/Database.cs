using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bobcat
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

        public void addSubmission(string json)
        {

        }
        public void Grade(string json, int assignmentID)
        {
            List<Columns> solutionsColumns = getSolutions(assignmentID);
            List<Columns> submissionColumns = getSubmissionColumns(json);
            List<Tuple<int, int>> differences = new List<Tuple<int, int>>();

            int match;
            int bestMatchIndex = -1;

            for(int i = 0; i < solutionsColumns.Count; i++)
            {
                match = 0;
                for(int k = 0; k < submissionColumns.Count; k++)
                {
                    if (solutionsColumns[i].id == submissionColumns[k].id)
                    {
                        ++match;
                    }
                    
                }
                if(match == submissionColumns.Count)
                {
                    bestMatchIndex = i;
                }
                else
                {
                    differences.Add(new Tuple<int, int>(i, (Math.Abs(solutionsColumns.Count - match)+Math.Abs(submissionColumns.Count - solutionsColumns.Count))));
                }
                
            }
            if(bestMatchIndex == -1)
            {
                bestMatchIndex = findClosestMatch(differences);
            }
        }
        public List<Columns> getSolutions(int assignmentID)
        {
            return null;
        }
        public List<Columns> getSubmissionColumns(string json)
        {
            return null;
        }
        public int findClosestMatch(List<Tuple<int, int>> differences)
        {
            int closestDifference = Int32.MaxValue;
            int closestIndex = -1;
            foreach(Tuple<int, int> t in differences)
            {
                if(t.Item2 < closestDifference)
                {
                    closestDifference = t.Item2;
                    closestIndex = t.Item1;
                }
            }
            return closestIndex;
        }
    }


}
