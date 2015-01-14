using UnityEngine;
using System.Collections;

public class Canvas : MonoBehaviour {

	public Vector3 position;

	private Texture2D texture;

	// Use this for initialization
	void Start () {

		texture = GetComponent<SpriteRenderer>().sprite.texture;
	}
	
	// Update is called once per frame
	void Update () {

		position = Input.mousePosition;
		texture.SetPixel((int)position.x, (int)position.y, Color.red);
		texture.Apply();
	}
}
