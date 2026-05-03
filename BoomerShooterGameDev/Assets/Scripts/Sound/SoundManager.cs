//made using a youtube tutorial!
using UnityEngine;
using System;
public enum MusicType
{
    WAITINGROOM,
    GAMEPLAY
}
public enum SoundType
{   
    SWORD,
    SHOTGUNBLAST,
    SHOTGUNCOCK,
    DOORBOOM,
    DOORCLOSING,
    ENEMYDEATH,
    WINGAME,
    WINLEVEL,
    LOSEGAME,
    BULLETHIT,
    SWORDHIT,
    ENEMYRANGEDATTACK,
    ENEMYACTIVATION,
    PLAYERHIT,
}
[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundList[] soundList;
    [SerializeField] private AudioClip[] musicList;
    private static SoundManager instance;
    private AudioSource audioSource;
    private AudioSource musicSource;

    private void Awake()
    {
        instance = this;
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public static void PlaySound(SoundType sound, float volume = 1f)
    {
        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];
        instance.audioSource.PlayOneShot(randomClip, volume);
    }
    #if UNITY_EDITOR
    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length);
        for(int i = 0; i < soundList.Length; i++)
        {
            soundList[i].name = names[i];
        }
    }
    #endif
public static void PlayMusic(MusicType music, float volume = 0.5f)
{
    instance.musicSource.clip = instance.musicList[(int)music];
    instance.musicSource.volume = volume;
    instance.musicSource.Play();
}

public static void StopMusic()
{
    instance.musicSource.Stop();
}

public static void SetMusicVolume(float volume)
{
    instance.musicSource.volume = volume;
}
}
[Serializable]
public struct SoundList
{
    public AudioClip[] Sounds {get => sounds;}
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] sounds;
}
