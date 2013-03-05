
// Use this for initialization
function Start () {
}

// Update is called once per frame
function Update () {

var direction = transform.TransformDirection(Vector3.forward);
var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
var hit : RaycastHit;
 
if(Physics.Raycast(ray, hit, range)){
	if(hit.transform.tag == door){
		hit.transform.rotation = Vector3(0, 90, 0);
	}
//or you can use:
//hit.transform.Rotate untill its reached 90
}


}

