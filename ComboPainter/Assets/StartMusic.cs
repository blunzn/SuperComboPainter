using UnityEngine;
using System.Collections;

public class StartMusic : MonoBehaviour {

	private CharacterManager manager;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<CharacterManager>();
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (manager.gameStarted && !audio.isPlaying)
						GetComponent<AudioSource> ().Play ();
	}
}
