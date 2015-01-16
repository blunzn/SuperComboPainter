using UnityEngine;
using System.Collections;

public class ContractGummi : MonoBehaviour {
	public float frequencyIncrease = 0.01f;

	private CharacterManager manager;
	private SpringJoint2D joint;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("GameController").GetComponent<CharacterManager> ();
		joint = GetComponent<SpringJoint2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("moveArm") > 0) {
						joint.frequency = Mathf.Min (joint.frequency + frequencyIncrease, 10);
				} else
						joint.frequency = 0.001f;
	}
}
