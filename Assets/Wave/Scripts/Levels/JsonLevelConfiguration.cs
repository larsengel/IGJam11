namespace Wave.Levels
{
    public struct JsonLevelConfiguration
    {
        public string LevelId;
        public string NextLevelId;

        public int Rows;
        public int SeatsPerRow;
        public float EmptySeatsFactor;

        public float ShowSignFactor;
        public float Duration;
        public float MaxLittleWaveDuration;
        public float PersuadeDuration;
        public float UpsetSpectatorsInterval;
    }
}