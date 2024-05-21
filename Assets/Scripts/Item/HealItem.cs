using System.Collections;
using UnityEngine;

public class HealItem : AllItemUse
{
    public override void ItemUse()
    {
        base.ItemUse();

        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            if (player.life < 3) 
            {
                player.life += 1; 
                
                GameManager manager = FindObjectOfType<GameManager>();
                if (manager != null)
                {
                    manager.UpdateLife(player.life); 
                }
            }
        }
    }
}


