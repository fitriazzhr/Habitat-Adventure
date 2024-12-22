using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Control : MonoBehaviour
{
    public bool IsTransisi, IsTidakPerlu;

    string SaveNamaScene;

    private void Awake()
    {
        if(IsTransisi && IsTidakPerlu)
        {
            gameObject.SetActive(false);
        }
    }

    public void btn_suara()
    {
        KumpulanSuara.instance.Panggil_sfx(0);
    }

    public void Btn_Pindah(string nama)
    {
        this.gameObject.SetActive(true);
        SaveNamaScene = nama;
        GetComponent<Animator>().Play("end");
    }

    public void pindah()
    {
        SceneManager.LoadScene(SaveNamaScene);
    }

}
