using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Rotation : MonoBehaviour {

    public float angle;
    public Vector3 axis;
    public float temp;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------
        //手法1

        //if (Example.flag_ZL)
        //{
        //    //Joy-Con_Lの場合
        //    Example.rotation_L.ToAngleAxis(out angle, out axis);
        //}
        //else if (Example.flag_ZR)
        //{
        //    //Joy-Con_Rの場合
        //    Example.rotation_R.ToAngleAxis(out angle, out axis);
        //}

        //z軸が奥に向いている場合
        /*
        axis.x = -axis.x;
        temp = axis.y;
        axis.y = axis.z;
        axis.z = -temp;
        */

        ////右手座標系に変換
        //temp = axis.x;
        //axis.x = axis.y;
        //axis.y = axis.z;
        //axis.z = -temp;

        //this.gameObject.transform.rotation = Quaternion.AngleAxis(-angle, axis);


        //----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------

        //手法2

        if (Example.flag_isL)
        {
            //Joy-Con_Lの場合
            this.gameObject.transform.rotation = new Quaternion(Example.rotation_L.w, Example.rotation_L.x, Example.rotation_L.z, Example.rotation_L.y);
        }
        else if (!Example.flag_isL)
        {
            //Joy-Con_Rの場合
            this.gameObject.transform.rotation = new Quaternion(Example.rotation_R.w, Example.rotation_R.x, Example.rotation_R.z, Example.rotation_R.y);
        }

    }
}
