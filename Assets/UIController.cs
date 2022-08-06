using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //�Q�[���I�[�o�[�e�L�X�g
    private GameObject gameOverText;
    //�Q�[���I�[�o�[�e�L�X�g�̃R���|�l���g
    private Text gameOverTextComponent;

    //���s�����e�L�X�g
    private GameObject runLengthText;
    //���s�����e�L�X�g�̃R���|�l���g
    private Text runLengthTextComponent;
    //����������
    private float len = 0;
    //���鑬�x
    private float speed = 5.0f;

    //�Q�[���I�[�o�[�̔���
    private bool isGameOver = false;



    // Start is called before the first frame update
    void Start()
    {
        //�I�u�W�F�N�g�̌���
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
        //�R���|�l���g�̎擾
        this.gameOverTextComponent = this.gameOverText.GetComponent<Text>();
        this.runLengthTextComponent = this.runLengthText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isGameOver == false)
        {
            //�����������̍X�V
            this.len += this.speed * Time.deltaTime;

            //������������\������
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
        //�Q�[���I�[�o�[�ɂȂ����Ƃ��ɉ�ʏ�ɃQ�[���I�[�o�[��\������
        this.gameOverTextComponent.text = "Game Over";
        this.isGameOver = true;
    }
}
