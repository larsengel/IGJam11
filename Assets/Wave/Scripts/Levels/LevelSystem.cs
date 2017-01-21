namespace Wave.Levels
{
    using System;

    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class LevelSystem : MonoBehaviour
    {
        private LevelBehaviour currentLevel;

        public LevelConfiguration CurrentConfiguration
        {
            get
            {
                return this.currentLevel != null ? this.currentLevel.Configuration : null;
            }
        }

        public event Action LevelStarted;

        protected virtual void OnLevelStarted()
        {
            var handler = this.LevelStarted;
            if (handler != null)
            {
                handler();
            }
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= this.OnSceneLoaded;
        }

        private void OnEnable()
        {
            this.currentLevel = FindObjectOfType<LevelBehaviour>();
            SceneManager.sceneLoaded += this.OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            var newLevel = FindObjectOfType<LevelBehaviour>();
            if (newLevel != this.currentLevel)
            {
                this.currentLevel = newLevel;
                this.OnLevelStarted();
            }
        }
    }
}