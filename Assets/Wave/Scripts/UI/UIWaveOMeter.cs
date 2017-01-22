using UnityEngine;

using Wave.Levels;

public class UIWaveOMeter : MonoBehaviour
{
    public Transform Pointer;

    [Range (0.0f, 1.0f)]
    public float Value;

    private DefeatSystem defeatSystem;

    private void OnDrawGizmos ()
    {
        //Update ();
    }

    private void Start ()
    {
        this.defeatSystem = FindObjectOfType<DefeatSystem> ();
    }

    // 0 ist 90 und 1 is -90
    private void Update ()
    {
        this.Value = this.defeatSystem != null ? this.defeatSystem.WaveRatio : 0.5f;

        float euler_angle = 90.0f - (180.0f * this.Value);
        this.Pointer.rotation = Quaternion.Euler (new Vector3 (0, 0, euler_angle));
    }
}