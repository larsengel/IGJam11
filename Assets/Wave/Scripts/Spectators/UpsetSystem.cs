namespace Wave.Spectators
{
    using System.Linq;

    using UnityEngine;

    public class UpsetSystem : MonoBehaviour
    {
        public SpectatorSystem SpectatorSystem;

        /// <summary>
        ///   Number of spectators to make upset (per second).
        /// </summary>
        [Tooltip("Number of spectators to make upset (per second)")]
        public float UpsetSpectatorsFrequency = 1;

        private float nextUpsetDuration;

        private void MakeSpectatorUpset()
        {
            // Choose not upset spectator.
            var happySpectators = this.SpectatorSystem.Spectators.FindAll(spectator => !spectator.IsUpset).ToList();
            if (happySpectators.Count == 0)
            {
                return;
            }

            var happySpectator = happySpectators[Random.Range(0, happySpectators.Count - 1)];

            // Make upset.
            happySpectator.MakeUpset();
        }

        private void Update()
        {
            this.nextUpsetDuration -= Time.deltaTime;
            if (this.nextUpsetDuration <= 0)
            {
                this.MakeSpectatorUpset();

                // Determine duration till next upset.
                this.nextUpsetDuration = 1 / this.UpsetSpectatorsFrequency;
            }
        }
    }
}