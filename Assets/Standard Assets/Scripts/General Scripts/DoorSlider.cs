using UnityEngine;
using System.Collections;

public class DoorSlider : MonoBehaviour
{
	// copy this in from the position information
	public float startX, startY, startZ;
	
	// this is where you want to end up
	// (typically just adjust one axis' variable)
	public float endX, endY, endZ;
	
	// adjust this to change the slide speed
	public int smooth = 2;
	
	public bool open = false; 	// if open, then move to the end
	public bool active = true;	// won't move unless active is true
	
	// where the door is moving
	Vector3 target;
	public void SetActive(){
		active = true;
	}
	// Use this for initialization
	void Start ()
	{
		// could maybe do some stuff here to determine initial values?
	}
	
	// Update is called once per frame
	void Update ()
	{
		// set the target based on whether door is open or not
		if (open == false) {
			target = new Vector3(startX, startY, startZ);
		}
		
		if (open == true) {
			target = new Vector3(endX, endY, endZ);
		}
	
		// only move if active, and slerp to move smoothly
		if (this.active) {
			this.transform.localPosition = Vector3.Slerp(this.transform.localPosition, target, Time.deltaTime * smooth);
		}
	}
	
	// when the player enters, this happens
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player")
		{
			open = true;
		}	
	}
	
	// when the player leaves, this happens
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "Player")
		{
			open = false;
		}	
	}
}