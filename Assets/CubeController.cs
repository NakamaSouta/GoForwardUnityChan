using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //�I�[�f�B�I
    private AudioSource audioComponent;

    //�L���[�u�̈ړ����x
    private float speed = -12.0f;
    //�L���[�u�̏��ňʒu
    private float deadLine = -10.0f;


    // Start is called before the first frame update
    void Start()
    {
        this.audioComponent = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //�L���[�u�̈ړ�
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //��ʊO�ɏo����j������
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GroundTag" || collision.gameObject.tag == "CubeTag")
        {
            this.audioComponent.Play();
        }
    }
}
