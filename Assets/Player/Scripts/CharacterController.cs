using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour{
    private Rigidbody2D rb;

    public float speed = 14;
    public float jumpSpeed = 7;
    private int Score = 0;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        Move();
    }

    //��ɫ�ƶ�
    void Move(){
        //��ȡ��ɫˮƽ�����ƶ�����
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal != 0)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

            //ͨ��x�����Ÿı��ɫ����
            float x_scale = (horizontal > 0 ? 1 : -1) * Mathf.Abs(transform.localScale.x);
            transform.localScale = new Vector3(x_scale, transform.localScale.y, transform.localScale.z);
        }

        //��ɫ��Ծ
        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
    //�ӷַ���
    public void AddScore()
    {
        Score++;
        Debug.Log(Score);
    }


}
