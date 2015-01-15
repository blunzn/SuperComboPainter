using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOutImage : MonoBehaviour {
	public float fadeDuration = 1;
	public float startFadeDelay = 2;

	// Use this for initialization
	void Start () {
		if(startFadeDelay > 0)
			StartCoroutine (fade ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startFade()
	{
		startFadeDelay = 0;
		StartCoroutine (fade ());
	}


	IEnumerator fade()
	{
		yield return new WaitForSeconds(startFadeDelay);

		float timePassed = 0;
		Color color = gameObject.GetComponent<Image> ().color;
		while (timePassed < fadeDuration) 
		{
						timePassed += Time.deltaTime;
			color.a = Mathf.Lerp(1,0, timePassed/fadeDuration);
			yield return null;
			gameObject.GetComponent<Image> ().color = color;
				}
	}
}
