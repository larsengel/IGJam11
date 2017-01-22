namespace Wave.Spectators
{
    using UnityEngine;

    using Wave.Levels;

    public class PersuadeSystem : MonoBehaviour
    {
        public LevelSystem LevelSystem;

        public SpectatorSystem SpectatorSystem;

        private void Reset ()
        {
            if (this.SpectatorSystem == null) {
                this.SpectatorSystem = FindObjectOfType<SpectatorSystem> ();
            }
            if (this.LevelSystem == null) {
                this.LevelSystem = FindObjectOfType<LevelSystem> ();
            }
        }

        private void Update ()
        {
            if (this.SpectatorSystem.Spectators == null) {
                return;
            }

            foreach (var spectator in this.SpectatorSystem.Spectators) {

                var particler = spectator.GetComponent<Particler> ();

                if (!spectator.IsUpset) {
                    continue;
                }

                if (!spectator.IsPursuading) {
                    // hier beendern wir den partciler halo
                    spectator.MakeUpset ();
                    particler.DestroyHalo ();
                    continue;
                }

                particler.CreateHalo ().PlayEffect ();

                // effekt laufen lassen 
                spectator.PersuadeFactor += Time.deltaTime / this.LevelSystem.CurrentConfiguration.PersuadeDuration;

                if (spectator.PersuadeFactor >= 1) {
                    particler.DestroyHalo ();
                    spectator.MakeHappy ();
                }
            }
        }
    }
}