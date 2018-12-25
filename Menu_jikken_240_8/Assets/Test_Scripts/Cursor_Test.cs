using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Test : MonoBehaviour {

    public GameObject Mesh_Degree;
    public GameObject Mesh_Parent;
    public GameObject Mesh_Start;
    public GameObject Rest;
    public static GameObject start;
    public static float degree = 30.0f;
    public static float degree_max = 240.0f;
    public static int now_num;
    public static bool flag_Random = false;
    public static bool flag_No = false;
    public static bool flag_Yes = false;
    public static bool flag_Reset = false;
    public static bool is_L = false;
    public static bool is_R = false;
    public bool flag_Copy = true;
    public int frame_count = 0;
    public static int count_all = 0;
    public static int count_yes = 0;
    public static int count_no = 0;
    public static int count_rest = 0;
    public static float time_start;
    public static float rest_time_start;

    //public static int[] nums = new int[(int)(degree_max / degree - 1) * 3];

    //public static int[] nums = new int[(int)(degree_max / degree - 1)];

    public static int[] nums = new int[(int)(degree_max / degree)];

    // Use this for initialization
    void Start () {

        start = Mesh_Start;
        start.SetActive(false);
        //start_name = ((int)(degree_max / degree - 1) / 2).ToString();
        now_num = (int)(degree_max / degree);

        Rest.SetActive(false);

        ////シャッフルするもとの配列
        //int[] random_num_1 = Enumerable.Range(0, (int)(degree_max / degree)).ToArray();
        //int[] random_num_2 = Enumerable.Range(0, (int)(degree_max / degree)).ToArray();
        //int[] random_num_3 = Enumerable.Range(0, (int)(degree_max / degree)).ToArray();

        ////using System.Linq;
        ////がソースファイルの一番上に書かれているものとする
        ////ランダムな順にソートされた配列
        //random_num_1 = random_num_1.OrderBy(i => Guid.NewGuid()).ToArray();
        //random_num_2 = random_num_2.OrderBy(i => Guid.NewGuid()).ToArray();
        //random_num_3 = random_num_3.OrderBy(i => Guid.NewGuid()).ToArray();

        ////配列を結合
        //int[] temp = new int[(int)(degree_max / degree) * 3];
        //random_num_1.CopyTo(temp, 0);
        //random_num_2.CopyTo(temp, (int)(degree_max / degree));
        //random_num_3.CopyTo(temp, (int)(degree_max / degree) * 2);

        //int j = 0;

        ////初期位置を除外
        //for (int i = 0; i < (degree_max / degree - 1) * 3; i++)
        //{
        //    if (temp[j] == int.Parse(start_name))
        //    {
        //        j++;
        //    }
        //    nums[i] = temp[j];
        //    j++;
        //}

        //結果を表示
        //for (int i = 0; i < (degree_max / degree - 1) * 3; i++)
        //{
        //    Debug.Log(i.ToString() + ":" + nums[i]);
        //}





        int[] random_num = Enumerable.Range(0, (int)(degree_max / degree)).ToArray();

        random_num = random_num.OrderBy(i => Guid.NewGuid()).ToArray();

        nums = random_num;

        //int j = 0;

        ////初期位置を除外
        //for (int i = 0; i < (degree_max / degree); i++)
        //{
        //    if (random_num[i] == int.Parse(start_name))
        //    {
        //        continue;
        //    }
        //    nums[j] = random_num[i];
        //    j++;
        //}

        ////結果を表示
        //for (int i = 0; i < (degree_max / degree - 2); i++)
        //{
        //    Debug.Log(i.ToString() + ":" + nums[i]);
        //}

    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyUp(KeyCode.L))
        {
            is_L = true;
            Debug.Log("L");
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            is_R = true;
            Debug.Log("R");
        }

        if (flag_Copy && (is_L || is_R))
        {
            start.SetActive(true);
            for (int i = 0; i < degree_max / degree; i++)
            {
                if (is_L)
                {
                    //左手の場合
                    Copy_Mesh(i, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(180.0f, 0.0f, degree * (-i - 1) + 140.0f));
                }
                else if (is_R)
                {
                    //右手の場合
                    Copy_Mesh(i, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(180.0f, 0.0f, degree * (i + 1) + 0.0f));
                }
            }
            Destroy(Mesh_Degree);
            flag_Copy = false;
        }

        if (!flag_Copy)
        {
            frame_count++;
        }

        if (frame_count == 5)
        {
            start.transform.localPosition = new Vector3(0.0f, 0.0f, -0.000001f);
            if (is_L)
            {
                start.transform.localRotation = Quaternion.Euler(180.0f, 0.0f, 15.0f);
            }
            else if (is_R)
            {
                start.transform.localRotation = Quaternion.Euler(180.0f, 0.0f, 145.0f);
            }
            start.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            for (int i = 0; i < degree_max / degree; i++)
            {
                GameObject.Find(i.ToString()).GetComponent<Renderer>().material.SetColor("_Color", Color.black);
            }
        }

        if (flag_Random)
        {
            start.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            for (int i = 0; i < degree_max / degree; i++)
            {
                GameObject.Find(i.ToString()).GetComponent<Renderer>().material.SetColor("_Color", Color.black);
            }
            now_num = nums[count_yes];
            GameObject.Find(now_num.ToString()).GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            flag_Random = false;
        }

        if (count_yes >= (degree_max / degree))
        {
            Destroy(Mesh_Parent);
            Rest.SetActive(true);
        }
        else if (count_rest >= 10)
        {
            Mesh_Parent.SetActive(false);
            Rest.SetActive(true);
            rest_time_start = Time.fixedTime;
            count_rest = 0;
        }

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
        if (other.gameObject.name == start.name)
        {
            flag_Reset = true;
        }

        if (other.gameObject.name != now_num.ToString() && other.gameObject.name != start.name && Example.flag_count_all)
        {
            other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            if (Example.flag_ZL || Example.flag_ZR)
            {
                flag_No = true;
                flag_Yes = false;
            }
        }
        else if (other.gameObject.name != now_num.ToString() && other.gameObject.name == start.name)
        {
            other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0.5f, 0.5f, 1.0f));

        }
        else if (other.gameObject.name == now_num.ToString())
        {
            other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(1.0f, 0.5f, 0.5f));
            if (Example.flag_ZL || Example.flag_ZR)
            {
                flag_Yes = true;
                flag_No = false;
            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == start.name)
        {
            flag_Reset = false;
        }

        if (other.gameObject.name != now_num.ToString() && other.gameObject.name != start.name)
        {
            other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        }
        else if (other.gameObject.name != now_num.ToString() && other.gameObject.name == start.name)
        {
            other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);

        }
        else
        {
            other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
    }
}
