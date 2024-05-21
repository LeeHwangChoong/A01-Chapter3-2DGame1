using System.Collections;
using UnityEngine;

public class ShieldItem : AllItemUse
{
    public GameObject shieldObject;
    private float shieldTime = 5f;

    public override void ItemUse()
    {
        base.ItemUse();
        ShieldManager.Instance.ActivateShield(shieldObject, shieldTime);
    }
}
