using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    [SerializeField]
    [Header("Œø‰Ê‰¹—p‚ÌAudioSource")]
    AudioSource _audioSE;

    [SerializeField]
    [Header("BGM—p‚ÌAudioSource")]
    AudioSource _audioBGM;

    protected override void Awake()
    {
        base.Awake();
    }

    public void PlayBGM(AudioClip clip)
    {
        _audioBGM.Stop();
        _audioBGM.clip = clip;
        _audioBGM.Play();
    }

    public void PlaySE(AudioClip clip)
    {
        _audioSE.PlayOneShot(clip);
    }
}
