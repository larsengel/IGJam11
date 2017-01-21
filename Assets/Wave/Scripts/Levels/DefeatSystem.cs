namespace Wave.Levels
{
    using UnityEngine;

    public class DefeatSystem : MonoBehaviour
    {
        public LevelSystem LevelSystem;

        public string LevelDefeatScene = "LevelDefeat";

        private void Reset()
        {
            if (this.LevelSystem == null)
            {
                this.LevelSystem = FindObjectOfType<LevelSystem>();
            }
        }
    }
}