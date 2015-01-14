using UnityEngine;
using System.Collections;

public class Canvas : MonoBehaviour {

	public Vector3 position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		position = Input.mousePosition;
		sprite.sprite.texture.SetPixel((int)position.x, (int)position.y, Color.red);
		sprite.sprite.texture.Apply();
	}
}
