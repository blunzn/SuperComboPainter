using UnityEngine;
using System.Collections;

public class BuildCharacter : MonoBehaviour {
	Object[] allLower;
	Object[] allMiddle;
	Object[] allTop;

	GameObject[] allCharacters;

	// Use this for initialization
	void Start () 
	{
		allLower = Resources.LoadAll ("Prefabs/AllCharacter/Lower");
		allMiddle = Resources.LoadAll ("Prefabs/AllCharacter/Middle");
		allTop = Resources.LoadAll ("Prefabs/AllCharacter/Top");

		allCharacters = new GameObject[3];
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("b"))
						newCharacter ();
	}

	void newCharacter()
	{
		foreach (GameObject p in allCharacters) 
		{
			if(p == null)
				continue;

			GameObject.Destroy(p);
		}

		GameObject temp = allLower [Random.Range (0, allLower.Length)] as GameObject;
		allCharacters [0] = Instantiate (temp, transform.position, Quaternion.identity) as GameObject;

		temp = allMiddle[Random.Range (0, allMiddle.Length)] as GameObject;

//		Transform bottom = temp.transform.FindChild ("bottom");
//		Vector3 pos = bottom.position - bottom.localPosition;

		allCharacters [1] = Instantiate (temp, transform.position , Quaternion.identity) as GameObject;
		HingeJoint2D joint = allCharacters [1].GetComponent<HingeJoint2D> ();
		joint.connectedBody = allCharacters [0].rigidbody2D;
		joint.anchor = allCharacters [1].transform.FindChild ("bottom").localPosition;
		joint.connectedAnchor = allCharacters [0].transform.FindChild ("top").localPosition;


		temp = allTop[Random.Range (0, allTop.Length)] as GameObject;
		
		//		Transform bottom = temp.transform.FindChild ("bottom");
		//		Vector3 pos = bottom.position - bottom.localPosition;
		
		allCharacters [2] = Instantiate (temp, transform.position , Quaternion.identity) as GameObject;
		joint = allCharacters [2].GetComponent<HingeJoint2D> ();
		joint.connectedBody = allCharacters [1].rigidbody2D;
		joint.anchor = allCharacters [2].transform.FindChild ("bottom").localPosition;
		joint.connectedAnchor = allCharacters [1].transform.FindChild ("top").localPosition;

//		allCharacters[0].transform.position.
	}
}
