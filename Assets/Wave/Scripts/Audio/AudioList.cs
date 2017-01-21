using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class AudioList : MonoBehaviour
{

	public AudioClip[] audioFiles;
	public AudioSource AudioSource;

	void Awake ()
	{
		AudioSource = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start ()
	{
		PlayRandomAudioClip ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!AudioSource.isPlaying) {
			PlayRandomAudioClip ();
		}
	}

	void PlayRandomAudioClip ()
	{
		if (audioFiles.Length > 0) {
			int index = Random.Range (0, audioFiles.Length);
			PlayAudioClip (audioFiles [index]);
		}
	}

	void PlayAudioClip (AudioClip audioClip)
	{
		AudioSource.clip = audioClip;
		AudioSource.Play ();
	}
}
