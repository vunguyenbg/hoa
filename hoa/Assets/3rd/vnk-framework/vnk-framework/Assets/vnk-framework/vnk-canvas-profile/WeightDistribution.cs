namespace Yoolax.Framework
{
    public class WeightDistribution
    {
        private float _min;
        private float _max;
        private float _weight;

        public float Min { get { return _min; } }
        public float Max { get { return _max; } }
        public float Weight { set { _weight = value; } get { return _weight; } }

        public WeightDistribution(float from, float to, float weight)
        {
            _min = from;
            _max = to;
            _weight = weight;
        }
    }
}