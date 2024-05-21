using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life = 3;
    public float speed;
    public float power;
    public float maxShotDelay;
    public float curShotDelay;

    public GameObject bulletA;
    public GameObject bulletB;
    public GameObject bulletC;
    public GameObject bulletD;

    public GameManager manager;
    public GameObject shieldImage;  // 추가    

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isLive)
            return;
        Fire();
        Reload();
    }

    private void Fire()
    {        
        if (curShotDelay < maxShotDelay)
        {
            return;
        }
        switch (power)
        {
            case 0:
                if(power == 0)
                {
                    maxShotDelay = 0.7f;
                }
                GameObject bullet = Instantiate(bulletA, transform.position + Vector3.up * 0.5f, transform.rotation);
                Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
                rigidbody.AddForce(Vector2.up * 2, ForceMode2D.Impulse);
                SoundManager.Instance.PlayerAttackSound(); //공격 사운드 추가
                break;
            case 1:
                if(power == 1)
                {
                    maxShotDelay = 0.65f;
                }
                GameObject bullet1 = Instantiate(bulletB, transform.position + Vector3.up * 0.5f, transform.rotation);
                Rigidbody2D rigidbody1 = bullet1.GetComponent<Rigidbody2D>();
                rigidbody1.AddForce(Vector2.up * 2, ForceMode2D.Impulse);
                SoundManager.Instance.PlayerAttackSound(); //공격 사운드 추가
                break;
            case 2:
                if(power == 2)
                {
                    maxShotDelay = 0.6f;
                }
                GameObject bullet2 = Instantiate(bulletC, transform.position + Vector3.up * 0.5f, transform.rotation);
                Rigidbody2D rigidbody2 = bullet2.GetComponent<Rigidbody2D>();
                rigidbody2.AddForce(Vector2.up * 2, ForceMode2D.Impulse);
                SoundManager.Instance.PlayerAttackSound(); //공격 사운드 추가
                break;
            case 3:
                if(power == 3)
                {
                    maxShotDelay = 0.55f;
                }
                GameObject bullet3 = Instantiate(bulletD, transform.position + Vector3.up * 0.5f, transform.rotation);
                Rigidbody2D rigidbody3 = bullet3.GetComponent<Rigidbody2D>();
                rigidbody3.AddForce(Vector2.up * 2, ForceMode2D.Impulse);
                SoundManager.Instance.PlayerAttackSound(); //공격 사운드 추가
                break;
        }
        curShotDelay = 0;
    }

    private void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {      
            if (!shieldImage.activeSelf) //추가
            {
                // 적의 공격을 받음
                SoundManager.Instance.PlayerDeadSound(); //파괴 사운드 추가
                life--;
                manager.UpdateLife(life);
                if (life == 0)
                {
                    manager.GameOver();
                }
                else
                {
                    manager.RespawnPlayer();
                }
                manager.RespawnPlayer();
                gameObject.SetActive(false);
            }
        }
    }
}
