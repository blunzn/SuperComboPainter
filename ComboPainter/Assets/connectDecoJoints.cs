using UnityEngine;
using System.Collections;

public class connectDecoJoints : MonoBehaviour {

	public string parentName;

	// Use this for initialization
	void OnEnable () 
	{

		connect ();
	}

	public void connect()
	{
		HingeJoint2D[] joints = gameObject.GetComponents<HingeJoint2D> ();
		CharacterManager manager = GameObject.Find ("GameController").GetComponent<CharacterManager> ();
		Rigidbody2D parentBody = manager.getPart(parentName).GetComponent<Rigidbody2D> ();
		foreach (HingeJoint2D j in joints)
		if (j.connectedBody == null) 
		{
			j.enabled = false;
//			j.connectedBody = parentBody;
//			j.connectedAnchor = j.connectedBody.gameObject.transform.InverseTransformPoint(gameObject.transform.TransformPoint(j.anchor));
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
