using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper_Control : MonoBehaviour
{

    Color originalCol; //オリジナル色

    // Use this for initialization
    void Start()
    {
        originalCol = GetComponent<Renderer>().material.color; //オリジナル色の取得       
    }

    // Update is called once per frame
    void Update()
    {
    }

    //衝突検出
    void OnCollisionEnter(Collision collision)
    {
        Vector3 p0 = transform.position;  //自分自身の位置
        Vector3 p = collision.gameObject.transform.position;  //衝突物体の位置
        Vector3 v = p - p0;  //自分から衝突物体に向かうベクトル
                             //衝突物体にv方向の力を付与
        collision.gameObject.GetComponent<Rigidbody>().AddForce(v * 200);
        GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f); //白色に変更

        //パーティカルシステム再生開始
        GetComponent<ParticleSystem>().Play();

        //スコア処理を追加
        FindObjectOfType<Score>().AddPoint(50);
    }

    //         
    void OnCollisionExit(Collision collision)
    {
        GetComponent<Renderer>().material.color = originalCol; //オリジナル色に戻す         
    }
}
