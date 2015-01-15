using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	private CharacterManager manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<CharacterManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("startGame") > 0) {
						manager.gameStarted = true;
			GetComponent<FadeOutImage>().startFade();
			transform.parent.Find("Background").gameObject.GetComponent<FadeOutImage>().startFade();

				}
	}
}
