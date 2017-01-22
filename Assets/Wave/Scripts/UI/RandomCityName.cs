using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wave.Levels;
using Wave.StageReady;

public class RandomCityName : MonoBehaviour
{

	string[] lines;
	public StageReadyBehaviour stageReadyBehaviour;

	void Awake ()
	{
		LoadCitynames ();
	}

	// Use this for initialization
	void Start ()
	{
		this.gameObject.GetComponent<Text> ().text = lines [Random.Range (0, lines.Length)];
	}

	void LoadCitynames ()
	{
		TextAsset txt = Resources.Load ("Cities") as TextAsset;
		lines = txt.text.Trim ().Split ("\n" [0]);
	}
}
