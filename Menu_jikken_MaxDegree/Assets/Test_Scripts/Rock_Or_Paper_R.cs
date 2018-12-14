using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Or_Paper_R : MonoBehaviour
{

    public static int count;
    public static bool flag_rock;

    // Use this for initialization
    void Start()
    {

        count = 0;
        flag_rock = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (count >= 3)
        {
            //Debug.Log("グー");
            flag_rock = true;
        }
        else
        {
            //Debug.Log("バー,count:" + count);
            flag_rock = false;
        }

    }

    //オブジェクトが衝突したとき
    void OnTriggerEnter(Collider other)
    {

        switch (other.gameObject.tag)
        {
            case "R0":
                count++;
                break;
            case "R1":
                count++;
                break;
            case "R2":
                count++;
                break;
            case "R3":
                count++;
                break;
            case "R4":
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
            case "R0":
                count--;
                break;
            case "R1":
                count--;
                break;
            case "R2":
                count--;
                break;
            case "R3":
                count--;
                break;
            case "R4":
                count--;
                break;
            default:
                break;
        }

    }

}