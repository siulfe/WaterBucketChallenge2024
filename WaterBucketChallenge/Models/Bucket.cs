using WaterBucketChallenge.Models.Interface;

namespace WaterBucketChallenge.Models
{
    public class Bucket : IBucket
    {
        private uint _gallons { get;  set; }
        private uint _capacity { get; set; }

        private string _label { get; set; }

        public uint capacity { get => _capacity; }
        public uint gallons { get => _gallons; }
        public string label { get => _label; }

        public Bucket(uint capacity, string label)
        {
            _capacity = capacity;
            _label = label;
        }

        public void Empty()
        {
            _gallons = 0;
        }

        public void Fill()
        {
            _gallons = capacity;
        }

        public void Transfer(Bucket bucket)
        {
            uint gallonsTransfer = bucket.capacity - bucket.gallons;

            if (gallonsTransfer > gallons) gallonsTransfer = gallons;

            bucket._gallons += gallonsTransfer;

            _gallons -= gallonsTransfer;
        }
    }
}
