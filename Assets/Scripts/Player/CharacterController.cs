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


    //角色移动
    void Move(){
        //获取角色水平方向移动输入
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal != 0){
            //rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            tran = new Vector3 (horizontal * Time.deltaTime * speed, 0, 0);
            rb.transform.Translate(tran);
            

            //通过x轴缩放改变角色朝向
            float x_scale = (horizontal > 0 ? 1 : -1) * Mathf.Abs(transform.localScale.x);
            transform.localScale = new Vector3(x_scale, transform.localScale.y, transform.localScale.z);
        }

        
    }

    void Jump()
    {
        //角色跳跃
        if (Input.GetButtonDown("Jump") && (Mathf.Abs(rb.velocity.y) <= 0.1 || CanJump == true))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    //碰到橙色物块跳动
    //ghy3
    private void OnCollisionEnter2D(Collision2D collision){
        
            if (collision.gameObject.tag == "Orange")
            {
                rb.velocity = new Vector2(rb.velocity.x, OrangeJumpSpeed);
                Timer = OrangeJumpTime;
            }
        
    }

    
    //控制是否能空中跳跃
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
