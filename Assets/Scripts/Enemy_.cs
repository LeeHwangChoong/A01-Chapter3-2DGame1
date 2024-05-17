using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyScore;
    public int health;
    void OnHit(int dmg)
    {
        //데미지 로직
        if (health <= 0)
        {
            Player playerLogic = player.GetComponent<Player>();
            playerLogic.score += enemyScore;
            //Destroy(gameObject)

        }
    }
}
