using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager inst;
    [SerializeField]
    private bool muted = false;
    [SerializeField]
    private AudioSource audios;
    void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else if (inst != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        audios = GetComponent<AudioSource>();
        if ( PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            muted = false;
        }
        else
        {
            muted = true;

        }
        audios.mute = muted;
    }

    public bool isMuted()
    {
        return muted;
    }

    public void mute()
    {
        muted = !audios.mute;
        audios.mute = !audios.mute;
        if (!isMuted())
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
        }
    }


}
