using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    //ƒXƒNƒ[ƒ‹‘¬“x
    private float scrollSpeed = -1.0f;
    //”wŒiI—¹ˆÊ’u
    private float deadLine = -16.0f;
    //”wŒiŠJnˆÊ’u
    private float startLine = 15.8f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //”wŒi‚ÌˆÚ“®
        transform.Translate(this.scrollSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x < this.deadLine)
        {
            transform.position = new Vector2(this.startLine, 0);
        }
    }
}
