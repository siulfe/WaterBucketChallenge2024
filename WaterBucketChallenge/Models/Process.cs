namespace WaterBucketChallenge.Models
{
    public class Process
    {
        public uint X { get; set; }
        public uint Y { get; set; }
        public string explanation { get; set; }

        public Process(Bucket a, Bucket b, string explanation)
        {
            X = a.label == "X" ? a.gallons: b.gallons;
            Y = a.label == "Y" ? a.gallons: b.gallons;
            this.explanation = explanation;
        }
    }
}
