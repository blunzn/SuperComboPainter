using UnityEngine;
using System.Collections;

public class Brush : MonoBehaviour {

	public int width = 21;
	public int height = 21;
	public Color color = Color.red;

	public Texture2D texture;

	private PaintArea canvas;
	private Color[] brush;
	
	public Color[] colors {
		get { return brush; }
	}

	// Use this for initialization
	void Start () {

		canvas = GameObject.Find("Canvas").GetComponent<PaintArea>();

		if (texture != null)
		{
			brush = texture.GetPixels();
			width = texture.width;
			height = texture.height;

			for (int i = 0; i < brush.Length; i++)
			{
				brush[i] *= color;
			}
		}
		else
		{
			brush = new Color[width * height];
			Vector2 centerOffset;
			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					int index = x + y*width;
					centerOffset.x = (width/2 + 1) - x;
					centerOffset.y = (height/2 + 1) - y;

					Color brushColor = color;
					brushColor.a = (centerOffset.magnitude < width/2) ? 1 : 0;
					brush[index] = brushColor;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		canvas.paint(this);
	}
}
