using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Controller : MonoBehaviour {

    public Color color_normal;
    public Color color_exit;
    public GameObject Menu_All;
    public GameObject Menu_0_Up;
    public GameObject Menu_0_Left;
    public GameObject Menu_0_Down;
    public GameObject Menu_0_Right;
    public bool flag_Menu_0_Up;
    public bool flag_Menu_0_Left;
    public bool flag_Menu_0_Down;
    public bool flag_Menu_0_Right;
    public bool flag_hit_Menu_0_Up;
    public bool flag_hit_Menu_0_Left;
    public bool flag_hit_Menu_0_Down;
    public bool flag_hit_Menu_0_Right;
    public float start_time;
    public float Scale_start;
    public float Scale_end;
    public float Scale_plus;
    public Material[] material;

    public GameObject Mesh_Degree;
    public GameObject Mesh_Parent;
    public float degree = 10.0f;
    public bool flag_Copy = true;

    // Use this for initialization
    void Start () {

        color_normal = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        color_exit = new Color(1.0f, 1.0f, 1.0f, 0.2f);

        flag_Menu_0_Up = false;
        flag_Menu_0_Left = false;
        flag_Menu_0_Down = false;
        flag_Menu_0_Right = false;
        flag_hit_Menu_0_Up = false;
        flag_hit_Menu_0_Left = false;
        flag_hit_Menu_0_Down = false;
        flag_hit_Menu_0_Right = false;

        Scale_start = 5.00f;
        Scale_end = 6.00f;
        Scale_plus = (Scale_end - Scale_start) * 2.00f * Time.deltaTime;                //1秒当たり(Scale_end-Scale_start)*2増やす

        Menu_0_Up.GetComponent<Renderer>().material.SetColor("_Color", color_exit);

        Menu_0_Right.GetComponent<Renderer>().material.SetColor("_Color", color_exit);

        Menu_0_Down.GetComponent<Renderer>().material.SetColor("_Color", color_exit);

        Menu_0_Left.GetComponent<Renderer>().material.SetColor("_Color", color_exit);

    }

    // Update is called once per frame
    void Update () {

        if (flag_Copy)
        {
            for (int i = 0; i < 180.0f / degree; i++)
            {
                Copy_Mesh(i, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, degree * i));
                Copy_Mesh(i, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(180.0f, 0.0f, 180.0f + degree * i));
            }
            Destroy(Mesh_Degree);
            flag_Copy = false;
        }

        if ((Example.flag_ZL || Example.flag_ZR) && Hit.flag_hit)
        {
            flag_Menu_0_Up = false;
            flag_Menu_0_Left = false;
            flag_Menu_0_Down = false;
            flag_Menu_0_Right = false;
            flag_hit_Menu_0_Up = false;
            flag_hit_Menu_0_Left = false;
            flag_hit_Menu_0_Down = false;
            flag_hit_Menu_0_Right = false;
            Menu_0_Up.GetComponent<Renderer>().material.SetColor("_Color", color_exit);
            Menu_0_Right.GetComponent<Renderer>().material.SetColor("_Color", color_exit);
            Menu_0_Down.GetComponent<Renderer>().material.SetColor("_Color", color_exit);
            Menu_0_Left.GetComponent<Renderer>().material.SetColor("_Color", color_exit);
            Example.flag_enter = false;
            Example.flag_enter_stay = true;
        }
        else if (!(Example.flag_ZL || Example.flag_ZR) && Hit.flag_hit)
        {
            Hit.flag_hit = false;
            Menu_All.SetActive(false);
        }
        else if (!(Example.flag_ZL || Example.flag_ZR) && !Hit.flag_hit)
        {
            Menu_All.SetActive(false);
            if (flag_hit_Menu_0_Up && Example.flag_enter)
            {
                Create_Cube("Cube_1", 0, new Vector3(0.0f, 0.0f, 0.0f));
                flag_hit_Menu_0_Up = false;
                Example.flag_enter = false;
                Example.flag_enter_stay = true;
            }
            else if (flag_hit_Menu_0_Right && Example.flag_enter)
            {
                Create_Cube("Cube_4", 3, new Vector3(0.0f, 0.0f, 0.1f));
                flag_hit_Menu_0_Right = false;
                Example.flag_enter = false;
                Example.flag_enter_stay = true;
            }
            else if (flag_hit_Menu_0_Down && Example.flag_enter)
            {
                Create_Cube("Cube_3", 2, new Vector3(-0.1f, 0.0f, 0.0f));
                flag_hit_Menu_0_Down = false;
                Example.flag_enter = false;
                Example.flag_enter_stay = true;
            }
            else if (flag_hit_Menu_0_Left && Example.flag_enter)
            {
                Create_Cube("Cube_2", 1, new Vector3(0.1f, 0.0f, 0.0f));
                flag_hit_Menu_0_Left = false;
                Example.flag_enter = false;
                Example.flag_enter_stay = true;
            }
        }
        else if ((Example.flag_ZL || Example.flag_ZR) && !Hit.flag_hit)
        {
            Menu_All.SetActive(true);
        }


        if (flag_Menu_0_Up)
        {
            flag_hit_Menu_0_Up = true;
            flag_hit_Menu_0_Left = false;
            flag_hit_Menu_0_Down = false;
            flag_hit_Menu_0_Right = false;
            Menu_0_Up.GetComponent<Renderer>().material.SetColor("_Color", color_normal);
            if (Menu_0_Up.transform.localScale.x < Scale_end && Menu_0_Up.transform.localScale.y < Scale_end)
            {
                Menu_0_Up.transform.localScale += new Vector3(Scale_plus, Scale_plus, 0.00f);
            }
            if (Menu_0_Up.transform.localPosition.y < 0.04f)
            {
                Menu_0_Up.transform.localPosition += new Vector3(0.00f, 0.01f, 0.00f);
            }
        }
        else
        {
            Menu_0_Up.GetComponent<Renderer>().material.SetColor("_Color", color_exit);
            Menu_0_Up.transform.localScale = new Vector3(Scale_start, Scale_start, Menu_0_Up.transform.localScale.z);
            Menu_0_Up.transform.localPosition = new Vector3(0.00f, 0.00f, 0.00f);
        }

        if (flag_Menu_0_Right)
        {
            flag_hit_Menu_0_Up = false;
            flag_hit_Menu_0_Left = false;
            flag_hit_Menu_0_Down = false;
            flag_hit_Menu_0_Right = true;
            Menu_0_Right.GetComponent<Renderer>().material.SetColor("_Color", color_normal);
            if (Menu_0_Right.transform.localScale.x < Scale_end && Menu_0_Right.transform.localScale.y < Scale_end)
            {
                Menu_0_Right.transform.localScale += new Vector3(Scale_plus, Scale_plus, 0.00f);
            }
            if (Menu_0_Right.transform.localPosition.x < 0.04f)
            {
                Menu_0_Right.transform.localPosition += new Vector3(0.01f, 0.00f, 0.00f);
            }
        }
        else
        {
            Menu_0_Right.GetComponent<Renderer>().material.SetColor("_Color", color_exit);
            Menu_0_Right.transform.localScale = new Vector3(Scale_start, Scale_start, Menu_0_Right.transform.localScale.z);
            Menu_0_Right.transform.localPosition = new Vector3(0.00f, 0.00f, 0.00f);
        }

        if (flag_Menu_0_Down)
        {
            flag_hit_Menu_0_Up = false;
            flag_hit_Menu_0_Left = false;
            flag_hit_Menu_0_Down = true;
            flag_hit_Menu_0_Right = false;
            Menu_0_Down.GetComponent<Renderer>().material.SetColor("_Color", color_normal);
            if (Menu_0_Down.transform.localScale.x < Scale_end && Menu_0_Down.transform.localScale.y < Scale_end)
            {
                Menu_0_Down.transform.localScale += new Vector3(Scale_plus, Scale_plus, 0.00f);
            }
            if (Menu_0_Down.transform.localPosition.y > -0.04f)
            {
                Menu_0_Down.transform.localPosition += new Vector3(0.00f, -0.01f, 0.00f);
            }
        }
        else
        {
            Menu_0_Down.GetComponent<Renderer>().material.SetColor("_Color", color_exit);
            Menu_0_Down.transform.localScale = new Vector3(Scale_start, Scale_start, Menu_0_Down.transform.localScale.z);
            Menu_0_Down.transform.localPosition = new Vector3(0.00f, 0.00f, 0.00f);
        }

        if (flag_Menu_0_Left)
        {
            flag_hit_Menu_0_Up = false;
            flag_hit_Menu_0_Left = true;
            flag_hit_Menu_0_Down = false;
            flag_hit_Menu_0_Right = false;
            Menu_0_Left.GetComponent<Renderer>().material.SetColor("_Color", color_normal);
            if (Menu_0_Left.transform.localScale.x < Scale_end && Menu_0_Left.transform.localScale.y < Scale_end)
            {
                Menu_0_Left.transform.localScale += new Vector3(Scale_plus, Scale_plus, 0.00f);
            }
            if (Menu_0_Left.transform.localPosition.x > -0.04f)
            {
                Menu_0_Left.transform.localPosition += new Vector3(-0.01f, 0.00f, 0.00f);
            }
        }
        else
        {
            Menu_0_Left.GetComponent<Renderer>().material.SetColor("_Color", color_exit);
            Menu_0_Left.transform.localScale = new Vector3(Scale_start, Scale_start, Menu_0_Left.transform.localScale.z);
            Menu_0_Left.transform.localPosition = new Vector3(0.00f, 0.00f, 0.00f);
        }

    }

    void Create_Cube(string name, int material_num, Vector3 position)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = name;
        cube.tag = "Obj";
        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Rigidbody>().useGravity = false;
        cube.GetComponent<Rigidbody>().isKinematic = true;
        cube.transform.position = position;
        cube.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        cube.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        cube.GetComponent<Renderer>().material = material[material_num];
        Destroy(cube, 1.00f);
    }

    void Copy_Mesh(int i, Vector3 position, Vector3 rotation)
    {
        GameObject Copied = Instantiate(Mesh_Degree, Mesh_Parent.transform);

        Copied.name = i.ToString();
        Copied.transform.localPosition = position;
        Copied.transform.localRotation = Quaternion.Euler(rotation);
    }

    //オブジェクトが衝突したとき
    void OnTriggerStay(Collider other)
    {
        if (!Hit.flag_hit)
        {
            switch (other.gameObject.tag)
            {
                case "Menu_Up":
                    flag_Menu_0_Up = true;
                    break;
                case "Menu_Left":
                    flag_Menu_0_Left = true;
                    break;
                case "Menu_Down":
                    flag_Menu_0_Down = true;
                    break;
                case "Menu_Right":
                    flag_Menu_0_Right = true;
                    break;
                default:
                    break;
            }
        }

    }

    //オブジェクトが離れた時
    void OnTriggerExit(Collider other)
    {

        switch (other.gameObject.tag)
        {
            case "Menu_Up":
                flag_Menu_0_Up = false;
                break;
            case "Menu_Left":
                flag_Menu_0_Left = false;
                break;
            case "Menu_Down":
                flag_Menu_0_Down = false;
                break;
            case "Menu_Right":
                flag_Menu_0_Right = false;
                break;
            default:
                break;
        }

    }

}
