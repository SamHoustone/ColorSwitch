using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  private static AudioManager _instance;
  public AudioSource audioSource;
  public AudioSource audioSource2;
  public AudioClip Ambiance1,tap,ColorChange,Death;
  public static AudioManager Instance { get { return _instance; } }


    private void Awake()
    {
      DontDestroyOnLoad(gameObject);
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
   void Start() 
  {
      PlayMusic();
  }
  public void PlayMusic()
  {
   audioSource.clip = Ambiance1;
   audioSource.Play();
  }
  public void Tap()
  {
    audioSource2.clip = tap;
    audioSource2.Play();
  }
  public void ColorChangePlay()
  {
     audioSource2.clip = ColorChange;
    audioSource2.Play();
  }
  public void DeathPlay()
  {
     audioSource2.clip = Death;
    audioSource2.Play();
  }
}
