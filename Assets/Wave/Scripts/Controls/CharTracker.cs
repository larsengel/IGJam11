using System;
using System.Collections;
using System.Collections.Generic;

#if UNITY_STANDALONE_WIN
using Tobii.EyeTracking;
#endif

using UnityEngine;

#if UNITY_STANDALONE_WIN
[RequireComponent (typeof(GazeAware))]
#endif
public class CharTracker : MonoBehaviour
{
	public float statePoints;
	float fadeSpeed = 1;
	Color color1 = Color.red;
	Color color2 = Color.green;

	#if UNITY_STANDALONE_WIN
	GazeAware gazeAware;
    #endif

	SpriteRenderer sprite;
	bool isMouseOver;

	void Start ()
	{
		#if UNITY_STANDALONE_WIN
		gazeAware = GetComponent<GazeAware>();
		#endif

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
		#if UNITY_STANDALONE_WIN
		isGazeAware = gazeAware.HasGazeFocus;
		#endif

		if (isGazeAware || isMouseOver) {
			statePoints += fadeSpeed * Time.deltaTime;
			statePoints = Mathf.Clamp (statePoints, 0, 1);
		} else {
			statePoints = 0;
		}

		sprite.color = Color.Lerp (color1, color2, statePoints);
	}

    
}
