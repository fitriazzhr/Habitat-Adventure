using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonscript : MonoBehaviour
{
    public GameObject home;
    public GameObject closehome;
    public GameObject btnmusic;
    public GameObject btnmusicoff;
    public GameObject info;
    public GameObject menu;
    public GameObject kompetensi;
    public GameObject materi;
    public GameObject habitat;
    public GameObject hutantropis;
    public GameObject sabana;
    public GameObject padangrumput;
    public GameObject gurun;
    public GameObject taiga;
    public GameObject tundra;
    public GameObject airtawar;
    public GameObject airasin;
    public GameObject airpayau;
    public GameObject videkosistem;
    public GameObject vidrantaimakanan;

    // Start is called before the first frame update
    void Start()
    {
        home.SetActive(true);
        closehome.SetActive(false);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
        info.SetActive(false);
        menu.SetActive(false);
        kompetensi.SetActive(false);
        materi.SetActive(false);
        habitat.SetActive(false);
        hutantropis.SetActive(false);
        sabana.SetActive(false);
        padangrumput.SetActive(false);
        gurun.SetActive(false);
        taiga.SetActive(false);
        tundra.SetActive(false);
        airtawar.SetActive(false);
        airasin.SetActive(false);
        airpayau.SetActive(false);
        videkosistem.SetActive(false);
        vidrantaimakanan.SetActive(false);

        string TargetPanel = PlayerPrefs.GetString("TargetPanel", "home");

        if(TargetPanel == "menu")
        {
            menu.SetActive(true);
            home.SetActive(false);
        }
        else
        {
            menu.SetActive(false);
            home.SetActive(true);
        }

        PlayerPrefs.DeleteKey("TargetPanel");
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

    public void closebtnClicked()
    {
        closehome.SetActive(true);
        home.SetActive(true);
    }

    public void Ya()
    {
        Debug.Log("Aplikasi akan ditutup.");
        Application.Quit();
    }

    public void Tidak()
    {
        closehome.SetActive(false);
        home.SetActive(true);
    }

    public void infobtnClicked()
    {
        home.SetActive(false);
        info.SetActive(true);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void homebtnClicked()
    {
        home.SetActive(true);
        info.SetActive(false);
        menu.SetActive(false);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void startbtnClicked()
    {
        home.SetActive(false);
        menu.SetActive(true);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void materibtnClicked()
    {
        menu.SetActive(false);
        kompetensi.SetActive(true);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
        
    }

    public void videobtnClicked()
    {
        menu.SetActive(false);
        videkosistem.SetActive(true);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void backbtnClicked()
    {
        menu.SetActive(true);
        materi.SetActive(false);
        kompetensi.SetActive(false);
        materi.SetActive(false);
        habitat.SetActive(false);
        videkosistem.SetActive(false);
        vidrantaimakanan.SetActive(false);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void kompetensibtnClicked()
    {
        menu.SetActive(false);
        kompetensi.SetActive(true);
        materi.SetActive(false);
        habitat.SetActive(false);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void isiMateribtnClicked()
    {
        menu.SetActive(false);
        kompetensi.SetActive(false);
        materi.SetActive(true);
        habitat.SetActive(false);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void habitatbtnClicked()
    {
        menu.SetActive(false);
        kompetensi.SetActive(false);
        materi.SetActive(false);
        habitat.SetActive(true);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void videkosistembtnClicked()
    {
        menu.SetActive(false);
        videkosistem.SetActive(true);
        vidrantaimakanan.SetActive(false);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void vidrantaibtnClicked()
    {
        menu.SetActive(false);
        vidrantaimakanan.SetActive(true);
        videkosistem.SetActive(false);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void tropisbtnClicked()
    {
        kompetensi.SetActive(false);
        materi.SetActive(false);
        habitat.SetActive(false);
        hutantropis.SetActive(true);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void sabanabtnClicked()
    {
        kompetensi.SetActive(false);
        materi.SetActive(false);
        habitat.SetActive(false);
        sabana.SetActive(true);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void pdgrumputbtnClicked()
    {
        kompetensi.SetActive(false);
        materi.SetActive(false);
        habitat.SetActive(false);
        padangrumput.SetActive(true);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void gurunbtnClicked()
    {
        kompetensi.SetActive(false);
        materi.SetActive(false);
        habitat.SetActive(false);
        gurun.SetActive(true);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void taigabtnClicked()
    {
        kompetensi.SetActive(false);
        materi.SetActive(false);
        habitat.SetActive(false);
        taiga.SetActive(true);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void tundrabtnClicked()
    {
        kompetensi.SetActive(false);
        materi.SetActive(false);
        habitat.SetActive(false);
        tundra.SetActive(true);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void airtwrbtnClicked()
    {
        kompetensi.SetActive(false);
        materi.SetActive(false);
        habitat.SetActive(false);
        airtawar.SetActive(true);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void airasnbtnClicked()
    {
        kompetensi.SetActive(false);
        materi.SetActive(false);
        habitat.SetActive(false);
        airasin.SetActive(true);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void airpywbtnClicked()
    {
        kompetensi.SetActive(false);
        materi.SetActive(false);
        habitat.SetActive(false);
        airpayau.SetActive(true);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    public void backhabitatbtnClicked()
    {
        hutantropis.SetActive(false);
        sabana.SetActive(false);
        padangrumput.SetActive(false);
        gurun.SetActive(false);
        taiga.SetActive(false);
        tundra.SetActive(false);
        airtawar.SetActive(false);
        airasin.SetActive(false);
        airpayau.SetActive(false);
        habitat.SetActive(true);
        btnmusic.SetActive(true);
        btnmusicoff.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
