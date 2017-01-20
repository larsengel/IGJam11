namespace Wave.Spectators
{
    using System.Collections.Generic;
    using System.Linq;

    using UnityEngine;

    public class SpectatorSystem : MonoBehaviour
    {
        public List<Spectator> Spectators;

        [ContextMenu("Find Spectators")]
        private void FindSpectators()
        {
            this.Spectators = FindObjectsOfType<Spectator>().ToList();
        }
    }
}