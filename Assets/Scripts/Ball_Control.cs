using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Control : MonoBehaviour
{
    GameObject gm;
    Rigidbody ball;

    float pow; //パワー用
    Vector3 p, angle;


    // Use this for initialization
    void Start()
    {
        pow = 0f; //初期値
        p = transform.position; //初期位置
        angle = transform.eulerAngles; //初期角度
        gm = GameObject.Find("GameManager");
        ball = this.GetComponent<Rigidbody>();
        ball.constraints = RigidbodyConstraints.FreezePosition;  //positionをフリーズさせる
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ball.constraints = RigidbodyConstraints.None;　//解除
        }

        //Xキーを押した時         
        if (Input.GetKey(KeyCode.X))
        {
            pow += 10f; //powを加算
            //GetComponent<Bar_Control>().();
        }
        //Xキーを離した時
        if (Input.GetKeyUp(KeyCode.X))
        {
            Vector3 v = transform.forward; //ボール前方向            
            transform.GetComponent<Rigidbody>().AddForce(v * pow); //ボールに力付与
            pow = 0f;
        }else if (Input.GetKeyUp(KeyCode.R)) //Rキーを押したとき
        {
            transform.position = p; //初期位置に戻す
            transform.eulerAngles = angle; //初期角度に戻す
            GetComponent<Rigidbody>().velocity *= 0;
            gm.GetComponent<GameManager>().DecreaseLife();
        }
        if(GetComponent<Rigidbody>().velocity.magnitude > 20)
        {
            GetComponent<ParticleSystem> ().Play ();
        }
    }

    //
    void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();
    }
}