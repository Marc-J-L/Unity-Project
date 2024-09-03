using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource BgmAudio;
    [SerializeField] AudioSource SfxAudio;

    public AudioClip bgm;
    public AudioClip dash;
    public AudioClip checkpoint;
    public AudioClip death;

    private void Start()
    {
        PlayBgm();
    }

    public void PlayBgm()
    {
        if (BgmAudio.clip != bgm)
        {
            BgmAudio.clip = bgm;
        }
        if (!BgmAudio.isPlaying)
        {
            BgmAudio.Play();
        }
    }

    public void StopBgm()
    {
        if (BgmAudio.isPlaying)
        {
            BgmAudio.Stop();
        }
    }

    public void PlaySfx(AudioClip clip)
    {
        SfxAudio.PlayOneShot(clip);
    }

}
