using System.Collections;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ControllItemUse(this.gameObject);
        }
    }

    private void ControllItemUse(GameObject item)
    {
        string itemTag = item.tag;

        switch (itemTag)
        {
            case "HealItem":
                item.GetComponent<HealItem>().ItemUse();                                
                break;
            case "PowerUpItem":
                item.GetComponent<PowerUpItem>().ItemUse();                
                break;
            case "ShieldItem":                
                item.GetComponent<ShieldItem>().ItemUse();                             
                break;
            default:
                break;
        }
        Destroy(item);
        //(아이템 획득 사운드)
    }
}

