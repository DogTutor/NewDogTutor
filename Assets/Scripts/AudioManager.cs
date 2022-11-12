using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
  public AudioClip musicaComisaria;
  private AudioSource track1, track2;
  private bool isPlayingTrack1, isOn;
  public Slider volumeSlider;
  public static AudioManager instance;
  public Image icon;
  public Sprite mutedIcon, soundIcon;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
  }
  // Start is called before the first frame update
  void Start()
  {
    track1 = gameObject.AddComponent<AudioSource>();
    track2 = gameObject.AddComponent<AudioSource>();
    track1.loop = true;
    track2.loop = true;
    isPlayingTrack1 = true;
    isOn = true;
    icon.sprite = soundIcon;

    SwapTrack(musicaComisaria);

    volumeSlider.onValueChanged.AddListener((v) =>
    {
      track1.volume = v;
      track2.volume = v;
    });
  }

  public void SwapTrack(AudioClip newClip)
  {
    StopAllCoroutines();
    StartCoroutine(FadeTrack(newClip));

    isPlayingTrack1 = !isPlayingTrack1;
  }
  public void MuteTrack()
  {
    StopAllCoroutines();
    if (isOn)
    {
      StartCoroutine(FadeMuteTrack());
      icon.sprite = mutedIcon;

    }
    else
    {
      StartCoroutine(FadeUnmuteTrack());
      icon.sprite = soundIcon;
    }
  }
  private IEnumerator FadeMuteTrack()
  {
    float timeToFade = 0.5f;
    float timeElapsed = 0;
    if (isPlayingTrack1)
    {
      while (timeElapsed < timeToFade)
      {
        track1.volume = Mathf.Lerp(volumeSlider.value, 0, timeElapsed / timeToFade);
        timeElapsed += Time.deltaTime;
        yield return null;
      }
      isOn = false;
      track1.mute = true;
    }
    else
    {
      while (timeElapsed < timeToFade)
      {
        track2.volume = Mathf.Lerp(volumeSlider.value, 0, timeElapsed / timeToFade);
        timeElapsed += Time.deltaTime;
        yield return null;
      }
      isOn = false;
      track2.mute = true;
    }
  }
  private IEnumerator FadeUnmuteTrack()
  {
    float timeToFade = 0.5f;
    float timeElapsed = 0;
    if (isPlayingTrack1)
    {
      track1.mute = false;
      while (timeElapsed < timeToFade)
      {
        track1.volume = Mathf.Lerp(0, volumeSlider.value, timeElapsed / timeToFade);
        timeElapsed += Time.deltaTime;
        yield return null;
      }
      isOn = true;
    }
    else
    {
      track2.mute = false;
      while (timeElapsed < timeToFade)
      {
        track2.volume = Mathf.Lerp(0, volumeSlider.value, timeElapsed / timeToFade);
        timeElapsed += Time.deltaTime;
        yield return null;
      }
      isOn = true;
    }
  }
  private IEnumerator FadeTrack(AudioClip newClip)
  {
    float timeToFade = 1.25f;
    float timeElapsed = 0;
    if (isPlayingTrack1)
    {
      track2.clip = newClip;
      track2.Play();
      if (track1.mute)
      {
        track2.mute = true;
      }
      while (timeElapsed < timeToFade)
      {
        track2.volume = Mathf.Lerp(0, volumeSlider.value, timeElapsed / timeToFade);
        track1.volume = Mathf.Lerp(volumeSlider.value, 0, timeElapsed / timeToFade);
        timeElapsed += Time.deltaTime;
        yield return null;
      }
      track1.Stop();
    }
    else
    {
      track1.clip = newClip;
      track1.Play();
      if (track2.mute)
      {
        track1.mute = true;
      }
      while (timeElapsed < timeToFade)
      {
        track1.volume = Mathf.Lerp(0, volumeSlider.value, timeElapsed / timeToFade);
        track2.volume = Mathf.Lerp(volumeSlider.value, 0, timeElapsed / timeToFade);
        timeElapsed += Time.deltaTime;
        yield return null;
      }
      track2.Stop();
    }
  }
}
