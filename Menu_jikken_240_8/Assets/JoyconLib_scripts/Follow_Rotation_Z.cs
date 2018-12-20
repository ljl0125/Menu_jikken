using System.Collections;
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

        if (Cursor_Test.is_L)
        {
            //左手の場合
            this.gameObject.transform.rotation = Quaternion.Euler(180.0f, 0.0f, (obj.transform.localEulerAngles.z - 90.0f));
            Debug.Log(this.gameObject.transform.rotation.eulerAngles.z);
            if (this.gameObject.transform.rotation.eulerAngles.z > 230.0f && this.gameObject.transform.rotation.eulerAngles.z < 290.0f)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(180.0f, 0.0f, 49.0f);
            }
            else if (this.gameObject.transform.rotation.eulerAngles.z > 290.0f && this.gameObject.transform.rotation.eulerAngles.z < 350.0f)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(180.0f, 0.0f, 170.0f);
            }
            else
            {
                this.gameObject.transform.rotation = Quaternion.Euler(180.0f, 0.0f, (obj.transform.localEulerAngles.z - 90.0f));
            }
        }
        else if (Cursor_Test.is_R)
        {
            //右手の場合
            this.gameObject.transform.rotation = Quaternion.Euler(180.0f, 0.0f, (obj.transform.localEulerAngles.z + 90.0f));

            if (this.gameObject.transform.rotation.eulerAngles.z > 0.0f && this.gameObject.transform.rotation.eulerAngles.z < 45.0f)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(180.0f, 0.0f, 179.0f);
            }
            else if (this.gameObject.transform.rotation.eulerAngles.z > 45.0f && this.gameObject.transform.rotation.eulerAngles.z < 90.0f)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(180.0f, 0.0f, 270.0f);
            }
            else
            {
                this.gameObject.transform.rotation = Quaternion.Euler(180.0f, 0.0f, (obj.transform.localEulerAngles.z + 90.0f));
            }
        }

        ////Joy-Con_Rの場合
        //this.gameObject.transform.rotation = Quaternion.Euler(180.0f, 0.0f, -(obj.transform.localEulerAngles.z - 270.0f));

    }
}
