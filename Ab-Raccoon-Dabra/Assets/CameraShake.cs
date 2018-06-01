using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {


	public void StartShake(float magnitude,float easeOut, float duration, float delay)
	{
			StartCoroutine(Shake(magnitude,easeOut, 2f, delay));
		
	}
	IEnumerator Shake(float magnitude,float easeOut, float duration, float delay)
	{
		if (delay > 0)
			yield return new WaitForSeconds(delay);
			
		float time= Time.time;
		Vector3 localPos = transform.localPosition;
		float tempMagnitude = magnitude;
		
		while (time > Time.time - duration)
		{
			tempMagnitude *= easeOut;
			Debug.Log(time > Time.time - duration);

			float lerpTime = (Time.time - time)/duration;
			Debug.Log(lerpTime);
			Vector3 offset = new Vector3(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f)) * tempMagnitude;
			transform.localPosition =offset;

			yield return null;

		}
		

		yield break;
	}
}
