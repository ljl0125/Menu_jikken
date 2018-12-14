using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Or_Paper_L : MonoBehaviour {

    public static int count;
    public static bool flag_rock;
    public float enter_time_rock;
    public float enter_time_paper;
    public static bool flag_enter;
    public static bool flag_enter_stay;

    // Use this for initialization
    void Start () {

        count = 0;
        flag_rock = false;

        enter_time_rock = 0.00f;
        enter_time_paper = 0.00f;
        flag_enter = false;
        flag_enter_stay = true;

    }
	
	// Update is called once per frame
	void Update () {
		
        if(count >= 3)
        {
            //Debug.Log("グー");
            flag_rock = true;
            flag_enter_stay = false;
            enter_time_rock = Time.fixedTime;
        }
        else
        {
            //Debug.Log("バー,count:" + count);
            flag_rock = false;
            enter_time_paper = Time.fixedTime;
        }

        if(enter_time_paper > enter_time_rock && !flag_enter_stay)
        {
            flag_enter = true;
        }
        else
        {
            flag_enter = false;
        }

    }

    //オブジェクトが衝突したとき
    void OnTriggerEnter(Collider other)
    {

        switch (other.gameObject.tag)
        {
            case "L0":
                count++;
                break;
            case "L1":
                count++;
                break;
            case "L2":
                count++;
                break;
            case "L3":
                count++;
                break;
            case "L4":
                count++;
                break;
            default:
                break;
        }

    }

    //オブジェクトが離れた時
    void OnTriggerExit(Collider other)
    {

        switch (other.gameObject.tag)
        {
            case "L0":
                count--;
                break;
            case "L1":
                count--;
                break;
            case "L2":
                count--;
                break;
            case "L3":
                count--;
                break;
            case "L4":
                count--;
                break;
            default:
                break;
        }

    }

}
