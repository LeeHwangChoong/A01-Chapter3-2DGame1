using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy_23" || collision.gameObject.tag == "enemyfire12")
        {
            gameObject.SetActive(false);
        }
    }
}
