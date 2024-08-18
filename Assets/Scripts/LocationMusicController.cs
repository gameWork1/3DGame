using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationMusicController : MonoBehaviour
{
    public AudioSource music;
    [SerializeField] private float time;

    private void Start()
    {
        music.mute = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            music.mute = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            music.mute = true;
        }
    }

    //IEnumerator slowUnMute()
    //{
    //    music.mute = false;
    //    music.volume = 0;
    //    float partMinus = time * Time.deltaTime;
    //    while(music.volume < 1)
    //    {
    //        music.volume += partMinus;
    //    }
    //    music.volume = 1;
    //    yield return null;
    //}
}
