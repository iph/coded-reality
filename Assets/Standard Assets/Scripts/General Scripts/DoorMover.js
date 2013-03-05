#pragma strict

int layerMask = 1 << 8;

// Use this for initialization
function Start () {
}

// Update is called once per frame
function Update () {
    var fwd = transform.TransformDirection (Vector3.forward);
    if (Physics.Raycast (transform.position, fwd, 10, layerMask)) {
        print ("Door!!!!");
    }
}
