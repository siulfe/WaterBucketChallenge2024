using System;
using System.Collections.Generic;
using WaterBucketChallenge.Enum;
using WaterBucketChallenge.Models;

namespace WaterBucketChallenge.Service
{
    internal class TestService
    {
        public TestResult Test(uint X, uint Y,uint Z, bool applyBadPath = false)
        {
            if(!validateParams(X,Y,Z)) return null;

            TestResult resp = new TestResult();

            resp.good = getProcesses(X, Y, Z, true);

            if(applyBadPath)
                resp.bad = getProcesses(X, Y, Z, false);

            return resp;
        }

        private Process[] getProcesses(uint X, uint Y, uint Z, bool goodPath)
        {
            Process[] resp = new Process[] { };

            switch (getPath(X,Y,Z,goodPath))
            {
                case PathEnum.SUBTRACT:
                    resp = subtract(X, Y, Z);
                    break;
                case PathEnum.ADD:
                    resp = add(X, Y, Z);
                    break;
            }

            return resp;
        }

        private PathEnum getPath(uint X, uint Y, uint Z, bool goodPath)
        {
            uint max = Math.Max(X, Y);
            uint min = Math.Min(X, Y);

            if (isRestable(X, Y, Z))
            {
                if (isSumable(X, Y, Z) && 
                    (
                        (goodPath && (Z <= Math.Round((decimal)max / 2) || (max % min != 0 || Z % min != 0) ) ) ||
                        (!goodPath && Z >= Math.Round((decimal)max / 2))
                    ))
                    return PathEnum.ADD;

                return PathEnum.SUBTRACT;
            }

            return PathEnum.ADD;
        }

        private Process[] subtract(uint X, uint Y, uint Z)
        {
            List<Process> resp = new List<Process>();

            Bucket minuend = new Bucket(Math.Max(X,Y), Math.Max(X, Y) == X ? "X" : "Y");
            Bucket subtracting = new Bucket(Math.Min(X, Y), Math.Min(X, Y) == Y ? "Y": "X");

            while (true)
            {
                if (minuend.gallons == Z)
                {
                    resp[resp.Count -1].explanation += ". Solved";
                    return resp.ToArray();
                }

                if (minuend.gallons == 0)
                {
                    minuend.Fill();

                    resp.Add(new Process(minuend, subtracting, $"Fill bucket {minuend.label}"));
                    continue;
                }

                if(subtracting.gallons == subtracting.capacity)
                {
                    subtracting.Empty();

                    resp.Add(new Process(minuend, subtracting, $"Empty bucket {subtracting.label}"));
                }

                minuend.Transfer(subtracting);

                resp.Add(new Process(minuend, subtracting, $"Transfer from bucket {minuend.label} to bucket {subtracting.label}"));
            }
        }

        private Process[] add(uint X, uint Y, uint Z)
        {
            List<Process> resp = new List<Process>();

            Bucket addends1 = new Bucket(Math.Min(X, Y), Math.Min(X, Y) == X ? "X" : "Y");
            Bucket addends2 = new Bucket(Math.Max(X, Y), Math.Max(X, Y) == Y ? "Y" : "X");
            
            if (addends2.capacity == Z)
            {
                addends2.Fill();
                resp.Add(new Process(addends1, addends2, $"Fill bucket {addends2.label}. Solved"));
                
                return resp.ToArray();
                
            }
            
            while (true)
            {
                if (addends2.gallons == Z)
                {
                    resp[resp.Count - 1].explanation += ". Solved";
                    return resp.ToArray();
                }

                if (addends1.gallons == 0)
                {
                    addends1.Fill();

                    resp.Add(new Process(addends1, addends2, $"Fill bucket {addends1.label}"));
                }

                if (addends1.gallons == Z)
                {
                    resp[resp.Count - 1].explanation += ". Solved";
                    return resp.ToArray();
                }

                addends1.Transfer(addends2);

                resp.Add(new Process(addends1, addends2, $"Transfer from bucket {addends1.label} to bucket {addends2.label}"));
            }
        }

        private bool validateParams(uint X, uint Y, uint Z)
        {
            if (X == 0 || Y == 0 || Z == 0) return false;

            if (X < Z && Y < Z) return false;

            return isRestable(X, Y, Z) || isSumable(X, Y, Z);
        }
        
        private bool isRestable(uint X, uint Y, uint Z)
        {
            return X % Y == Z || Y % X == Z || (X < Z && Z % X == 0) || (Y < Z && Z % Y == 0);
        }
        
        private bool isSumable(uint X, uint Y, uint Z)
        {
            return Z % X == 0 || Z % Y == 0;
        }
    }
}
