using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particler : MonoBehaviour
{

    public GameObject HappyParticlePrefab;
    public GameObject UpsetParticlePrefab;

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
