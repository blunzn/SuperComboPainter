using UnityEngine;
using System.Collections;

public class Brush : MonoBehaviour {

	public int width = 21;
	public int height = 21;
	public Color[] brushColors = {Color.red, Color.green, Color.blue};
	public Texture2D texture;
	public string keyRed = "1";
	public string keyGreen = "2";
	public string keyBlue = "3";

	private PaintArea canvas;
	private Color[] brush;

	private Color brushColor;
	private int brushIndex;

	private bool doPaint;

	
	public Color[] colors {
		get { return brush; }
	}

	public Color color {
		get { return brushColor; }
		set {
			brushColor = value;

			if (texture != null)
			{
				brush = texture.GetPixels();
				width = texture.width;
				height = texture.height;

				for (int i = 0; i < brush.Length; i++)
				{
					brush[i] *= brushColor;
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
						
						Color color = brushColor;
						color.a = (centerOffset.magnitude < width/2) ? 1 : 0;
						brush[index] = color;
					}
				}
	}

		}
	}

	// Use this for initialization
	void Start () {

		canvas = GameObject.Find("Canvas").GetComponent<PaintArea>();
//		color = brushColors[0];
		doPaint = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(keyRed))
			color = brushColors[0];
		if (Input.GetKeyDown(keyBlue))
			color = brushColors[1];
		if (Input.GetKeyDown(keyGreen))
			color = brushColors[2];


		if (Input.GetKey(keyRed) || Input.GetKey(keyGreen) || Input.GetKey(keyBlue))
			doPaint = true;
		else
			doPaint = false;

		if (doPaint)
			canvas.paint(this);
	}
}
