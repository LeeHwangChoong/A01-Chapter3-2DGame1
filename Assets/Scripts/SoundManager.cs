using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private AudioSource bgmAudioSource;
    private AudioSource itemAudioSource;
    private AudioSource playerAttackAudioSource;   
    private AudioSource playerDeadAudioSource;

    public float bgmVolume = 1f;
    public float itemVolume = 1f;
    public float playerAttackVolume = 1f;
    public float playerDeadVolume = 1f;

    public AudioClip backgroundMusicClip;
    public AudioClip playerAttackSoundClip; 
    public AudioClip playerDeadSoundClip;

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

            // 아이템용 오디오 소스 추가
            itemAudioSource = gameObject.AddComponent<AudioSource>();
            itemAudioSource.volume = itemVolume;

            // 플레이어 공격용 오디오 소스 추가
            playerAttackAudioSource = gameObject.AddComponent<AudioSource>();
            playerAttackAudioSource.volume = playerAttackVolume;

            // 플레이어 사망용 오디오 소스 추가
            playerDeadAudioSource = gameObject.AddComponent<AudioSource>();
            playerDeadAudioSource.volume = playerDeadVolume;
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

    public void PlayerAttackSound()
    {
        if (playerAttackSoundClip != null)
        {
            playerAttackAudioSource.PlayOneShot(playerAttackSoundClip);
        }
    }

    public void PlayerDeadSound()
    {
        if (playerAttackSoundClip != null)
        {
            playerDeadAudioSource.PlayOneShot(playerDeadSoundClip);
        }
    }

}
