namespace Wave.Levels
{
    using System;

    using UnityEngine;

    public class VictorySystem : MonoBehaviour
    {
        public LevelSystem LevelSystem;

        private float levelOverTime = float.MaxValue;

        private Main main;

        public float RemainingDuration
        {
            get
            {
                return Math.Max(0, this.levelOverTime - Time.time);
            }
        }

        public event Action LevelWon;

        [ContextMenu("Win Level")]
        protected virtual void OnLevelWon()
        {
            if (this.main != null)
            {
                this.main.SwitchState(GameStates.LEVEL_WON);
            }

            this.levelOverTime = float.MaxValue;

            var handler = this.LevelWon;
            if (handler != null)
            {
                handler();
            }
        }

        private void OnEnable()
        {
            this.LevelSystem.LevelStarted += this.OnLevelStarted;
            this.LevelSystem.LevelFinished += this.OnLevelFinished;
            this.main = FindObjectOfType<Main>();
        }

        private void OnLevelFinished()
        {
            this.levelOverTime = float.MaxValue;
        }

        private void OnLevelStarted()
        {
            // Check when level is finished.
            this.levelOverTime = Time.time + this.LevelSystem.CurrentConfiguration.Duration;
        }

        private void Reset()
        {
            if (this.LevelSystem == null)
            {
                this.LevelSystem = FindObjectOfType<LevelSystem>();
            }
        }

        private void Update()
        {
            if (this.levelOverTime < Time.time)
            {
                this.OnLevelWon();
            }
        }
    }
}