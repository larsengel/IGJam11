using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour {
    private void Start()
    {
        //GetComponent<SpriteRenderer>().enabled = false;
    }


    void Update () {
        var rotation = Quaternion.LookRotation(new Vector3(0,0,-245.348f));
        transform.rotation = rotation;
    }
}
