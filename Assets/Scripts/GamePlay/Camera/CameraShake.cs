using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public IEnumerator Shake(float duration, float magnitude)
	{
		Debug.Log("ÇALIÞIYO ÝÞTEEEEE");
		Vector3 originalPos = transform.position;
		float elapsed = 0.0f;
		while (elapsed <= duration)
		{
			float x = Random.Range(-1f, 1f) * magnitude;
			float z = Random.Range(-1f, 1f) * magnitude;
			transform.position = new Vector3(originalPos.x ,originalPos.y, originalPos.z +z);

			elapsed += Time.deltaTime;

			yield return null;
		}
		transform.localPosition = originalPos;
	}
}
