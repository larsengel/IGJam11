namespace Wave.Levels
{
    using System;

    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class LevelSystem : MonoBehaviour
    {
        public enum LevelState
        {
            None,

            Loaded,

            Running,

            Finished
        }

        private Main main;

        public LevelConfiguration CurrentConfiguration { get; private set; }

        public LevelState CurrentLevelState { get; private set; }

        public bool IsLevelRunning
        {
            get
            {
                return this.CurrentLevelState == LevelState.Running;
            }
        }

        public event Action LevelFinished;

        public event Action LevelLoaded;

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

        public void StartLevel()
        {
            switch (this.CurrentLevelState)
            {
                case LevelState.Loaded:
                    this.CurrentLevelState = LevelState.Running;
                    this.OnLevelStarted();
                    break;
                default:
                    Debug.LogWarningFormat("Invalid state to start level: {0}", this.CurrentLevelState);
                    break;
            }
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

        protected virtual void OnLevelLoaded()
        {
            var handler = this.LevelLoaded;
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

            if (newLevelConfiguration != this.CurrentConfiguration)
            {
                this.CurrentConfiguration = newLevelConfiguration;
                if (newLevelConfiguration != null)
                {
                    this.CurrentLevelState = LevelState.Loaded;
                    this.OnLevelLoaded();
                }
            }
        }

        private void OnSceneUnloaded(Scene arg0)
        {
            var newLevel = FindObjectOfType<LevelBehaviour>();
            var newLevelConfiguration = newLevel != null ? newLevel.Configuration : null;
            if (this.CurrentConfiguration != newLevelConfiguration)
            {
                this.CurrentLevelState = LevelState.Finished;
                this.OnLevelFinished();

                this.CurrentConfiguration = newLevelConfiguration;

                if (this.CurrentConfiguration != null)
                {
                    this.CurrentLevelState = LevelState.Loaded;
                    this.OnLevelLoaded();
                }
            }
        }
    }
}