﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Rotation_Z : MonoBehaviour {

    public GameObject obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //if (Example.flag_ZL)
        //{
        //    //Joy-Con_Lの場合
        //    this.gameObject.transform.rotation = Quaternion.Euler(180.0f, 0.0f, (obj.transform.localEulerAngles.z + 180.0f));
        //}
        //else if (Example.flag_ZR)
        //{
        //    //Joy-Con_Rの場合
        //    this.gameObject.transform.rotation = Quaternion.Euler(180.0f, 0.0f, -(obj.transform.localEulerAngles.z - 180.0f));
        //}

        //Joy-Con_Lの場合
        this.gameObject.transform.rotation = Quaternion.Euler(180.0f, 0.0f, (obj.transform.localEulerAngles.z - 90.0f));

        ////Joy-Con_Rの場合
        //this.gameObject.transform.rotation = Quaternion.Euler(180.0f, 0.0f, -(obj.transform.localEulerAngles.z - 270.0f));

    }
}
