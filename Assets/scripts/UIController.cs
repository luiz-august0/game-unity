using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    public void ToggleMusic() {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX() {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume() {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume() {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }
}
