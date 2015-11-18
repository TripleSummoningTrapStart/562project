using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadInSoutions
{
    public class Solution
    {
        public int assignmentId
        { get; set; }

        public string json
        {get; set;}
        public int percentage
        { get; set; }

        public Solution(int percentage, string json, int assnId)
        {
            assignmentId = assnId;
            this.json = json;
            this.percentage = percentage;
        }
    }
}
