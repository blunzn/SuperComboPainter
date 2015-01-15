using UnityEngine;
using System.Collections;

public class connectDecoJoints : MonoBehaviour {

	public string parentName;

	// Use this for initialization
	void Start () {
		HingeJoint2D[] joints = gameObject.GetComponents<HingeJoint2D> ();
		foreach (HingeJoint2D j in joints)
			if (j.connectedBody == null) 
			{
				j.connectedBody = GameObject.Find(parentName).GetComponent<Rigidbody2D>();
				j.connectedAnchor = j.connectedBody.gameObject.transform.InverseTransformPoint(gameObject.transform.TransformPoint(j.anchor));
			}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
