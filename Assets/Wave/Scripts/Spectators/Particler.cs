using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wave.Levels;

public class Particler : MonoBehaviour
{

    public GameObject HappyParticlePrefab;
    public GameObject UpsetParticlePrefab;
    public GameObject HappyHaloPrefab;

    public AudioClip PowerUpSound;
    public AudioClip HappySound;

    private float duration;

    public float Duration {
        get {
            if (duration == 0.0f) {
                duration = FindObjectOfType<LevelSystem> ().CurrentConfiguration.PersuadeDuration;
            }
            return duration;
        }
        set {
            duration = value;  
        }
    }

    public HappyHalo HappyHalo;

    public HappyHalo CreateHalo ()
    {
        if (HappyHalo != null) {
            return HappyHalo;
        }

        HappyHalo = Instantiate (HappyHaloPrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<HappyHalo> ();
        HappyHalo.transform.localPosition = Vector3.zero;
        HappyHalo.SpeedFactor = Duration;

        var AudioSource = GetComponent<AudioSource> ();
        AudioSource.clip = PowerUpSound;
        AudioSource.Play ();

        return HappyHalo;
    }

    public void DestroyHalo ()
    {
        if (HappyHalo != null) {
            Destroy (HappyHalo.gameObject);    
            HappyHalo = null;
        }

        var AudioSource = GetComponent<AudioSource> ();
        AudioSource.Stop ();
    }

    public void ShowHappy ()
    {
        var pos = transform.position;
        var particle = Instantiate (HappyParticlePrefab, pos, Quaternion.identity);
        Destroy (particle, 2.0f);

        var AudioSource = GetComponent<AudioSource> ();
        AudioSource.clip = HappySound;
        AudioSource.Play ();
    }

    public void ShowUpset ()
    {
        var pos = transform.position;
        var particle = Instantiate (UpsetParticlePrefab, pos, Quaternion.identity);
        Destroy (particle, 2.0f);
    }
}
