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

    private bool isLButtonDown = false;

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
        //右矢印キーを押したとき左フリッパーを動かす
        if (this.isLButtonDown == true && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押したとき右フリッパーを動かす
        if(this.isRButtonDown == true && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キーが離されたときフリッパーをもとに戻す
        if(this.isLButtonDown == false && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if(this.isRButtonDown == false && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

    //左ボタンを押し続けた場合の処理（追加）
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    //左ボタンを離した場合の処理（追加）
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }

    //右ボタンを押し続けた場合の処理（追加）
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    //右ボタンを離した場合の処理（追加）
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }
}
