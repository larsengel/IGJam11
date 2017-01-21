namespace Wave.Levels
{
    using System;
    using System.Collections;

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

                if (this.currentConfiguration != null)
                {
                    StartCoroutine(DelayLevelStarted());
                }
            }
        }

        private IEnumerator DelayLevelStarted()
        {
            yield return new WaitForEndOfFrame();

            this.IsLevelRunning = true;
            this.OnLevelStarted();
        }

        public bool IsLevelRunning { get; private set; }

        public event Action LevelFinished;

        public event Action LevelStarted;

        public void RestartLevel()
        {
            var loadLevel = GameStates.LEVEL1;
            if (this.CurrentConfiguration != null)
            {
                loadLevel = this.CurrentConfiguration.LevelId;
            }

            this.main.SwitchState(loadLevel != GameStates.NONE ? loadLevel : GameStates.LEVEL1);
        }

        public void StartNextLevel()
        {
            var newLevel = GameStates.LEVEL1;
            if (this.CurrentConfiguration != null)
            {
                newLevel = this.CurrentConfiguration.NextLevelId;
            }

            this.main.SwitchState(newLevel != GameStates.NONE ? newLevel : GameStates.GAME_FINISHED);
        }

        protected virtual void OnLevelFinished()
        {
            var handler = this.LevelFinished;
            if (handler != null)
            {
                handler();
            }
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
            SceneManager.sceneUnloaded -= this.OnSceneUnloaded;
        }

        private void OnEnable()
        {
            var currentLevel = FindObjectOfType<LevelBehaviour>();
            this.CurrentConfiguration = currentLevel != null ? currentLevel.Configuration : null;
            SceneManager.sceneLoaded += this.OnSceneLoaded;
            SceneManager.sceneUnloaded += this.OnSceneUnloaded;

            this.main = FindObjectOfType<Main>();
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            var newLevel = FindObjectOfType<LevelBehaviour>();
            var newLevelConfiguration = newLevel != null ? newLevel.Configuration : null;
            this.CurrentConfiguration = newLevelConfiguration;
        }

        private void OnSceneUnloaded(Scene arg0)
        {
            var newLevel = FindObjectOfType<LevelBehaviour>();
            var newLevelConfiguration = newLevel != null ? newLevel.Configuration : null;
            if (this.CurrentConfiguration != newLevelConfiguration)
            {
                this.OnLevelFinished();
                this.IsLevelRunning = false;
            }
        }
    }
}