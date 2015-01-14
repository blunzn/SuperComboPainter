using UnityEngine;
using System.Collections;

public class Canvas : MonoBehaviour {

	private Sprite sprite;
	private Transform brush;

	// Use this for initialization
	void Start () {

		sprite = GetComponent<SpriteRenderer>().sprite;
		brush = GameObject.Find("Torso").transform.FindChild("arms_hand").transform;

	}
	
	// Update is called once per frame
	void Update () {

		sprite.texture.Apply();
	}

	public void paintAt(Vector3 worldPoint) {

		Vector2 position = pixelCoordinates(worldPoint);
		sprite.texture.SetPixel((int)position.x, (int)position.y, Color.red);
	}

	Vector2 pixelCoordinates(Vector3 worldCoordinates) {

		Vector3 localPoint = transform.InverseTransformPoint(brush.position);
		Vector2 position = (Vector2)localPoint;

		Vector2 normCoord = (position - (Vector2)sprite.bounds.min);
		normCoord.x /= sprite.bounds.size.x;
		normCoord.y /= sprite.bounds.size.y;

		Vector2 pixelCoord = normCoord;
		pixelCoord.x *= sprite.textureRect.size.x;
		pixelCoord.y *= sprite.textureRect.size.y;

		return pixelCoord;
	}
}
