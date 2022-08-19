using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] AudioSource _audio;
    [SerializeField] AudioClip _click;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Play(AudioClip audioClip)
    {
        _audio.clip = audioClip;
        _audio.Play();
    }

    void Click()
    {
        Play(_click);
    }
}
