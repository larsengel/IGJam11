namespace Wave.Spectators
{
    using System.Linq;

    using UnityEngine;

    public class UpsetSystem : MonoBehaviour
    {
        public SpectatorSystem SpectatorSystem;

        /// <summary>
        ///   Duration till a spectator is persuaded (in s).
        /// </summary>
        [Tooltip("Duration till a spectator is persuaded (in s)")]
        public float PersuadeDurationNormalMin = 0.25f;
        public float PersuadeDurationNormalMax = 0.35f;
        public float PersuadeDurationHardMin = 1;
        public float PersuadeDurationHardMax = 1.5f;

        /// <summary>
        ///   Number of spectators to make upset (per second).
        /// </summary>
        [Tooltip("Number of spectators to make upset (per second)")]
        public float UpsetSpectatorsFrequencyNormal = 1.0f / 2.0f;
        public float UpsetSpectatorsFrequencyHard = 1.0f / 6.0f;

        private float nextUpsetDurationNormal;
        private float nextUpsetDurationHard;

        private void MakeSpectatorUpset(bool isDissident)
        {
            // Choose not upset spectator.
            var happySpectators = this.SpectatorSystem.Spectators.FindAll(spectator => !spectator.IsUpset).ToList();
            if (happySpectators.Count == 0)
            {
                return;
            }

            var happySpectator = happySpectators[Random.Range(0, happySpectators.Count - 1)];

            happySpectator.PersuadeDuration = isDissident ? Random.Range(PersuadeDurationHardMin, PersuadeDurationHardMax) : Random.Range(PersuadeDurationNormalMin, PersuadeDurationNormalMax);
            // Make upset.
            happySpectator.MakeUpset();
        }

        private void Update()
        {
            this.nextUpsetDurationNormal -= Time.deltaTime;
            if (this.nextUpsetDurationNormal <= 0)
            {
                this.MakeSpectatorUpset(false);

                // Determine duration till next upset.
                this.nextUpsetDurationNormal = 1 / this.UpsetSpectatorsFrequencyNormal;
            }

            this.nextUpsetDurationHard -= Time.deltaTime;
            if (this.nextUpsetDurationHard <= 0)
            {
                this.MakeSpectatorUpset(true);

                // Determine duration till next upset.
                this.nextUpsetDurationHard = 1 / this.UpsetSpectatorsFrequencyHard;
            }

        }
    }
}