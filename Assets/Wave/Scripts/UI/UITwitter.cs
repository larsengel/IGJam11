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

	public string SourceFile;

	public bool RandomOrder;

	string[] lines;
	int CurrentLine = 0;

	string GetQuotes ()
	{
		TextAsset txt = Resources.Load (SourceFile) as TextAsset;
		return txt.text;
	}

	// Use this for initialization
	void Start ()
	{
		var fileContents = GetQuotes ();

		lines = fileContents.Trim ().Split ("\n" [0]);


		for (int i = 0; i < 200; i++) {
			CreateTweet (randomLine ());
		}

	}

	string randomLine ()
	{
		if (RandomOrder) {
			return lines [Random.Range (0, lines.Length - 1)];

		} else {
			if (CurrentLine > lines.Length - 1) {
				CurrentLine = 0;
			}
			return lines [CurrentLine++];
		}

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
		for (var i = TweetContainer.GetEnumerator (); i.MoveNext ();) {
			Transform child = (Transform)i.Current;
			var pos = child.position;
			child.position = new Vector3 (pos.x - ScrollSpeed * Time.deltaTime, pos.y, pos.z);
		}
	}
}
