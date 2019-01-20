using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //ボールが見える可能性のあるｚ軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private GameObject scoreText;

    //得点
    private int score = 0;

	// Use this for initialization
	void Start () {
        //シ―ンの中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のscoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {
		//ボールが画面外に出て場合
        if(this.transform.position.z < this.visiblePosZ)
        {
            //GameOverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
	}

    void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.tag == "SmallStarTag" || other.gameObject.tag == "SmallCloudTag")
        {
            this.score += 10;

            this.scoreText.GetComponent<Text>().text = "Score" + this.score;
        }

       if(other.gameObject.tag == "LargeStarTag" || other.gameObject.tag == "LargeCloudTag")
        {
            this.score += 20;

            this.scoreText.GetComponent<Text>().text = "Score" + this.score;
        }
    }
}
