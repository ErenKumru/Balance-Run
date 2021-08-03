using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource musicPlayer;
    [SerializeField] private Image soundButtonImage;
    [SerializeField] private Sprite soundOnImage;
    [SerializeField] private Sprite soundOffImage;

    public void MuteUnmuteSound()
    {
        musicPlayer.mute = !musicPlayer.mute;
        ChangeButtonImage(musicPlayer.mute);
    }

    public void ChangeButtonImage(bool muted)
    {
        soundButtonImage.sprite = muted ? soundOffImage : soundOnImage;
    }
}
