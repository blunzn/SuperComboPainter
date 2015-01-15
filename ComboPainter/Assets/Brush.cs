using UnityEngine;
using System.Collections;

public class Brush : MonoBehaviour {

	public int size;
	public Color color;
	public string keyGreen = "1";
	public string keyBlue = "2";

	private PaintArea canvas;
	private Color[] brush;

	private bool doPaint;

	
	public Color[] colors {
		get { return brush; }
	}

	// Use this for initialization
	void Start () {

		doPaint = false;
		canvas = GameObject.Find("Canvas").GetComponent<PaintArea>();


	}
	
	// Update is called once per frame
	void Update () {


		doPaint = true;
		if (Input.GetKey(keyGreen))
						setColor (Color.green);
				else if (Input.GetKey(keyBlue))
						setColor (Color.blue);
				else
						doPaint = false;

		if (doPaint)
			canvas.paint(this);
	}

	void setColor(Color color)
	{
				int width = size;
				int height = size;
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
