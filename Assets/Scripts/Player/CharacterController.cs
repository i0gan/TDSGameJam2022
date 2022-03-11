using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour{
    private Rigidbody2D rb;
    private Collider2D collider;

    public float speed = 14;
    public float jumpSpeed = 7;
    public float OrangeJumpSpeed = 7;
    public float BlueSpeed = 40;

    private bool CanJump = false;
    private float Timer = 0;
    public float OrangeJumpTime = 2;

    Vector3 tran;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
        

    }
    void Update(){
        isCanJump();
        Jump();
    }


    //��ɫ�ƶ�
    void Move(){
        //��ȡ��ɫˮƽ�����ƶ�����
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal != 0){
            //rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            tran = new Vector3 (horizontal * Time.deltaTime * speed, 0, 0);
            rb.transform.Translate(tran);
            

            //ͨ��x�����Ÿı��ɫ����
            float x_scale = (horizontal > 0 ? 1 : -1) * Mathf.Abs(transform.localScale.x);
            transform.localScale = new Vector3(x_scale, transform.localScale.y, transform.localScale.z);
        }

        
    }

    void Jump()
    {
        //��ɫ��Ծ
        if (Input.GetButtonDown("Jump") && (Mathf.Abs(rb.velocity.y) <= 0.1 || CanJump == true))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    //������ɫ�������
    //ghy3
    private void OnCollisionEnter2D(Collision2D collision){
        
            if (collision.gameObject.tag == "Orange")
            {
                rb.velocity = new Vector2(rb.velocity.x, OrangeJumpSpeed);
                Timer = OrangeJumpTime;
            }
        
    }

    
    //�����Ƿ��ܿ�����Ծ
    private void isCanJump()
    {
        if (Timer > 0)
        {
            CanJump = true;
        }
        else
        {
            CanJump = false;
        }
        Timer = Timer - Time.deltaTime;
    }



}
