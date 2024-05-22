using System.Collections;
using UnityEngine;

public class PowerUpItem : AllItemUse
{
    public override void ItemUse()
    {
        base.ItemUse();
        Player player = FindObjectOfType<Player>(); // 씬에서 Player 오브젝트를 찾아서
        if (player != null)
        {
            if (player.power < 3)
            {
                player.power += 1;
            }
            else
            {
                player.speed += 1;
            }                       
        }
    }
}


