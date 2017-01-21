namespace Wave.StageReady
{
    using UnityEngine;
    using UnityEngine.Events;

    using Wave.Levels;

    public class StageReadyBehaviour : MonoBehaviour
    {
        public UnityEvent LevelLoaded;

        public LevelSystem LevelSystem;

        public void StartLevel()
        {
            if (this.LevelSystem != null)
            {
                this.LevelSystem.StartLevel();
            }
        }

        private void OnDisable()
        {
            this.LevelSystem.LevelLoaded -= this.OnLevelLoaded;
        }

        private void OnEnable()
        {
            this.LevelSystem = FindObjectOfType<LevelSystem>();
            this.LevelSystem.LevelLoaded += this.OnLevelLoaded;
        }

        private void OnLevelLoaded()
        {
            this.LevelLoaded.Invoke();
        }
        
    }
}