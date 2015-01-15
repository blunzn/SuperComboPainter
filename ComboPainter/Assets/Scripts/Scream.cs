using UnityEngine;
using System.Collections;


public class Scream : MonoBehaviour {
	
	private SpriteRenderer headIdle;
	private SpriteRenderer headScream;
	
	// Use this for initialization
	void Start () {
		Transform head = gameObject.transform;
		headIdle = head.FindChild ("idle").gameObject.GetComponent<SpriteRenderer> ();
		headScream = head.FindChild ("scream").gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		bool doScream = Input.GetAxis ("color1") > 0 || Input.GetAxis ("color2") > 0 || Input.GetAxis ("color3") > 0;
		headIdle.enabled = !doScream;
		headScream.enabled = doScream;
	}
}
