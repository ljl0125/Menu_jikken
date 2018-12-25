using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

    public static bool flag_hit;

    // Use this for initialization
    void Start () {

        flag_hit = false;

	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log("World:" + GameObject.Find("Cube0").transform.eulerAngles.ToString("F4"));
        //Debug.Log("Local:" + GameObject.Find("Cube0").transform.localPosition.ToString("F4"));

    }

    //オブジェクトが衝突したとき
    void OnTriggerEnter(Collider other) {

        if(other.gameObject.name == "Menu_0")
        {
            flag_hit = true;
        }

    }

    //オブジェクトが離れた時
    void OnTriggerExit(Collider other) {

        if (other.gameObject.name == "Menu_0")
        {
            flag_hit = false;
        }

    }

    //オブジェクトが触れている間
    void OnTriggerStay(Collider other) {

        if (Rock_Or_Paper_R.flag_rock && other.gameObject.tag == "Obj")
        {
            other.gameObject.transform.position = this.transform.position;
            other.gameObject.transform.rotation = this.transform.rotation;
        }

    }

}
