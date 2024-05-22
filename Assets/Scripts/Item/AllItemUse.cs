using System.Collections;
using UnityEngine;

public class AllItemUse : MonoBehaviour
{
    public AudioClip itemSoundClip;
    public float itemVolume = 1f;

    public virtual void ItemUse()
    {
        SoundManager.Instance.ItemSound(itemSoundClip);
        SoundManager.Instance.SetItemVolume(itemVolume);
    }
}

