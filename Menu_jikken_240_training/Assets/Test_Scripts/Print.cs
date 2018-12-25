using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Print : MonoBehaviour {

    public GameObject Mesh_Parent;
    //抽選
    int[] turn = { 4, 5, 6, 8, 10, 12, 15, 16, 20, 24 };

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //抽選
        if (Input.GetKey(KeyCode.Space))
        {
            this.gameObject.GetComponent<TextMesh>().text = "";
            turn = turn.OrderBy(i => Guid.NewGuid()).ToArray();
            int j;
            for (j = 0; j < turn.Length; j++)
            {
                this.gameObject.GetComponent<TextMesh>().text += turn[j].ToString();
                if ( j < turn.Length - 1)
                {
                    this.gameObject.GetComponent<TextMesh>().text += ",";
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            this.gameObject.GetComponent<TextMesh>().text = "";
        }


        if (Input.GetKeyUp(KeyCode.S))
        {
            Cursor_Test.count_yes = 0;
            Cursor_Test.now_num = (int)(Cursor_Test.degree_max / Cursor_Test.degree);
            Cursor_Test.nums = Cursor_Test.nums.OrderBy(i => Guid.NewGuid()).ToArray();
            Mesh_Parent.gameObject.SetActive(true);
        }
        else if (Cursor_Test.count_yes >= (Cursor_Test.degree_max / Cursor_Test.degree))
        {
            Mesh_Parent.gameObject.SetActive(false);
        }

    }
}
