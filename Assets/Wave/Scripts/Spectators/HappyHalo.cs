using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyHalo : MonoBehaviour
{
    
    public AnimationCurve Intensity;
    [Tooltip ("Object gets destroyed after this time (in sec)")]
    public float KillTime;
    public float SpeedFactor;

    Light Light;
    float time;

    // Use this for initialization
    void Awake ()
    {
        Light = GetComponent<Light> ();
    }
	
    // Update is called once per frame
    public void PlayEffect ()
    {
        Light.intensity = Intensity.Evaluate (time);
        time += Time.deltaTime / SpeedFactor;
    }

   
}
