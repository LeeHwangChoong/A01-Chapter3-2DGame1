using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private AudioSource audioSource;

    public float volume = 1f;
    public AudioClip backgroundMusicClip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.volume = volume;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp(newVolume, 0f, 1f); // 볼륨 값 제한
        audioSource.volume = volume; // 오디오 소스 볼륨 업데이트
    }

    private void Start()
    {
        PlayBackgroundMusic(); 
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusicClip != null)
        {
            audioSource.clip = backgroundMusicClip;
            audioSource.Play();
        }
    }

    public void ItemSound(AudioClip itemSoundClip)
    {
        if (itemSoundClip != null)
        {
            audioSource.PlayOneShot(itemSoundClip);
        }
    }
}
