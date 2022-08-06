using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //ゲームオーバーテキスト
    private GameObject gameOverText;
    //ゲームオーバーテキストのコンポネント
    private Text gameOverTextComponent;

    //走行距離テキスト
    private GameObject runLengthText;
    //走行距離テキストのコンポネント
    private Text runLengthTextComponent;
    //走った距離
    private float len = 0;
    //走る速度
    private float speed = 5.0f;

    //ゲームオーバーの判定
    private bool isGameOver = false;



    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトの検索
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
        //コンポネントの取得
        this.gameOverTextComponent = this.gameOverText.GetComponent<Text>();
        this.runLengthTextComponent = this.runLengthText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isGameOver == false)
        {
            //走った距離の更新
            this.len += this.speed * Time.deltaTime;

            //走った距離を表示する
            this.runLengthTextComponent.text = "Distance: " + len.ToString("F2") + "m";
        }

        if (this.isGameOver == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void GameOver()
    {
        //ゲームオーバーになったときに画面上にゲームオーバーを表示する
        this.gameOverTextComponent.text = "Game Over";
        this.isGameOver = true;
    }
}
