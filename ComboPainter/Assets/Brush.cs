using UnityEngine;
using System.Collections;

public class Brush : MonoBehaviour {

	private PaintArea canvas;

	// Use this for initialization
	void Start () {

		canvas = GameObject.Find("Canvas").GetComponent<PaintArea>();
	}
	
	// Update is called once per frame
	void Update () {

		canvas.paintAt(transform.position);
	}
}
