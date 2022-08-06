using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid2D;
    AudioSource audioComponent;

    //地面の位置
    private float groundLevel = -3.0f;

    //ジャンプ速度の減衰
    private float dump = 0.8f;
    //ジャンプの速度
    float jumpVelocity = 20;

    //ゲームオーバーになる位置
    private float deadLine = -9.0f;


    // Start is called before the first frame update
    void Start()
    {
        //コンポネントの取得
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.audioComponent = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Animatorのパラメータ
        this.animator.SetFloat("Horizontal", 1);

        //着地しているかどうか調べる 自分の座標が地面より高い場合isGround = false;
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);
        //ジャンプ状態のときにはボリュームを0にする
        audioComponent.volume = (isGround) ? 1 : 0;

        //着地状態でクリックされた場合
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //クリックをやめたら上方向への速度を減速する
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //デッドラインを超えた場合ゲームオーバーにする
        if (transform.position.x < this.deadLine)
        {
            //UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            Destroy(gameObject);
        }
    }
}
