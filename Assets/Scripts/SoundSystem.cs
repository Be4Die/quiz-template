using System;
using UnityEngine;

public class SoundSystem : MonoBehaviourSingleton<SoundSystem>
{
    public bool IsMusicPlaying { get => m_isMusicPlaying; }
    private bool m_isMusicPlaying = true;

    public Action OnMusicChange;
    public void MusicOn()
    {
        m_isMusicPlaying = true;
        OnMusicChange?.Invoke();
    }
    public void MusicOff() 
    {
        m_isMusicPlaying = false;
        OnMusicChange?.Invoke();
    }
}
