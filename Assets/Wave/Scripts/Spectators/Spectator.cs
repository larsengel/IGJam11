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

        public float PersuadeDuration;

        private bool isUpset;

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
                    transform.Find("audience").GetComponent<AudienceAnimations>().SetIdle();
                }
                else
                {
                    this.BecameHappy.Invoke();
                    var wave = Random.Range(1, 3) == 1 ? "left" : "right";

                    transform.Find("audience").GetComponent<AudienceAnimations>().SetWave(wave);
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