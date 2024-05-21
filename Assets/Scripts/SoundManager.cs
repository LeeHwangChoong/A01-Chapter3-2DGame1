using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private AudioSource bgmAudioSource;
    private AudioSource itemAudioSource;

    public float bgmVolume = 1f;
    public float itemVolume = 1f;
    public AudioClip backgroundMusicClip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // 배경음악용 오디오 소스 추가
            bgmAudioSource = gameObject.AddComponent<AudioSource>();
            bgmAudioSource.loop = true;
            bgmAudioSource.volume = bgmVolume;

            // 효과음용 오디오 소스 추가
            itemAudioSource = gameObject.AddComponent<AudioSource>();
            itemAudioSource.volume = itemVolume;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetBGMVolume(float newVolume)
    {
        bgmVolume = Mathf.Clamp(newVolume, 0f, 1f);
        bgmAudioSource.volume = bgmVolume;
    }

    public void SetItemVolume(float newVolume)
    {
        itemVolume = Mathf.Clamp(newVolume, 0f, 1f);
        itemAudioSource.volume = itemVolume;
    }

    private void Start()
    {
        PlayBackgroundMusic(); 
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusicClip != null)
        {
            bgmAudioSource.clip = backgroundMusicClip;
            bgmAudioSource.Play();
        }
    }

    public void ItemSound(AudioClip itemSoundClip)
    {
        if (itemSoundClip != null)
        {
            itemAudioSource.PlayOneShot(itemSoundClip);
        }
    }
}
