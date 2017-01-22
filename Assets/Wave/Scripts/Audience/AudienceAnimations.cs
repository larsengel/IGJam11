using System;

using UnityEngine;

using Wave.Spectators;

using Random = UnityEngine.Random;

public class AudienceAnimations : MonoBehaviour
{
    public Animator Animator;

    public Shield ShieldLeft;

    public Shield ShieldRight;

    public Spectator Spectator;

    public static Transform Search (Transform target, string name)
    {
        if (target.name == name) {
            return target;
        }

        for (int i = 0; i < target.childCount; ++i) {
            var result = Search (target.GetChild (i), name);

            if (result != null) {
                return result;
            }
        }

        return null;
    }

    public void SetIdle ()
    {
        this.Animator.SetTrigger ("idle");
        this.ShieldLeft.Show (false);
        this.ShieldRight.Show (false);
    }

    public void SetWave ()
    {
        this.SetWave (Random.Range (1, 3) == 1 ? "left" : "right");
    }

    public void SetWave (string direction)
    {
        var showSignFactor = this.Spectator != null ? this.Spectator.ShowSignFactor : 0.3f;
        var showShield = Random.Range (0.0f, 1.0f) < showSignFactor;
        if (direction == "left") {
            this.ShieldLeft.Show (showShield);
            this.Animator.SetTrigger ("wave_left");
        } else if (direction == "right") {
            this.ShieldRight.Show (showShield);
            this.Animator.SetTrigger ("wave_right");
        }
    }

    private void Reset ()
    {
        if (this.Animator == null) {
            this.Animator = this.GetComponent<Animator> ();
        }
        this.ShieldLeft = new Shield {
            Root = Search (this.transform, "schild_left"),
            TextTransform = Search (this.transform, "text_left"),
            SchieldAni = Search (this.transform, "schild_ani_left")
        };
        this.ShieldRight = new Shield {
            Root = Search (this.transform, "schild_right"),
            TextTransform = Search (this.transform, "text_right"),
            SchieldAni = Search (this.transform, "schild_ani_right")
        };
    }

    // Use this for initialization
    private void Start ()
    {
        var speed = Random.Range (.6f, 1);
        this.Animator.speed = speed;

        this.ShieldLeft.Show (false);
        this.ShieldRight.Show (false);
        this.SetIdle ();
    }

    [Serializable]
    public class Shield
    {
        public Transform Root;

        public Transform TextTransform;

        public Transform SchieldAni;

        public void Show (bool isVisible)
        {
            if (this.Root != null) {
                this.Root.gameObject.SetActive (isVisible);
                if (isVisible) {
                    this.SchieldAni.GetComponent<Animator> ().SetTrigger ("start");
                }
            }
        }
    }
}