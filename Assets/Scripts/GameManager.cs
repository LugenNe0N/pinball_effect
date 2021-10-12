using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    GameObject lifeText;
    GameObject statusText;
    GameObject restartBotton;
    GameObject titleButton;
    public GameObject ball;
    AudioSource ballAudio;

    int life = 3; //ライフ
    bool playFlag = false; //ゲーム中判断

    // Use this for initialization
    void Start () {
        //LIFEの表示
        lifeText = GameObject.Find("LIFE");
        this.lifeText.GetComponent<Text>().text = "LIFE : " + life;
        //GameTextの設定
        statusText = GameObject.Find("STATUS");
        this.statusText.GetComponent<Text>().text = "PRESS SPACE TO START";
        //Restartの表示
        restartBotton = GameObject.Find("Restart");
        restartBotton.SetActive(false);
        //Titletextの表示
        titleButton = GameObject.Find("Title");
        titleButton.SetActive(false);

        ballAudio = ball.GetComponent<AudioSource>();
        ballAudio.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!playFlag)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                playFlag = true;
                ballAudio.enabled = true;
                this.statusText.SetActive(false);
            }
        }else{
            if (Input.GetKey(KeyCode.Escape))
            {
                playFlag = false;
                restartBotton.SetActive(true);
                titleButton.SetActive(true);
            }
        }
    }

    public void DecreaseLife()
    {
        if (playFlag) {
            life--;
            this.lifeText.GetComponent<Text>().text = "LIFE : " + life;
            if (life == 0)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        //テキスト表示
        Debug.Log("Game Over!");
        playFlag = false;
        statusText.GetComponent<Text>().text = "GAME OVER!!";
        statusText.SetActive(true);
        restartBotton.SetActive(true);
        titleButton.SetActive(true);
        // ハイスコアの保存
        FindObjectOfType<Score>().Save();

    }
}


