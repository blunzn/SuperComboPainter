using UnityEngine;
using System.Collections;


public class Scream : MonoBehaviour {
	
	private SpriteRenderer headIdle;
	private SpriteRenderer headScream;
	
	private AudioSource currentSound;
	
	// Use this for initialization
	void Start () {
		Transform head = gameObject.transform;
		headIdle = head.FindChild ("idle").gameObject.GetComponent<SpriteRenderer> ();
		headScream = head.FindChild ("scream").gameObject.GetComponent<SpriteRenderer> ();

		currentSound = null;
	}
	
	// Update is called once per frame
	void Update () {
		bool doScream = Input.GetButton("color1") || Input.GetButton("color2") || Input.GetButton("color3");
		headIdle.enabled = !doScream;
		headScream.enabled = doScream;

		if (currentSound == null && doScream)
		{
			AudioSource[] sources = transform.GetComponentsInChildren<AudioSource>();

			int index = Random.Range(0, sources.Length);
			currentSound = sources[index];
			currentSound.Play();
		}
		else if (currentSound != null && !doScream)
		{
			currentSound.Stop();
			currentSound = null;
		}
	}
}
