using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest_Time : MonoBehaviour {

    public GameObject Mesh_Parent;
    float rest_time = 120.0f;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (this.gameObject.activeSelf)
        {
            if (Cursor_Test.count_yes >= (Cursor_Test.degree_max / Cursor_Test.degree))
            {
                this.gameObject.GetComponent<TextMesh>().text = "終了！";
            }
            else
            {
                this.gameObject.GetComponent<TextMesh>().text = "休憩時間残り：" + (rest_time - (Time.fixedTime - Cursor_Test.rest_time_start)).ToString("f0") + "秒";
            }

            if (Time.fixedTime - Cursor_Test.rest_time_start >= rest_time || Input.GetKeyUp(KeyCode.Space))
            {
                Mesh_Parent.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}
