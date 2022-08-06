using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid2D;
    AudioSource audioComponent;

    //�n�ʂ̈ʒu
    private float groundLevel = -3.0f;

    //�W�����v���x�̌���
    private float dump = 0.8f;
    //�W�����v�̑��x
    float jumpVelocity = 20;

    //�Q�[���I�[�o�[�ɂȂ�ʒu
    private float deadLine = -9.0f;


    // Start is called before the first frame update
    void Start()
    {
        //�R���|�l���g�̎擾
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.audioComponent = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Animator�̃p�����[�^
        this.animator.SetFloat("Horizontal", 1);

        //���n���Ă��邩�ǂ������ׂ� �����̍��W���n�ʂ�荂���ꍇisGround = false;
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);
        //�W�����v��Ԃ̂Ƃ��ɂ̓{�����[����0�ɂ���
        audioComponent.volume = (isGround) ? 1 : 0;

        //���n��ԂŃN���b�N���ꂽ�ꍇ
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //�N���b�N����߂��������ւ̑��x����������
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //�f�b�h���C���𒴂����ꍇ�Q�[���I�[�o�[�ɂ���
        if (transform.position.x < this.deadLine)
        {
            //UIController��GameOver�֐����Ăяo���ĉ�ʏ�ɁuGameOver�v�ƕ\������
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            Destroy(gameObject);
        }
    }
}
