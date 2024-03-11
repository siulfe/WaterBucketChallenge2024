
namespace WaterBucketChallenge.Models.Interface
{
    public interface IBucket
    {
        void Fill();
        void Empty();
        void Transfer(Bucket bucket);
    }
}
