using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchLeft;
    public bool isTouchRight;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //키보드  x값 y값 받기
        float x = Input.GetAxisRaw("Horizontal");
        if((isTouchRight && x == 1) || (isTouchLeft && x == -1))
        {
            x = 0;
        }
        float y = Input.GetAxisRaw("Vertical");
        if((isTouchTop && y == 1) || (isTouchBottom && y == -1))
        {
            y = 0;
        }
        Vector3 curPos = transform.position;
        Vector3 nextPos = (new Vector3(x, y, 0)).normalized * speed * Time.deltaTime;

        transform.position = curPos + nextPos;

        if(Input.GetButtonDown("Horizontal") || (Input.GetButtonUp("Horizontal")))
        {
            anim.SetInteger("Input", (int)x);
        }
    }

    // Player가 화면 너머 Box 콜라이더에 충돌시 막음
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Border")
        {
            switch(collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
            }
        }
    }
}
