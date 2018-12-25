using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Position : MonoBehaviour {

    public GameObject obj;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.gameObject.transform.position = obj.transform.position;

    }

}
