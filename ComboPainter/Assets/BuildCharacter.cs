using UnityEngine;
using System.Collections;

public class BuildCharacter : MonoBehaviour {
	Object[] allLower;
	Object[] allMiddle;
	Object[] allTop;

	GameObject[] allPositions;

	// Use this for initialization
	void Start () 
	{
		allLower = Resources.LoadAll ("Prefabs/AllCharacter/Lower");
		allMiddle = Resources.LoadAll ("Prefabs/AllCharacter/Middle");
		allTop = Resources.LoadAll ("Prefabs/AllCharacter/Top");

		allPositions = new GameObject[3];
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void newCharacter()
	{
		foreach (GameObject p in allPositions) 
		{
			if(p == null)
				continue;

			GameObject.Destroy(p);
		}

		GameObject temp = allLower [Random.Range (0, allLower.Length)] as GameObject;
		allPositions [0] = Instantiate (temp, transform.position, Quaternion.identity) as GameObject;

		temp = allMiddle[Random.Range (0, allMiddle.Length)] as GameObject;
		allPositions [1] = Instantiate (temp, transform.position, Quaternion.identity) as GameObject;
//		allPositions[0].transform.position.
	}
}
