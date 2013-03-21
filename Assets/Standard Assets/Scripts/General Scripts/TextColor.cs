using UnityEngine;
using System.Collections;

public class TextColor : MonoBehaviour {
	public float red, green, blue;
	GameObject cube;
	// Use this for initialization
	void Start () {
		Color color = new Color(red, green, blue);
		this.renderer.material.SetColor("_Color", color);	
		cube = GameObject.FindGameObjectWithTag("blockpath"); 

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("9")){
			TextMesh tex = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
			tex.text = "10";
			cube.transform.Translate(0, 0, -10);
		}
	}
}
