using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Main_Menu_video : MonoBehaviour
{
    public RawImage menu_bg;
    public VideoPlayer menu_video;
    public AudioSource menu_audio_source;
    
    void Start()
    {
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        menu_video.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);

        while (!menu_video.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        menu_bg.texture = menu_video.texture;
        menu_video.Play();
    }

    //void PlayVideo()
    //{
    //    menu_video.Prepare();
    //    menu_bg.texture = menu_video.texture;
    //    menu_video.Play();
    //}
}
