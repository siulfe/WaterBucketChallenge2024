using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterBucketChallenge.Models
{
    public class TestResult
    {
        public Process[] good { get; set; }
        public Process[] bad { get; set; }

        public TestResult() { }

        public TestResult(Process[] good, Process[] bad)
        {
            this.good = good;
            this.bad = bad;
        }
    }
}
