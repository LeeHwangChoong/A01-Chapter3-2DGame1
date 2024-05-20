using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchLeft;
    public bool isTouchRight;

    public float speed;
    public float power;
    public float maxShotDelay;
    public float curShotDelay;

    public GameObject bulletA;
    public GameObject bulletB;
    public GameObject bulletC;
    public GameObject bulletD;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        Reload();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && x == 1) || (isTouchLeft && x == -1))
        {
            x = 0;
        }
        float y = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && y == 1) || (isTouchBottom && y == -1))
        {
            y = 0;
        }
        Vector3 curPos = transform.position;
        Vector3 nextPos = (new Vector3(x, y, 0)).normalized * speed * Time.deltaTime;

        transform.position = curPos + nextPos;

        if (Input.GetButtonDown("Horizontal") || (Input.GetButtonUp("Horizontal")))
        {
            anim.SetInteger("Input", (int)x);
        }
    }
    // 총알 생성후 발사
    private void Fire()
    {
        if(curShotDelay < maxShotDelay)
        {
            return;
        }
        switch (power)
        {
            case 0:
                GameObject bullet = Instantiate(bulletA, transform.position, transform.rotation);
                Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
                rigidbody.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
                break;
            case 1:
                GameObject bullet1 = Instantiate(bulletB, transform.position, transform.rotation);
                Rigidbody2D rigidbody1 = bullet1.GetComponent<Rigidbody2D>();
                rigidbody1.AddForce(Vector2.up * speed * 2, ForceMode2D.Impulse);
                break;
            case 2:
                GameObject bullet2 = Instantiate(bulletC, transform.position, transform.rotation);
                Rigidbody2D rigidbody2 = bullet2.GetComponent<Rigidbody2D>();
                rigidbody2.AddForce(Vector2.up * speed * 3, ForceMode2D.Impulse);
                break;
            case 3:
                GameObject bullet3 = Instantiate(bulletD, transform.position, transform.rotation);
                Rigidbody2D rigidbody3 = bullet3.GetComponent<Rigidbody2D>();
                rigidbody3.AddForce(Vector2.up * speed * 4, ForceMode2D.Impulse);
                break;
        }
        curShotDelay = 0;
    }

    private void Reload()
    {
        curShotDelay += Time.deltaTime;
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
