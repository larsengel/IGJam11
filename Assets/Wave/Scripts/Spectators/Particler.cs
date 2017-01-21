using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particler : MonoBehaviour
{

    public GameObject HappyParticlePrefab;
    public GameObject UpsetParticlePrefab;
    public GameObject HappyHaloPrefab;

    public float Duration { get; set; }

    public HappyHalo HappyHalo;

    public HappyHalo CreateHalo ()
    {
        if (HappyHalo != null) {
            return HappyHalo;
        }

        HappyHalo = Instantiate (HappyHaloPrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<HappyHalo> ();
        HappyHalo.transform.localPosition = Vector3.zero;
        HappyHalo.SpeedFactor = Duration;

        return HappyHalo;
    }


    public void OnFocusEffekt ()
    {
       
    }

    public void ShowHappy ()
    {
        var pos = transform.position;
        var particle = Instantiate (HappyParticlePrefab, pos, Quaternion.identity);
        Destroy (particle, 2.0f);
    }

    public void ShowUpset ()
    {
        var pos = transform.position;
        var particle = Instantiate (UpsetParticlePrefab, pos, Quaternion.identity);
        Destroy (particle, 2.0f);
    }
}
