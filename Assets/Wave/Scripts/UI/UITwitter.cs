using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UITwitter : MonoBehaviour
{

	public RectTransform TweetPrefab;
	public Transform TweetContainer;

	public float ScrollSpeed;


	string[] lines;

	string GetQuotes ()
	{
		TextAsset txt = Resources.Load ("TrumpQuotes") as TextAsset;
		return txt.text;
	}

	// Use this for initialization
	void Start ()
	{
		var fileContents = GetQuotes ();

		lines = fileContents.Split ("\n" [0]);


		for (int i = 0; i < 200; i++) {
			CreateTweet (randomLine ());
		}

	}

	string randomLine ()
	{
		return lines [Random.Range (0, lines.Length - 1)];
	}

	void CreateTweet (string line)
	{

		var tweet = Instantiate (TweetPrefab, Vector3.zero, Quaternion.identity, TweetContainer);
  
		tweet.FindChild ("TweetText").GetComponent<Text> ().text = line;

		char letter = (char)Random.Range (65, 90);
		tweet.FindChild ("Mood").GetComponent<Text> ().text = letter.ToString ();
	}

	// Update is called once per frame
	void Update ()
	{
		foreach (Transform child in TweetContainer) {
			var pos = child.position;
			child.position = new Vector3 (pos.x - ScrollSpeed * Time.deltaTime, pos.y, pos.z); 
		}
	}
}
