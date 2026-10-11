using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootClip;
    [SerializeField] [Range(0f, 1f)] float shootVolume;

    [Header("Damage SFX")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume;

    static AudioManager instance;

    void Awake()
    {
        ManagerSingleton();
    }
    void ManagerSingleton()
    {
        //int instanceCount = FindObjectsByType<AudioManager>(FindObjectsSortMode.None).Length;
        //if (instanceCount > 1 )
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayShootingSFX()
    {
        PlayAudioClip(shootClip, shootVolume);
    }

    public void PlayDamageSFX()
    {
        PlayAudioClip(damageClip, damageVolume);
    }

    void PlayAudioClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }

}
