﻿using UnityEngine;
using System.Collections;

public class Brush : MonoBehaviour {

	public int size;
	public Color color;

	private PaintArea canvas;
	private Color[] brush;
	
	public Color[] colors {
		get { return brush; }
	}

	// Use this for initialization
	void Start () {

		canvas = GameObject.Find("Canvas").GetComponent<PaintArea>();

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
	
	// Update is called once per frame
	void Update () {

		canvas.paint(this);
	}
}
