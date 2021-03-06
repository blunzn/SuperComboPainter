﻿using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {
	Object[] allBottom;
	Object[] allMiddle;
	Object[] allTop;

	Object[] allBackgrounds;

	public GameObject[] allCharacters;
	public SpriteRenderer currentBg;

	public int finehide = 1;

	public bool gameStarted;

	private string[,] crewSets;
	private int crewSetIndex;

	// Use this for initialization
	void Start () 
	{
		allBottom = Resources.LoadAll ("Prefabs/AllCharacter/Bottom");
		allMiddle = Resources.LoadAll ("Prefabs/AllCharacter/Middle");
		allTop = Resources.LoadAll ("Prefabs/AllCharacter/Top");
		allBackgrounds = Resources.LoadAll ("Sprites/backgrounds");

		crewSets = new string[5,3];
		crewSets [0,0] = "berta";
		crewSets [0,1] = "schnauzer";
		crewSets [0,2] = "ute";
		crewSets [1,0] = "dot";
		crewSets [1,1] = "TwoGirls";
		crewSets [1,2] = "polka";
		crewSets [2,0] = "niceUndies";
		crewSets [2,1] = "gurl";
		crewSets [2,2] = "dude_oben";
		crewSets [3,0] = "delivery";
		crewSets [3,1] = "ape";
		crewSets [3,2] = "hendl";
		crewSets [4,0] = "jonny";
		crewSets [4,1] = "donut";
		crewSets [4,2] = "marius1";

		crewSetIndex = Random.Range(0, crewSets.Length/3);

		newBackground ();
		newCrewSet();
//		allCharacters = new GameObject[3];
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("newRandomCrew"))
			newCharacter();
		if (Input.GetButtonDown("newBackground"))
			newBackground();

		if (Input.GetButtonDown("newCrew"))
						newCrewSet ();

		if (Input.GetButtonDown("decreaseFinehide") && finehide < 2)
			finehide++;
				
		if (Input.GetButtonDown("increaseFinehide") && finehide > 0)
			finehide--;
	}
	
	void newBackground()
	{
		GameObject bg = GameObject.Find ("PaintCanvas");
		SpriteRenderer[] sp = bg.GetComponentsInChildren<SpriteRenderer> ();
		int num = Random.Range (0, sp.Length);
		for (int i = 0; i < sp.Length; ++i)
		{
			if (i == num)
				bg.GetComponent<PaintArea>().background = sp[i].sprite;

			sp[i].enabled = (i == num);
		}
	}

	void newCharacter()
	{
		foreach (GameObject p in allCharacters) 
		{
			if(p == null)
				continue;

			GameObject.Destroy(p);
		}

		Vector3 pos = transform.position;

		GameObject temp = allBottom [Random.Range (0, allBottom.Length)] as GameObject;
		allCharacters [0] = Instantiate (temp, pos, Quaternion.identity) as GameObject;

		temp = allMiddle[Random.Range (0, allMiddle.Length)] as GameObject;

//		Transform bottom = temp.transform.FindChild ("bottom");
//		Vector3 pos = bottom.position - bottom.localPosition;

		pos.y += 2;

		allCharacters [1] = Instantiate (temp, pos , Quaternion.identity) as GameObject;
		connectDecoJoints[] djs = allCharacters [1].GetComponentsInChildren<connectDecoJoints> ();
		foreach (connectDecoJoints dj in djs)
						dj.connect (); 

//		allCharacters [1].SetActive (false);
		HingeJoint2D joint = allCharacters [1].GetComponent<HingeJoint2D> ();
		joint.connectedBody = allCharacters [0].rigidbody2D;
		joint.anchor = allCharacters [1].transform.FindChild ("bottom").localPosition;
		joint.connectedAnchor = allCharacters [0].transform.FindChild ("top").localPosition;
		
//		allCharacters [1].SetActive (true);

		temp = allTop[Random.Range (0, allTop.Length)] as GameObject;
		
		//		Transform bottom = temp.transform.FindChild ("bottom");
		//		Vector3 pos = bottom.position - bottom.localPosition;
		
		
		pos.y += 2;

		allCharacters [2] = Instantiate (temp, pos, Quaternion.identity) as GameObject;
		joint = allCharacters [2].GetComponent<HingeJoint2D> ();
		joint.connectedBody = allCharacters [1].rigidbody2D;
		joint.anchor = allCharacters [2].transform.FindChild ("bottom").localPosition;
		joint.connectedAnchor = allCharacters [1].transform.FindChild ("top").localPosition;

//		allCharacters[0].transform.position.
	}

	void newCrewSet()
	{
		foreach (GameObject p in allCharacters) 
		{
			if(p == null)
				continue;
			
			GameObject.Destroy(p);
		}

		
		Vector3 pos = transform.position;

		GameObject temp = Resources.Load ("Prefabs/AllCharacter/Bottom/" + crewSets [crewSetIndex,0]) as GameObject;
//			allBottom [Random.Range (0, allBottom.Length)] as GameObject;
		allCharacters [0] = Instantiate (temp, pos, Quaternion.identity) as GameObject;
		
		temp = Resources.Load ("Prefabs/AllCharacter/Middle/" + crewSets [crewSetIndex,1]) as GameObject;
		
		//		Transform bottom = temp.transform.FindChild ("bottom");
		//		Vector3 pos = bottom.position - bottom.localPosition;

		pos.y += 2;

		allCharacters [1] = Instantiate (temp, pos , Quaternion.identity) as GameObject;
		connectDecoJoints[] djs = allCharacters [1].GetComponentsInChildren<connectDecoJoints> ();
		foreach (connectDecoJoints dj in djs)
			dj.connect (); 
		
		allCharacters [1].SetActive (true);
		HingeJoint2D joint = allCharacters [1].GetComponent<HingeJoint2D> ();
		joint.connectedBody = allCharacters [0].rigidbody2D;
		joint.anchor = allCharacters [1].transform.FindChild ("bottom").localPosition;
		joint.connectedAnchor = allCharacters [0].transform.FindChild ("top").localPosition;
		
		temp = Resources.Load ("Prefabs/AllCharacter/Top/" + crewSets [crewSetIndex,2]) as GameObject;
		
		//		Transform bottom = temp.transform.FindChild ("bottom");
		//		Vector3 pos = bottom.position - bottom.localPosition;
		
		pos.y += 2;

		allCharacters [2] = Instantiate (temp, pos , Quaternion.identity) as GameObject;
		joint = allCharacters [2].GetComponent<HingeJoint2D> ();
		joint.connectedBody = allCharacters [1].rigidbody2D;
		joint.anchor = allCharacters [2].transform.FindChild ("bottom").localPosition;
		joint.connectedAnchor = allCharacters [1].transform.FindChild ("top").localPosition;
		
		//		allCharacters[0].transform.position.

		crewSetIndex = (crewSetIndex+1) % (crewSets.Length/3);
	}

	public GameObject getPart(string part)
	{
		if (part == "bottom")
			return bottom ();
		else if (part == "middle")
			return middle ();
		else if (part == "top")
			return top ();

		return null;
	}

	public GameObject bottom()
	{
		return allCharacters [0];
	}
	
	public GameObject middle()
	{
		return allCharacters [1];
	}
	
	public GameObject top()
	{
		return allCharacters [2];
	}
}
