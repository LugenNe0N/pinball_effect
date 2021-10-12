using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperR_Control : MonoBehaviour
{
    Vector3 p, up;
    int flg;

    // Use this for initialization
    void Start()
    {
        //FlipperRの中心
        p = transform.position;
        //回転中心pをFlipperRの横幅の半分だけ右に移動
        p.x += transform.localScale.x * 0.5f;
        //FlipperRの上方向
        up = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        flg = 0;
        //[M]キーが押されている
        if (Input.GetKey(KeyCode.M))
        {
            //角度が範囲内
            if (transform.localEulerAngles.y < 30 || transform.localEulerAngles.y > 320)
            {
                //FlipperRを回転
                transform.RotateAround(p, up, 10);
                //flgに1をセット
                flg = 1;
            }
        }
        else if (transform.localEulerAngles.y < 40 || transform.localEulerAngles.y > 330)
        {
            //FlipperRを回転
            transform.RotateAround(p, up, -2);
        }
    }

    //衝突検出
    void OnCollisionEnter(Collision collision)
    {
        //FlipperRの前方向
        Vector3 v = transform.forward;

        //FlipperRが動いているとき
        if (flg == 1)
            collision.gameObject.GetComponent<Rigidbody>().AddForce(v * 1000);
    }
}
