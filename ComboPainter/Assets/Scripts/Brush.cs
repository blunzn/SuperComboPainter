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

	private int mipLevel = 0;
	private PaintArea canvas;
	private Color[] brush;

	private Color brushColor;
	private int brushIndex;

	private bool doPaint;
	
	public Color[] colors {
		get { return brush; }
	}

	private Color color {
		get { return brushColor; }
		set {
			brushColor = value;

			if (texture != null)
			{
				brush = texture.GetPixels(mipLevel);
				width = Mathf.Max(1,texture.width >> mipLevel);
				height = Mathf.Max(1,texture.height >> mipLevel);

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

		canvas = GameObject.Find("PaintCanvas").GetComponent<PaintArea>();
//		color = brushColors[0];
		doPaint = false;
		brushIndex = -1;
	}
	
	// Update is called once per frame
	void Update () {

		bool color1 = Input.GetAxis("color1") > 0;
		bool color2 = Input.GetAxis("color2") > 0;
		bool color3 = Input.GetAxis("color3") > 0;

		CharacterManager manager = GameObject.Find ("GameController").GetComponent<CharacterManager> ();

		if (manager.finehide != mipLevel)
		{
			mipLevel = manager.finehide;
			color = brushColors[Mathf.Max(brushIndex,0)];
		}

		int index = (color1) ? 0 : (color2) ? 1 : (color3) ? 2 : brushIndex;
//		print (index);
		if (brushIndex != index)
			color = brushColors[index];
		brushIndex = index;

		doPaint = color1 || color2 || color3;

		if (doPaint)
			canvas.paint(this);
	}
}
