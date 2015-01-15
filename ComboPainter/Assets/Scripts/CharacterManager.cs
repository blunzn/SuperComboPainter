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

	// Use this for initialization
	void Start () 
	{
		allBottom = Resources.LoadAll ("Prefabs/AllCharacter/Bottom");
		allMiddle = Resources.LoadAll ("Prefabs/AllCharacter/Middle");
		allTop = Resources.LoadAll ("Prefabs/AllCharacter/Top");
		allBackgrounds = Resources.LoadAll ("Sprites/backgrounds");

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

		if (Input.GetKeyDown(KeyCode.LeftArrow) && finehide < 2)
			finehide++;
				
		if (Input.GetKeyDown(KeyCode.RightArrow) && finehide > 0)
			finehide--;
	}
	
	void newBackground()
	{
		GameObject bg = GameObject.Find ("Canvas");
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
