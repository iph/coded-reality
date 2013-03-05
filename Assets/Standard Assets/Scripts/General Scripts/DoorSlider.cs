using UnityEngine;
using System.Collections;

public class DoorSlider : MonoBehaviour
{
	public float startX;
	public float startY;
	public float startZ;
	
	public float endX;
	public float endY;
	public float endZ;
	
	public int smooth = 2;
	
	public bool open = false;
		
	Vector3 target;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (open == false) {
			target = new Vector3(startX, startY, startZ);
		}
		
		if (open == true) {
			target = new Vector3(endX, endY, endZ);
		}
		//Vector3 temp = this.transform.localPosition;
		this.transform.localPosition = Vector3.Slerp(this.transform.localPosition, target, Time.deltaTime * smooth);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player")
		{
			open = true;
		}	
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "Player")
		{
			open = false;
		}	
	}
}