using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sabanascript : MonoBehaviour
{
    public GameObject btnmusic;
    public GameObject btnmusicoff;
    
    [System.Serializable]

    public class DataMateri
    {
        public Sprite Materi_Gambar;
        public AudioClip Materi_Suara;
    }

    public List<DataMateri> _Data;

    [Header("Data Component")]
    public int Data_Materi;
    public Image Gambar_Materi;

    public AudioSource SourceSuara;

    // Start is called before the first frame update
    void Start()
    {
        Data_Materi = 0;
        v_SetMateri();
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void v_Tombol(bool ArahKanan)
    {
        if (ArahKanan)
        {
            if (Data_Materi < _Data.Count - 1) 
                Data_Materi++;
        }
        else
        {
            if (Data_Materi > 0) 
                Data_Materi--;
        }
        v_SetMateri();
    }

    public void v_SetMateri()
    {
        if (Data_Materi >= 0 && Data_Materi < _Data.Count)
        {
            Gambar_Materi.sprite = _Data[Data_Materi].Materi_Gambar;
        }
        else
        {
            Debug.Log("Data tidak ada");
        }
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
