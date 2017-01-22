using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
	public float shake = 0;
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

	public void StartShake ()
	{
		Vector3 localPosition = this.gameObject.transform.localPosition;

		localPosition.x = 0 + Random.Range (-0.5f, 0.5f) * shakeAmount;
		localPosition.y = 1 + Random.Range (-0.5f, 0.5f) * shakeAmount;
		localPosition.z = -10 + Random.Range (-0.5f, 0.5f) * shakeAmount;

		this.gameObject.transform.localPosition = localPosition;
	}

	public void StopShake ()
	{
		shake = 0.0f;
		this.gameObject.transform.localPosition = new Vector3 (0, 1, -10);
	}
}
