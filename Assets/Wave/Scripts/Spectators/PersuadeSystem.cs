namespace Wave.Spectators
{
    using UnityEngine;

    public class PersuadeSystem : MonoBehaviour
    {
        /// <summary>
        ///   Duration till a spectator is persuaded (in s).
        /// </summary>
        [Tooltip("Duration till a spectator is persuaded (in s)")]
        public float PersuadeDuration = 1;

        public SpectatorSystem SpectatorSystem;

        private void Update()
        {
            if (this.SpectatorSystem.Spectators == null)
            {
                return;
            }

            foreach (var spectator in this.SpectatorSystem.Spectators)
            {
                if (!spectator.IsUpset)
                {
                    continue;
                }

                if (!spectator.IsPursuading)
                {
                    continue;
                }

                spectator.PersuadeFactor += Time.deltaTime / this.PersuadeDuration;

                if (spectator.PersuadeFactor >= 1)
                {
                    spectator.MakeHappy();
                }
            }
        }
    }
}