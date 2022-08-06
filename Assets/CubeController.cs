using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //オーディオ
    private AudioSource audioComponent;

    //キューブの移動速度
    private float speed = -12.0f;
    //キューブの消滅位置
    private float deadLine = -10.0f;


    // Start is called before the first frame update
    void Start()
    {
        this.audioComponent = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //キューブの移動
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
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
