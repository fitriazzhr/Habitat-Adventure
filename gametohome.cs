using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gametohome : MonoBehaviour
{
    public void Materi()
    {
        PlayerPrefs.SetString("TargetPanel", "menu");
        PlayerPrefs.Save();

        SceneManager.LoadScene("Materi");
    }
}
