using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _audioClips;
    private float _defVolume=0.5f;

    private void Start()
    {
        if (SoundSingleton.IsFirst)
        {
            NewBGM(SoundEnum.MainBGM);
            _defVolume = SoundSingleton.AudioSourceBGM.volume;
            SoundSingleton.IsFirst = false;
        }
    }

    public async void PlaySound(SoundEnum sound,bool bgmAdjust = false)
    {
        AudioSource audioSource;
        if (Convert.ToInt32(sound) < 2) audioSource = SoundSingleton.AudioSourceBGM;
        else audioSource = SoundSingleton.AudioSourceSE;

        if (bgmAdjust) SoundSingleton.AudioSourceBGM.volume /= 2;

        audioSource.clip = _audioClips[Convert.ToInt32(sound)];
        audioSource.Play();

        if (bgmAdjust==false) return;
        await UniTask.WaitUntil(() => audioSource.isPlaying == false, cancellationToken: this.GetCancellationTokenOnDestroy());
        SoundSingleton.AudioSourceBGM.volume = _defVolume;
    }

    public async UniTask ChangeBGM()
    {
        var t = 0f;
        while (t<1)
        {
            SoundSingleton.AudioSourceBGM.volume = Mathf.Lerp(SoundSingleton.AudioSourceBGM.volume, 0, t);
            t += Time.deltaTime;
            await UniTask.Yield();
        }
    }

    public void NewBGM(SoundEnum sound)
    {
        SoundSingleton.AudioSourceBGM.clip = _audioClips[Convert.ToInt32(sound)];
        SoundSingleton.AudioSourceBGM.volume = _defVolume;
        SoundSingleton.AudioSourceBGM.Play();
    }
}
