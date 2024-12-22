using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Data
{
    public static int DataScore,DataWaktu,DataDarah,DataLevel;
}

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;

    int MaxLevel = 5;

    [Header("Data Permainan")]
    public bool GameAktif;
    public bool GameSelesai;
    public bool SistemAcak;
    public int Target,DataSaatIni;


    [Header("Komponen UI")]
    public Text Teks_Level;
    public Text Teks_Waktu,Teks_Score;
    public RectTransform UI_Darah;

    [Header("Obj GUI")]
    public GameObject Gui_Pause;
    public GameObject Gui_Transisi;

    [System.Serializable]
    public class DataGame
    {
        public string Nama;
        public Sprite Gambar;
    }

    [Header("Settingan Standar")]
    public DataGame[] DataPermainan;


    [Space]
    [Space]
    [Space]

    public Obj_TempatDrop[] Drop_Tempat;
    public Obj_Drag[] Drag_Obj;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameAktif = false;
        GameSelesai = false;

        AcakSoal();
        
        ResetData();
        Target = Drop_Tempat.Length;
        // if(SistemAcak)

        DataSaatIni = 0;
        GameAktif = true;
    }


    public void ResetData()
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Game0")
        {
            Data.DataWaktu = 60 * 3;
            Data.DataScore = 0;
            Data.DataDarah = 60;
            Data.DataLevel = 0;
        }
    }

    [HideInInspector]public List<int> _AcakSoal = new List<int>();
    [HideInInspector]public List<int> _AcakPos = new List<int>();
    int rand;
    int rand2;
    // public void AcakSoal()
    // {
    //     _AcakSoal.Clear();
    //     _AcakPos.Clear();

    //     _AcakSoal = new List<int>(new int[Drag_Obj.Length]);

    //     for (int i = 0; i < _AcakSoal.Count; i++)
    //     {
    //         rand = Random.Range(1, DataPermainan.Length);
    //         while(_AcakSoal.Contains(rand))
    //             rand = Random.Range(1, DataPermainan.Length);

    //         _AcakSoal[i] = rand;

    //         Drag_Obj[i].ID = rand - 1;
    //         Drag_Obj[i].Teks.text = DataPermainan[rand - 1].Nama;
    //     }

    //     _AcakPos = new List<int>(new int[Drop_Tempat.Length]);

    //     for (int i = 0; i < _AcakPos.Count; i++)
    //     {
    //         rand2 = Random.Range(1, _AcakSoal.Count+1);
    //         while(_AcakPos.Contains(rand))
    //             rand2 = Random.Range(1, _AcakSoal.Count+1);

    //         _AcakPos[i] = rand2;

    //         Drop_Tempat[i].Drop.ID = _AcakSoal[rand2 - 1] - 1;
    //         Drop_Tempat[i].Gambar.sprite = DataPermainan[Drop_Tempat[i].Drop.ID].Gambar;
    //     }

    // }

    public void AcakSoal()
    {
        // Bersihkan list sebelumnya
        _AcakSoal.Clear();
        _AcakPos.Clear();

        // Membuat list indeks soal unik dari DataPermainan
        List<int> indeksSoal = Enumerable.Range(0, DataPermainan.Length).ToList();

        // Acak indeks soal
        for (int i = 0; i < Drag_Obj.Length; i++)
        {
            // Pilih indeks secara acak dari daftar indeks soal yang tersedia
            int randIndex = Random.Range(0, indeksSoal.Count);
            int soalDipilih = indeksSoal[randIndex];

            // Tambahkan ke daftar _AcakSoal
            _AcakSoal.Add(soalDipilih);

            // Set data untuk Drag_Obj
            Drag_Obj[i].ID = soalDipilih;
            Drag_Obj[i].Teks.text = DataPermainan[soalDipilih].Nama;

            // Hapus indeks yang sudah dipakai dari daftar indeks soal
            indeksSoal.RemoveAt(randIndex);
        }

        // Membuat daftar indeks posisi untuk Drop_Tempat
        List<int> indeksPosisi = Enumerable.Range(0, Drag_Obj.Length).ToList();

        // Acak posisi
        for (int i = 0; i < Drop_Tempat.Length; i++)
        {
            // Pilih indeks secara acak dari daftar indeks posisi yang tersedia
            int randPosIndex = Random.Range(0, indeksPosisi.Count);
            int posisiDipilih = indeksPosisi[randPosIndex];

            // Tambahkan ke daftar _AcakPos
            _AcakPos.Add(posisiDipilih);

            // Set data untuk Drop_Tempat
            Drop_Tempat[i].Drop.ID = _AcakSoal[posisiDipilih];
            Drop_Tempat[i].Gambar.sprite = DataPermainan[_AcakSoal[posisiDipilih]].Gambar;

            // Hapus indeks posisi yang sudah dipakai dari daftar
            indeksPosisi.RemoveAt(randPosIndex);
        }
    }


    float s;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            AcakSoal();

        if(GameAktif && !GameSelesai)
        {
            if(Data.DataWaktu > 0)
            {
                s += Time.deltaTime;
                if(s >= 1)
                {
                    Data.DataWaktu--;
                    s = 0;
                }
            }
            if(Data.DataWaktu <= 0)
            {
                GameAktif = false;
                GameSelesai = true;

                // game kalah
                Gui_Transisi.GetComponent<UI_Control>().Btn_Pindah("GameSelesai");
                KumpulanSuara.instance.Panggil_sfx(2);

            }

            if(Data.DataDarah <= 0)
            {
                GameSelesai = true;
                GameAktif = false;

                // fungsi kalah
                Gui_Transisi.GetComponent<UI_Control>().Btn_Pindah("GameSelesai");
                KumpulanSuara.instance.Panggil_sfx(2);
            }

            if(DataSaatIni >= Target)
            {
                GameSelesai = true;
                GameAktif = false;

                // menang
                if(Data.DataLevel < (MaxLevel-1))
                {
                    Data.DataLevel++;

                    // pindah ke next level
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Game" + Data.DataLevel);


                    // Gui_Transisi.GetComponent<UI_Control>().Btn_Pindah("Game" + Data.DataLevel);

                    KumpulanSuara.instance.Panggil_sfx(4);
                }
                else
                {
                    // game selesai pindah ke menu selesai
                    Gui_Transisi.GetComponent<UI_Control>().Btn_Pindah("GameSelesai");
                    KumpulanSuara.instance.Panggil_sfx(3);
                }
            }
        }

        SetInfoUI();
            
    }

    public void SetInfoUI()
    {
        Teks_Level.text = (Data.DataLevel + 1).ToString();

        int Menit = Mathf.FloorToInt(Data.DataWaktu / 60);// 01
        int Detik = Mathf.FloorToInt(Data.DataWaktu % 60);// 30
        Teks_Waktu.text = Menit.ToString("00") + ":" + Detik.ToString("00");

        Teks_Score.text = Data.DataScore.ToString();

        UI_Darah.sizeDelta = new Vector2(5.130f * Data.DataDarah, 61.31f);
    }

    public void Pause(bool pause)
    {
        if(pause)
        {
            GameAktif = false;
            Gui_Pause.SetActive(true);
        }
        else
        {
            GameAktif = true;
            Gui_Pause.SetActive(false);
        }
    }
}
