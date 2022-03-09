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
        //角色掉出场景则传送回起点
        if (transform.position.y < deadHeight) 
            reStart();
        Move();
    }

    //角色移动
    void Move(){
        //获取角色水平方向移动输入
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal != 0){
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

            //通过x轴缩放改变角色朝向
            float x_scale = (horizontal > 0 ? 1 : -1) * Mathf.Abs(transform.localScale.x);
            transform.localScale = new Vector3(x_scale, transform.localScale.y, transform.localScale.z);
        }

        //角色跳跃
        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0){
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }


    //加分方法
    public void AddScore(){
        Score++;
        Debug.Log(Score);
    }
    //碰到橙色物块跳动
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Orange"){
            rb.velocity = new Vector2(rb.velocity.x, OrangeJumpSpeed);
        }
    }

    //重新开始游戏
    public void reStart(){
        transform.position = startPos;
    }


}
