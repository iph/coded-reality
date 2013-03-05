using UnityEngine;
using System.Collections;

public class TerminalSwap : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag("MainCamera"); 
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("1")){
			player.camera.enabled = false;
			this.camera.enabled = true;
		}
		else if(Input.GetKeyDown("2")){
			player.camera.enabled = true;
			this.camera.enabled = false;			
		}
	}
		
}
