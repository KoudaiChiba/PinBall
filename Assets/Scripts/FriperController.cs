using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriperController : MonoBehaviour {
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    //初期の左画面の状態
    private bool isLButtonDown = false;

    //初期の右画面の状態
    private bool isRButtonDown = false;

    // Use this for initialization
	void Start () {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
	}

    // Update is called once per frame
    void Update()
    {
        //左画面を押したとき左フリッパーを動かす
        if (this.isLButtonDown == true && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右画面を押したとき右フリッパーを動かす
        if(this.isRButtonDown == true && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //左画面から離したときフリッパーをもとに戻す
        if(this.isLButtonDown == false && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        //右画面から離したときフリッパーをもとに戻す
        if(this.isRButtonDown == false && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        
        //左矢印キーを押されたら左画面を押されたことにする
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.isLButtonDown = true;
        }
        //右矢印キーが押されたら右画面を押されたことにする
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.isRButtonDown = true;
        }

        //左矢印キーが離されたら左画面を離したことにする
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.isLButtonDown = false;
        }
        //右矢印キーが離されたら右画面を離したことにする
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.isRButtonDown = false;
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

    //左ボタンを押し続けた場合の処理
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    //左ボタンを離した場合の処理
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }

    //右ボタンを押し続けた場合の処理
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    //右ボタンを離した場合の処理
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }
}
