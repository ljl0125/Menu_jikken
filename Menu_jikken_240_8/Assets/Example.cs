using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;
using System.IO;

public class Example : MonoBehaviour
{
    private static readonly Joycon.Button[] m_buttons =
        Enum.GetValues(typeof(Joycon.Button)) as Joycon.Button[];

    private List<Joycon> m_joycons;
    private Joycon m_joyconL;
    private Joycon m_joyconR;
    private Joycon.Button? m_pressedButtonL;
    private Joycon.Button? m_pressedButtonR;

    public static Quaternion rotation_L;
    public static Quaternion rotation_R;
    public static bool flag_L;
    public static bool flag_R;
    public static bool flag_ZL;
    public static bool flag_ZR;
    public static bool flag_isL;
    public float enter_time_rock;
    public float enter_time_paper;
    public static bool flag_enter;
    public static bool flag_enter_stay;
    public bool flag_count_all;

    int count_error;

    public string path = @"D:\Menu_jikken_9\Data\Data01.csv";

    void Start()
    {
        flag_L = false;
        flag_R = false;
        flag_ZL = false;
        flag_ZR = false;
        flag_isL = false;

        enter_time_rock = 0.00f;
        enter_time_paper = 0.00f;
        flag_enter = false;
        flag_enter_stay = true;

        flag_count_all = false;

        count_error = 0;

        m_joycons = JoyconManager.Instance.j;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        m_joyconL = m_joycons.Find(c => c.isLeft);
        m_joyconR = m_joycons.Find(c => !c.isLeft);




        // ファイル書き出し
        // 現在のフォルダにsaveData.csvを出力する(決まった場所に出力したい場合は絶対パスを指定してください)
        // 引数説明：第1引数→ファイル出力先, 第2引数→ファイルに追記(true)or上書き(false), 第3引数→エンコード
        StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("Shift_JIS"));
        // ヘッダー出力
        string[] s1 = { "正解数", "全エラー回数", "選択回数", "選択時間", "エラー回数", "正解番号" };
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        // StreamWriterを閉じる
        sw.Close();
    }

    void Update()
    {
        m_pressedButtonL = null;
        m_pressedButtonR = null;

        if (m_joycons == null || m_joycons.Count <= 0)
        {
            Debug.Log("Joy-Con が接続されていません");
            return;
        }

        //if (!m_joycons.Any(c => c.isLeft))
        //{
        //    Debug.Log("Joy-Con (L) が接続されていません");
        //    return;
        //}

        //if (!m_joycons.Any(c => !c.isLeft))
        //{
        //    Debug.Log("Joy-Con (R) が接続されていません");
        //    return;
        //}

        if (m_joycons == null || m_joycons.Count <= 0) return;

        foreach (var joycon in m_joycons)
        {
            var isLeft = joycon.isLeft;
            //var name = isLeft ? "Joy-Con (L)" : "Joy-Con (R)";
            //var key = isLeft ? "Z キー" : "X キー";
            //var button = isLeft ? m_pressedButtonL : m_pressedButtonR;
            //var stick = joycon.GetStick();
            //var gyro = joycon.GetGyro();
            //var accel = joycon.GetAccel();
            var orientation = joycon.GetVector();

            if (isLeft)
            {
                flag_isL = true;
                rotation_L = orientation;
            }
            if (!isLeft)
            {
                flag_isL = false;
                rotation_R = orientation;
            }

        }

        //Lを押したら
        if (m_joyconL.GetButtonDown(Joycon.Button.SHOULDER_1))
        {
            flag_L = true;
        }
        else if (m_joyconL.GetButtonUp(Joycon.Button.SHOULDER_1))
        {
            flag_L = false;

            if (Cursor_Test.flag_Reset)
            {
                Cursor_Test.flag_Random = true;
                Cursor_Test.flag_Reset = false;
                flag_count_all = true;
                Cursor_Test.time_start = Time.fixedTime;
            }
        }

        //ZLを押したら
        if (m_joyconL.GetButtonDown(Joycon.Button.SHOULDER_2))
        {
            flag_ZL = true;
        }
        else if (m_joyconL.GetButtonUp(Joycon.Button.SHOULDER_2))
        {
            flag_ZL = false;

            if (Cursor_Test.flag_No && flag_count_all)
            {
                count_error++;
                Cursor_Test.count_no++;
                Cursor_Test.count_all++;
                Cursor_Test.flag_No = false;
            }

            if (Cursor_Test.flag_Yes && flag_count_all)
            {
                Cursor_Test.count_yes++;
                Cursor_Test.count_all++;
                Debug.Log("No:" + Cursor_Test.count_no + ",now_num:" + Cursor_Test.now_num);
                Debug.Log("Yes:" + Cursor_Test.count_yes + ",All:" + Cursor_Test.count_all);
                Cursor_Test.flag_Yes = false;
                flag_count_all = false;
                Debug.Log((Time.fixedTime - Cursor_Test.time_start).ToString("f2"));

                //データ出力
                StreamWriter sw = new StreamWriter(path, true, Encoding.GetEncoding("Shift_JIS"));
                string[] s1 = { Cursor_Test.count_yes.ToString(), Cursor_Test.count_no.ToString(), Cursor_Test.count_all.ToString(), (Time.fixedTime - Cursor_Test.time_start).ToString("f2"), count_error.ToString(), Cursor_Test.now_num.ToString() };
                string s2 = string.Join(",", s1);
                sw.WriteLine(s2);
                // StreamWriterを閉じる
                sw.Close();
                count_error = 0;

                if (Cursor_Test.flag_Even)
                {
                    GameObject.Find(Cursor_Test.start_name).transform.localPosition = new Vector3(0.0f, 0.0f, -0.000001f);
                    GameObject.Find(Cursor_Test.start_name).GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                    for (int i = 0; i < Cursor_Test.degree_max / Cursor_Test.degree; i++)
                    {
                        if (i == int.Parse(Cursor_Test.sub_start_name_1) || i == int.Parse(Cursor_Test.sub_start_name_2))
                        {
                            GameObject.Find(i.ToString()).GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                        }
                        else
                        {
                            GameObject.Find(i.ToString()).GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                        }
                    }
                }
                else if (!Cursor_Test.flag_Even)
                {
                    for (int i = 0; i < Cursor_Test.degree_max / Cursor_Test.degree; i++)
                    {
                        if (i == int.Parse(Cursor_Test.start_name))
                        {
                            GameObject.Find(i.ToString()).GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                        }
                        else
                        {
                            GameObject.Find(i.ToString()).GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                        }
                    }
                }
                Cursor_Test.now_num = (int)(Cursor_Test.degree_max / Cursor_Test.degree);
            }
        }

        ////ZRを押したら
        //if (m_joyconR.GetButtonDown(Joycon.Button.SHOULDER_2))
        //{
        //    flag_ZR = true;
        //}
        //else if (m_joyconR.GetButtonUp(Joycon.Button.SHOULDER_2))
        //{
        //    flag_ZR = false;
        //}


        ////ZLを押したら
        //if (m_joyconL.GetButtonDown(Joycon.Button.SHOULDER_2))
        //{
        //    flag_ZL = true;
        //    flag_enter_stay = false;
        //    enter_time_rock = Time.fixedTime;
        //}
        //else if (m_joyconL.GetButtonUp(Joycon.Button.SHOULDER_2))
        //{
        //    flag_ZL = false;
        //    enter_time_paper = Time.fixedTime;
        //}

        ////ZRを押したら
        //if (m_joyconR.GetButtonDown(Joycon.Button.SHOULDER_2))
        //{
        //    flag_ZR = true;
        //    flag_enter_stay = false;
        //    enter_time_rock = Time.fixedTime;
        //}
        //else if (m_joyconR.GetButtonUp(Joycon.Button.SHOULDER_2))
        //{
        //    flag_ZR = false;
        //    enter_time_paper = Time.fixedTime;
        //}

        //if (enter_time_paper > enter_time_rock && !flag_enter_stay)
        //{
        //    flag_enter = true;
        //}
        //else
        //{
        //    flag_enter = false;
        //}

    }

}