namespace Wave.Levels
{
    using UnityEngine;

    public class UILevelWon : MonoBehaviour
    {
        private LevelSystem levelSystem;

        private void Start()
        {
            this.levelSystem = FindObjectOfType<LevelSystem>();
        }

        public void GoToNextLevel()
        {
            this.levelSystem.StartNextLevel();
        }
    }
}