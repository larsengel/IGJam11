using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignTrumpText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    var st = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
	    var c = st[Random.Range(0, st.Length)];
	    GetComponent<TextMesh>().text = c.ToString();
		
	}
}
