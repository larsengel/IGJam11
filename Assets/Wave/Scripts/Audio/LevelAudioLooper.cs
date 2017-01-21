using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
    
public class LevelAudioLooper : MonoBehaviour
{

    public AudioClip Intro;
    public AudioClip Loop;

    AudioSource AudioSource;


    void Awake ()
    {
        AudioSource = GetComponent<AudioSource> ();
    }
    // Use this for initialization
    void Start ()
    {
        AudioSource.clip = Intro;
        AudioSource.Play ();
    }
	
    // Update is called once per frame
    void Update ()
    {
        if (Loop == null) {
            return;
        }

        if (!AudioSource.isPlaying) {
            AudioSource.clip = Loop;
            AudioSource.Play ();
        }
    }
}
