using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColor : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    var color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 0);
        setColors(transform, "clothes", color);
	}

    void setColors(Transform t, string tag, Color color)
    {
        foreach(Transform tr in t)
        {
            setColors(tr, tag, color);
            if(tr.CompareTag("clothes"))
            {
                var renderer =  tr.GetComponent<Renderer>();
                renderer.material.shader = Shader.Find (" Glossy");
                renderer.material.SetColor ("_SpecColor", color);
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
