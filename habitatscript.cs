using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class habitatscript : MonoBehaviour
{
    public GameObject btnmusic;
    public GameObject btnmusicoff;

    // Start is called before the first frame update
    void Start()
    {
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void Mute()
    {
        SistemBacksound.instance.SuaraMusik.Pause();
        btnmusicoff.SetActive(true);
        btnmusic.SetActive(false);
    }

    public void Aktifkan()
    {
        SistemBacksound.instance.SuaraMusik.UnPause();
        btnmusicoff.SetActive(false);
        btnmusic.SetActive(true);
    }
}
