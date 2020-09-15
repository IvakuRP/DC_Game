using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public enum SFXType {HOP, HIT_VIRUS, HIT_TROJAN, HIT_BUG, HIT_SPIKE, HIT_ELECT, COIN, BUTTON, 
	STELE, POWERUP_TAKE, POWERUP_EQUIP, DEAD, GAMEOVER, EXIT}

public class SFXManeger : MonoBehaviour
{
    public static SFXManeger instance;
    public AudioSource musicAudioSource;
    private AudioSource sfxAudioSource;
    public AudioClip[] sfxCollection;

    public AudioMixer gameAudioMixer;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start ()
    {
        instance = this;
        sfxAudioSource = GetComponent<AudioSource>();
	}

    //SFXManeger.instance.PlaySFX(SFXType.BUTTON);
    public void PlaySFX(SFXType sfxType)
    {
        switch(sfxType)
        {
            case SFXType.HOP:
                sfxAudioSource.PlayOneShot(sfxCollection[0]);
                break;

            case SFXType.HIT_VIRUS:
                sfxAudioSource.PlayOneShot(sfxCollection[1]);
                break;

            case SFXType.HIT_TROJAN:
                sfxAudioSource.PlayOneShot(sfxCollection[2]);
                break;

            case SFXType.HIT_BUG:
                sfxAudioSource.PlayOneShot(sfxCollection[3]);
                break;

            case SFXType.HIT_SPIKE:
                sfxAudioSource.PlayOneShot(sfxCollection[4]);
                break;

            case SFXType.HIT_ELECT:
                sfxAudioSource.PlayOneShot(sfxCollection[5]);
                break;


             case SFXType.COIN:
                sfxAudioSource.PlayOneShot(sfxCollection[6]);
                break;

            case SFXType.BUTTON:
                sfxAudioSource.PlayOneShot(sfxCollection[7]);
                break;

            case SFXType.STELE:
                sfxAudioSource.PlayOneShot(sfxCollection[8]);
                break;


            case SFXType.POWERUP_TAKE:
                sfxAudioSource.PlayOneShot(sfxCollection[9]);
                break;


            case SFXType.POWERUP_EQUIP:
                sfxAudioSource.PlayOneShot(sfxCollection[10]);
                break;


            case SFXType.DEAD:
                sfxAudioSource.PlayOneShot(sfxCollection[11]);
                break;


            case SFXType.GAMEOVER:
                sfxAudioSource.PlayOneShot(sfxCollection[12]);
                break;


            case SFXType.EXIT:
                sfxAudioSource.PlayOneShot(sfxCollection[13]);
                break;
        }
    }
}
