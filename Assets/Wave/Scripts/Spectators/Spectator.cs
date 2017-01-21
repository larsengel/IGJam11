namespace Wave.Spectators
{
    using UnityEngine;
    using UnityEngine.Events;

    public class Spectator : MonoBehaviour
    {
        public UnityEvent BecameHappy;

        public UnityEvent BecameUpset;

        public bool IsPursuading { get; set; }

        public float PersuadeFactor;

        private bool isUpset;

        private Particler Particler;

        public bool IsUpset {
            get {
                return this.isUpset;
            }
            set {
                if (value == this.isUpset) {
                    return;
                }

                this.isUpset = value;

                if (value) {
                    this.BecameUpset.Invoke ();
                } else {
                    this.BecameHappy.Invoke ();
                }
            }
        }

        public void MakeHappy ()
        {
            this.IsUpset = false;
            Particler.ShowHappy ();
        }

        public void MakeUpset ()
        {
            this.IsUpset = true;
            this.PersuadeFactor = 0;
            Particler.ShowUpset ();
        }

        private void Awake ()
        {
            Particler = GetComponent<Particler> ();
        }
    }
}