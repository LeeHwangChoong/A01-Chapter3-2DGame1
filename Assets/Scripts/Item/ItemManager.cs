using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }

    private List<GameObject> itemList = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void RandomItem(GameObject item)
    {
        // 랜덤 생성된 아이템을 아이템 리스트에 추가
        itemList.Add(item);

        // 랜덤 생성된 아이템에 이동 스크립트 추가
        item.AddComponent<ItemMove>();

        //랜덤 생성된 아이템에 충돌 스크립트 추가
        item.AddComponent<ItemCollider>();
    }
}
    
