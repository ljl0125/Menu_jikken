using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Test : MonoBehaviour {

    public GameObject Mesh_Degree;
    public GameObject Mesh_Parent;
    public string start_name = "6";
    public static float degree = 1.0f;
    public static float degree_max = 360.0f;
    public static int now_num;
    public bool flag_Copy = true;
    public static bool flag_Random = false;
    public static bool flag_All = false;
    public static bool flag_Yes = false;
    public static bool flag_Reset = false;
    public static int count_all = 0;
    public static int count_yes = 0;
    public static float time_start;

    public static string now_name;

    // Use this for initialization
    void Start () {

        now_num = (int)(degree_max / degree);

    }

    // Update is called once per frame
    void Update () {

        if (flag_Copy)
        {
            for (int i = 0; i < degree_max / degree; i++)
            {
                //Copy_Mesh(i, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, degree * i - 90.0f));
                Copy_Mesh(i, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(180.0f, 0.0f, degree * (-i - 1) + 90.0f));
            }
            Destroy(Mesh_Degree);
            flag_Copy = false;
        }

        if (flag_Random)
        {
            for (int i = 0; i < degree_max / degree; i++)
            {
                GameObject.Find(i.ToString()).GetComponent<Renderer>().material.SetColor("_Color", Color.black);
            }
            now_num = new System.Random().Next(0, (int)(degree_max / degree));
            //GameObject.Find("0").GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            flag_Random = false;
        }

        if (count_all >= 20)
        {
            for (int i = 0; i < degree_max / degree; i++)
            {
                Destroy(GameObject.Find(i.ToString()));
            }
        }

        //グラデーション
        //for (int i = 0; i < degree_max / degree; i++)
        //{
        //    GameObject.Find(i.ToString()).GetComponent<Renderer>().material.SetColor("_Color", Color.HSVToRGB(i * degree / degree_max, 1.0f, 1.0f));
        //}

    }

    void Copy_Mesh(int i, Vector3 position, Vector3 rotation)
    {
        GameObject Copied = Instantiate(Mesh_Degree, Mesh_Parent.transform);

        Copied.name = i.ToString();
        Copied.transform.localPosition = position;
        Copied.transform.localRotation = Quaternion.Euler(rotation);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == start_name)
        {
            flag_Reset = true;
        }

        //if (other.gameObject.name != "0")
        //{
        //    other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        //    if (Example.flag_ZL || Example.flag_ZR)
        //    {
        //        flag_All = true;
        //    }
        //}
        //else
        //{
        //    other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0.5f, 0.5f, 0.0f));
        //    if (Example.flag_ZL || Example.flag_ZR)
        //    {
        //        flag_Yes = true;
        //    }
        //}

        other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        if (Example.flag_ZL || Example.flag_ZR)
        {
            flag_All = true;
            now_name = other.gameObject.name;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == start_name)
        {
            flag_Reset = false;
        }

        other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        //if (other.gameObject.name != "0")
        //{
        //    other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        //}
        //else
        //{
        //    other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        //}
    }
}
