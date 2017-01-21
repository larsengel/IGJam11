namespace Wave.Levels
{
    using UnityEngine;

    public class UILevelDefeat : MonoBehaviour
    {
        private LevelSystem levelSystem;

        public void RestartLevel()
        {
            if (this.levelSystem != null)
            {
                this.levelSystem.RestartLevel();
            }
        }

        private void Start()
        {
            this.levelSystem = FindObjectOfType<LevelSystem>();
        }
    }
}