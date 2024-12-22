using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemBacksound : MonoBehaviour
{
    public static SistemBacksound instance;
    public AudioSource SuaraMusik;

    public void OnEnable()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
