using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour{
    private Rigidbody2D rb;

    public float speed = 14;
    public float jumpSpeed = 7;
    public float OrangeJumpSpeed = 7;
    public float deadHeight = -100;
    private int Score = 0;
    private Vector3 startPos;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update(){
        //��ɫ�����������ͻ����
        if (transform.position.y < deadHeight) 
            reStart();
        Move();
    }

    //��ɫ�ƶ�
    void Move(){
        //��ȡ��ɫˮƽ�����ƶ�����
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal != 0){
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

            //ͨ��x�����Ÿı��ɫ����
            float x_scale = (horizontal > 0 ? 1 : -1) * Mathf.Abs(transform.localScale.x);
            transform.localScale = new Vector3(x_scale, transform.localScale.y, transform.localScale.z);
        }

        //��ɫ��Ծ
        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0){
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }


    //�ӷַ���
    public void AddScore(){
        Score++;
        Debug.Log(Score);
    }
    //������ɫ�������
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Orange"){
            rb.velocity = new Vector2(rb.velocity.x, OrangeJumpSpeed);
        }
    }

    //���¿�ʼ��Ϸ
    public void reStart(){
        transform.position = startPos;
    }


}
