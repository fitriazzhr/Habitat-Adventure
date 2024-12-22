using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoscript1 : MonoBehaviour
{
    public VideoPlayer _Video;

    public void btn_sentuh(int id)
    {
        if(id == 0) // untuk play
        {
            _Video.Play();
        }
        else if(id == 1) // untuk pause
        {
            _Video.Pause();
        }
        else if(id == 2) // untuk stop
        {
           _Video.frame = 0;
           _Video.Play();
        }
    }
}
