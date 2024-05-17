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
                Debug.Log("힐아이템");                
                break;
            case "PowerUpItem":
                item.GetComponent<PowerUpItem>().ItemUse();
                Debug.Log("파워업 아이템");
                break;
            case "ShieldItem":                
                item.GetComponent<ShieldItem>().ItemUse();
                Debug.Log("쉴드아이템");                
                break;
            default:
                break;
        }
        Destroy(item);
        //(아이템 획득 사운드)
    }
}

