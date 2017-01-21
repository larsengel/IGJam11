using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.EyeX.Client;

public class UIWaveOMeter : MonoBehaviour
{
    public RectTransform Pointer;

    [Range (0.0f, 1.0f)]
    public float Value;

 
    // 0 ist 90 und 1 is -90
    void Update ()
    {
        float euler_angle = 90.0f - (180.0f * Value);
        Pointer.rotation = Quaternion.Euler (new Vector3 (0, 0, euler_angle));
    }

    void OnDrawGizmos ()
    {
        //Update ();
    }
}
