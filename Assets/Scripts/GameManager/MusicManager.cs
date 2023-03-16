using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class MusicManager
{
    [SerializeField] public List<AudioClip> backgroundMusicAudioClips;
    [SerializeField] public AudioSource backgroundMusicAudioSource;

    private bool isChanging;
    public float musicChangeTime, musicMaxVolume, musicVolumeChangeTime;
    private float changeTimer, volumeTimer;

    public void Start() => SetNewMusic();

    public void Update()
    {
        if (isChanging) return;
        changeTimer += Time.deltaTime;
        if (changeTimer >= musicChangeTime) ChangeMusic();
    }

    public void ChangeMusic()
    {
        isChanging = true;
        changeTimer = 0;
        GameManager.Instance.StartCoroutine(DecreaseVolume());
    }

    public void SetNewMusic()
    {
        backgroundMusicAudioSource.Stop();
        backgroundMusicAudioSource.clip = backgroundMusicAudioClips[Random.Range(0, backgroundMusicAudioClips.Count)];
        backgroundMusicAudioSource.Play();
        GameManager.Instance.StartCoroutine(IcreaseVolume());
    }

    IEnumerator IcreaseVolume()
    {
        while (backgroundMusicAudioSource.volume < musicMaxVolume)
        {
            backgroundMusicAudioSource.volume += (musicMaxVolume / musicVolumeChangeTime) * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if (backgroundMusicAudioSource.volume >= musicMaxVolume) isChanging = false;
    }

    IEnumerator DecreaseVolume()
    { 
        while (backgroundMusicAudioSource.volume != 0)
        {
            backgroundMusicAudioSource.volume -= (musicMaxVolume / musicVolumeChangeTime) * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        SetNewMusic();
    }
}
