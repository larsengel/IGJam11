namespace Wave.Spectators
{
    using UnityEngine;
    using UnityEngine.Events;

    public class Spectator : MonoBehaviour
    {
        public UnityEvent BecameHappy;

        public UnityEvent BecameUpset;

        public float PersuadeFactor;

        private bool isUpset;

        public float ShowSignFactor { get; set; }

        public bool IsPursuading { get; set; }

        public bool IsUpset
        {
            get
            {
                return this.isUpset;
            }
            set
            {
                if (value == this.isUpset)
                {
                    return;
                }

                this.isUpset = value;

                if (value)
                {
                    this.BecameUpset.Invoke();
                }
                else
                {
                    this.BecameHappy.Invoke();
                }
            }
        }

        public void MakeHappy()
        {
            this.IsUpset = false;
        }

        public void MakeUpset()
        {
            this.IsUpset = true;
            this.PersuadeFactor = 0;
        }
    }
}