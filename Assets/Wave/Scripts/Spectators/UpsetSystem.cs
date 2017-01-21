namespace Wave.Spectators
{
    using System.Linq;

    using UnityEngine;

    using Wave.Levels;

    public class UpsetSystem : MonoBehaviour
    {
        public LevelSystem LevelSystem;

        public SpectatorSystem SpectatorSystem;

        private float nextUpsetDuration;

        private void MakeSpectatorUpset()
        {
            if (this.SpectatorSystem.Spectators == null)
            {
                return;
            }

            // Choose not upset spectator.
            var happySpectators = this.SpectatorSystem.Spectators.FindAll(spectator => !spectator.IsUpset && !spectator.IsPursuading).ToList();
            if (happySpectators.Count == 0)
            {
                return;
            }

            var happySpectator = happySpectators[Random.Range(0, happySpectators.Count - 1)];

            // Make upset.
            happySpectator.MakeUpset();
        }

        private void Reset()
        {
            if (this.SpectatorSystem == null)
            {
                this.SpectatorSystem = FindObjectOfType<SpectatorSystem>();
            }
            if (this.LevelSystem == null)
            {
                this.LevelSystem = FindObjectOfType<LevelSystem>();
            }
        }

        private void Update()
        {
            if (!this.LevelSystem.IsLevelRunning)
            {
                return;
            }

            this.nextUpsetDuration -= Time.deltaTime;
            if (this.nextUpsetDuration <= 0)
            {
                this.MakeSpectatorUpset();

                // Determine duration till next upset.
                this.nextUpsetDuration = this.LevelSystem.CurrentConfiguration.UpsetSpectatorsInterval;
            }
        }
    }
}