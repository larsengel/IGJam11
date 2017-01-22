using System.Collections;
using System.Collections.Generic;
using Spriter2UnityDX;
using UnityEngine;

public class OrderInLayer : MonoBehaviour {

    static int Offset = 0;

	// Use this for initialization
	void Start ()
	{
	    Offset += 1000;

	    foreach (var renderer in GetComponentsInChildren<Renderer>())
	    {
	        renderer.sortingOrder += Offset;
	    }
	    foreach (var renderer in GetComponentsInChildren<EntityRenderer>())
	    {
	        renderer.SortingOrder += Offset;
	    }
	}
}
