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
	        var order = renderer.sortingOrder + Offset;
	        renderer.sortingOrder = order;
	    }

	    Search(transform, "schild_ani_right").GetComponent<EntityRenderer>().SortingOrder += Offset;
	    Search(transform, "schild_ani_left").GetComponent<EntityRenderer>().SortingOrder += Offset;

	}

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
}
