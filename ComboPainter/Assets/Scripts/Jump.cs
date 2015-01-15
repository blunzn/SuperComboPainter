using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	public float jumpForce = 2;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
						rigidbody2D.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
	}
}
