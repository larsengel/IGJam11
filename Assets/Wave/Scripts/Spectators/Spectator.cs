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
                    transform.Find("audience").GetComponent<Animator>().SetTrigger("idle");
                }
                else
                {
                    this.BecameHappy.Invoke();
                    var rnd = Random.Range(1, 3);
                    var wave = rnd == 1 ? "wave_left" : "wave_right";

                    transform.Find("audience").GetComponent<Animator>().SetTrigger(wave);
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