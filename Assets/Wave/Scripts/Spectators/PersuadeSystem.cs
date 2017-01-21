namespace Wave.Spectators
{
    using UnityEngine;

    public class PersuadeSystem : MonoBehaviour
    {
        public SpectatorSystem SpectatorSystem;

        private void Update()
        {
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

                spectator.PersuadeFactor += Time.deltaTime / spectator.PersuadeDuration;

                if (spectator.PersuadeFactor >= 1)
                {
                    spectator.MakeHappy();
                }
            }
        }
    }
}