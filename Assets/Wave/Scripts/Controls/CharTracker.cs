using System;
using System.Collections;
using System.Collections.Generic;

using Tobii.EyeTracking;

using UnityEngine;

[RequireComponent (typeof(GazeAware))]
public class CharTracker : MonoBehaviour
{
	public float statePoints;
	float fadeSpeed = 1;
	Color color1 = Color.red;
	Color color2 = Color.green;

	GazeAware gazeAware;

	SpriteRenderer sprite;
	bool isMouseOver;

	void Start ()
	{
		gazeAware = GetComponent<GazeAware>();

		sprite = GetComponent<SpriteRenderer> ();
		statePoints = 0f;
	}

	private void OnMouseEnter ()
	{
		Debug.Log ("OnMouseEnter");
		isMouseOver = true;
	}

	private void OnMouseExit ()
	{
		Debug.Log ("OnMouseExit");
		isMouseOver = false;
	}

	void Update ()
	{
		var isGazeAware = false;
		isGazeAware = gazeAware.HasGazeFocus;

		if (isGazeAware || isMouseOver) {
			statePoints += fadeSpeed * Time.deltaTime;
			statePoints = Mathf.Clamp (statePoints, 0, 1);
		} else {
			statePoints = 0;
		}

		sprite.color = Color.Lerp (color1, color2, statePoints);
	}

    
}
