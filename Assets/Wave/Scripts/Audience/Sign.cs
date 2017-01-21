using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour {
    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }


    void Update () {
        var rotation = Quaternion.Euler(new Vector3(0,0,-0f));
        transform.rotation = rotation;
    }
}
