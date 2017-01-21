namespace Wave.Spectators
{
    using System.Collections.Generic;
    using System.Linq;

    using UnityEngine;

    using Wave.Levels;

    public class SpectatorSystem : MonoBehaviour
    {
        public LevelSystem LevelSystem;

        public List<Spectator> Spectators;

        [ContextMenu("Find Spectators")]
        private void FindSpectators()
        {
            this.Spectators = FindObjectsOfType<Spectator>().ToList();
        }

        private void OnDisable()
        {
            this.LevelSystem.LevelStarted -= this.OnLevelStarted;
            this.LevelSystem.LevelFinished -= this.OnLevelFinished;
        }

        private void OnEnable()
        {
            this.LevelSystem.LevelStarted += this.OnLevelStarted;
            this.LevelSystem.LevelFinished += this.OnLevelFinished;
        }

        private void OnLevelFinished()
        {
            this.Spectators = null;
        }

        private void OnLevelStarted()
        {
            this.FindSpectators();
        }
    }
}