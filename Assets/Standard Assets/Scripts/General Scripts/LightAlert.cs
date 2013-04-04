using UnityEngine;
using System.Collections;

public class LightAlert : MonoBehaviour {
    public Color original;
    public Color alert;

    Color cur;
	// Use this for initialization
	void Start () {
        StartCoroutine(toggle()); 
	}

    IEnumerator toggle()
    {
        while (true)
        {
            if (cur == original)
                cur = alert;
            else
                cur = original;
            this.gameObject.light.color = cur;
            yield return new WaitForSeconds(.2f);
        }
    }
}
