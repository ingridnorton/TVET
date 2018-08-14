using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Purchase : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Debug.Log("gujhdsg");
        GameManagerScript.instance.GetLevel1();
    }
}
