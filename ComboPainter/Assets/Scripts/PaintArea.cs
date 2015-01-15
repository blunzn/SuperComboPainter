using UnityEngine;
using System.Collections;

public class PaintArea : MonoBehaviour {

	private Sprite sprite;

	private Color[] original;

	// Use this for initialization
	void Start () {

		sprite = GetComponent<SpriteRenderer>().sprite;
		original = sprite.texture.GetPixels();
	}
	
	// Update is called once per frame
	void Update () {

		sprite.texture.Apply();

		if (Input.GetKeyDown(KeyCode.Backspace))
			clear();
	}

	void OnApplicationQuit() {

		clear();
	}

	public void clear() {

		sprite.texture.SetPixels(original);
	}

	public void paint(Brush brush) {

		Vector2 position = pixelCoordinates(brush.transform.position);
		int x = (int)position.x - (brush.width / 2) + 1;
		int y = (int)position.y - (brush.height / 2) + 1;

		Color[] canvasColors = sprite.texture.GetPixels(x, y, brush.width, brush.height);
		Color[] brushColors = brush.colors;
		Color[] colors = new Color[brush.colors.Length];

		for (int i = 0; i < colors.Length; i++) {
			colors[i] = Color.Lerp(canvasColors[i], brushColors[i], brushColors[i].a );
			colors[i].a = 1f;
		}

		sprite.texture.SetPixels(x, y, brush.width, brush.height, colors);
	}

	Vector2 pixelCoordinates(Vector3 worldCoordinates) {

		Vector3 localPoint = transform.InverseTransformPoint(worldCoordinates);
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
