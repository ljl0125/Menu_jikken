﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(MeshRenderer))]
//[RequireComponent(typeof(MeshFilter))]

public class Mesh_Cursor : MonoBehaviour
{
    private Mesh mesh;
    [SerializeField]
    private Material _mat;

    public PhysicMaterial physicMaterial;

    public float r_in = 1.5f; //内側の円の半径
    public float r_out = 5.0f; //外側の円の半径
    public int div_num = 2000; //3の倍数にする

    public int central_angle = 1; //中心角

    float R_in = 0.0f; //内側の円の半径
    float R_out = 0.0f; //外側の円の半径
    int Div_num = 0; //3の倍数にする
    int Central_angle = 0; //中心角

    float rate = 0.0f;

    // Use this for initialization
    void Start()
    {
        //this.gameObject.AddComponent<MeshRenderer>();
        //this.gameObject.AddComponent<MeshFilter>();

        //扇型Meshの描画
        CreateMesh(r_in, r_out, div_num, central_angle);
        //this.gameObject.transform.localPosition += new Vector3(1.0f, 0.0f, 0.0f); 
        //this.gameObject.transform.localRotation = Quaternion.Euler(180.0f, 0.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        //rate += 1.0f;
        //this.gameObject.transform.localRotation = Quaternion.Euler(180.0f, 0.0f, rate);

        //前のフレームで描画した値と異なる場合再描画
        if ((R_in != r_in) || (R_out != r_out) || (Div_num != div_num) || (Central_angle != central_angle))
        {
            R_in = r_in; //内側の円の半径
            R_out = r_out; //外側の円の半径
            Div_num = div_num; //3の倍数にする
            Central_angle = central_angle; //中心角
            CreateMesh(R_in, R_out, Div_num, Central_angle);//扇型Meshの描画
        }

    }

    void CreateMesh(float r_in, float r_out, int div_num, int central_angle)
    {
        mesh = new Mesh();
        Vector3[] newVertices = new Vector3[div_num * 2];
        Vector2[] newUV = new Vector2[div_num * 2];

        int i = 0;
        int temp_angle = 0;

        for (i = 0; i < 2 * div_num; i++)
        {
            // 頂点座標の指定.
            if (i < div_num)
            {
                newVertices[i].x = r_out * Mathf.Cos(2.0f * Mathf.PI * (float)i / (float)div_num);
                newVertices[i].y = r_out * Mathf.Sin(2.0f * Mathf.PI * (float)i / (float)div_num);
                newVertices[i].z = 0.0f;
                newVertices[i] = newVertices[i] + this.transform.localPosition;
            }
            else
            {
                newVertices[i].x = r_in * Mathf.Cos(2.0f * Mathf.PI * ((float)i + 0.5f) / (float)div_num);
                newVertices[i].y = r_in * Mathf.Sin(2.0f * Mathf.PI * ((float)i + 0.5f) / (float)div_num);
                newVertices[i].z = 0.0f;
                newVertices[i] = newVertices[i] + this.transform.localPosition;
            }

            //円をどこで切るのかを決定
            if (central_angle > (180.0f * (float)i / (float)div_num))
            {
                temp_angle = i;
            }


            // UVの指定 (頂点数と同じ数を指定すること).
            if (i % 3 == 2)
            {
                newUV[i] = new Vector2(0.0f, 0.0f);
            }
            else if (i % 3 == 1)
            {
                newUV[i] = new Vector2(0.0f, 1.0f);
            }
            else if (i % 3 == 0)
            {
                newUV[i] = new Vector2(1.0f, 1.0f);
            }

        }

        //　決めた範囲のみ描画する
        int[] newTriangles = new int[temp_angle * 3 + 3];

        for (i = 0; i < temp_angle - 1; i++)
        {
            // 三角形ごとの頂点インデックスを指定.
            if (i % 2 == 0)
            {
                newTriangles[3 * i] = i / 2;
                newTriangles[3 * i + 1] = i / 2 + 1;
                newTriangles[3 * i + 2] = i / 2 + div_num;
            }
            else
            {
                newTriangles[3 * i] = i / 2 + div_num + 1;
                newTriangles[3 * i + 1] = i / 2 + div_num;
                newTriangles[3 * i + 2] = i / 2 + 1;

            }
        }

        //端の部分を補う
        newTriangles[3 * i] = 0;
        newTriangles[3 * i + 1] = div_num;
        newTriangles[3 * i + 2] = 2 * div_num - 1;

        i++;

        newTriangles[3 * i] = 0;
        newTriangles[3 * i + 1] = div_num * 2 - 1;
        newTriangles[3 * i + 2] = div_num - 1;

        //Mesh生成開始
        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        GetComponent<MeshFilter>().sharedMesh = mesh;
        GetComponent<MeshFilter>().sharedMesh.name = "myMesh";

        var renderer = GetComponent<MeshRenderer>();
        renderer.material = _mat;

        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
        if (!meshCollider) meshCollider = gameObject.AddComponent<MeshCollider>();

        meshCollider.sharedMesh = mesh;
        meshCollider.sharedMaterial = physicMaterial; //衝突判定付与
    }

}
