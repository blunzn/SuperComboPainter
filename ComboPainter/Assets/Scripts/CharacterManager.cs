using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {
	Object[] allBottom;
	Object[] allMiddle;
	Object[] allTop;

	Object[] allBackgrounds;

	public GameObject[] allCharacters;
	public SpriteRenderer currentBg;

	public int finehide = 0;

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

		crewSets = new string[3,3];
		crewSets [0,0] = "berta";
		crewSets [0,1] = "schnauzer";
		crewSets [0,2] = "ute";
		crewSets [1,0] = "dot";
		crewSets [1,1] = "TwoGirls";
		crewSets [1,2] = "polka";
		crewSets [2,0] = "niceUndies";
		crewSets [2,1] = "gurl";
		crewSets [2,2] = "dude_oben";

		crewSetIndex = 0;

		newBackground ();
		newCharacter();
//		allCharacters = new GameObject[3];
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("b"))
			newCharacter();
		if (Input.GetKeyDown ("v"))
			newBackground();

		if (Input.GetKeyDown ("n"))
						newCrewSet ();

		if (Input.GetKeyDown(KeyCode.LeftArrow) && finehide < 2)
			finehide++;
				
		if (Input.GetKeyDown(KeyCode.RightArrow) && finehide > 0)
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

		GameObject temp = allBottom [Random.Range (0, allBottom.Length)] as GameObject;
		allCharacters [0] = Instantiate (temp, transform.position, Quaternion.identity) as GameObject;

		temp = allMiddle[Random.Range (0, allMiddle.Length)] as GameObject;

//		Transform bottom = temp.transform.FindChild ("bottom");
//		Vector3 pos = bottom.position - bottom.localPosition;

		allCharacters [1] = Instantiate (temp, transform.position , Quaternion.identity) as GameObject;
		connectDecoJoints[] djs = allCharacters [1].GetComponentsInChildren<connectDecoJoints> ();
		foreach (connectDecoJoints dj in djs)
						dj.connect (); 

		allCharacters [1].SetActive (true);
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

	void newCrewSet()
	{
		foreach (GameObject p in allCharacters) 
		{
			if(p == null)
				continue;
			
			GameObject.Destroy(p);
		}

		
		GameObject temp = Resources.Load ("Prefabs/AllCharacter/Bottom/" + crewSets [crewSetIndex,0]) as GameObject;
//			allBottom [Random.Range (0, allBottom.Length)] as GameObject;
		allCharacters [0] = Instantiate (temp, transform.position, Quaternion.identity) as GameObject;
		
		temp = Resources.Load ("Prefabs/AllCharacter/Middle/" + crewSets [crewSetIndex,1]) as GameObject;
		
		//		Transform bottom = temp.transform.FindChild ("bottom");
		//		Vector3 pos = bottom.position - bottom.localPosition;
		
		allCharacters [1] = Instantiate (temp, transform.position , Quaternion.identity) as GameObject;
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
		
		allCharacters [2] = Instantiate (temp, transform.position , Quaternion.identity) as GameObject;
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
