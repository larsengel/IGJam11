using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColor : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		var color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
		setColors (transform, "clothes", color);
	}

	void setColors (Transform t, string tag, Color color)
	{
		for (var i = t.GetEnumerator (); i.MoveNext ();) {
			Transform tr = (Transform)i.Current;
			setColors (tr, tag, color);
			if (tr.CompareTag ("clothes")) {
				var spriteRenderer = tr.GetComponent<SpriteRenderer> ();
				spriteRenderer.color = color;
			}
		}
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
}
