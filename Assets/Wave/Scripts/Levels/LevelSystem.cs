namespace Wave.Levels
{
    using System;

    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class LevelSystem : MonoBehaviour
    {
        private LevelConfiguration currentConfiguration;

        private Main main;

        public LevelConfiguration CurrentConfiguration
        {
            get
            {
                return this.currentConfiguration;
            }
            private set
            {
                if (value == this.currentConfiguration)
                {
                    return;
                }
                this.currentConfiguration = value;

                this.OnLevelStarted();
            }
        }

        public event Action LevelStarted;

        public void StartNextLevel()
        {
            var newLevel = GameStates.LEVEL1;
            if (this.CurrentConfiguration != null)
            {
                newLevel = this.CurrentConfiguration.NextLevelId;
            }

            this.main.SwitchState(newLevel != GameStates.NONE ? newLevel : GameStates.GAME_FINISHED);
        }

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
            var currentLevel = FindObjectOfType<LevelBehaviour>();
            this.CurrentConfiguration = currentLevel != null ? currentLevel.Configuration : null;
            SceneManager.sceneLoaded += this.OnSceneLoaded;

            this.main = FindObjectOfType<Main>();
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            var newLevel = FindObjectOfType<LevelBehaviour>();
            var newLevelConfiguration = newLevel != null ? newLevel.Configuration : null;
            this.CurrentConfiguration = newLevelConfiguration;
        }
    }
}