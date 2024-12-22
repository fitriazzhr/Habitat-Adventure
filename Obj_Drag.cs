using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Obj_Drag : MonoBehaviour
{
    [HideInInspector]public Vector2 SavePosisi;
    [HideInInspector]public bool IsDiatasObj;

    Transform SaveObj;

    public int ID;
    public Text Teks;

    [Space]

    public UnityEvent OnDragBenar;
    
    // Start is called before the first frame update
    void Start()
    {
        SavePosisi = transform.position;
    }

    private void OnMouseDown()
    {
        KumpulanSuara.instance.Panggil_sfx(0);
    }

    private void OnMouseUp()
    {
        if(IsDiatasObj)
        {
            int ID_TempatDrop = SaveObj.GetComponent<Tempat_Drop>().ID;
            
            if(ID == ID_TempatDrop)
            {
                transform.SetParent(SaveObj);
                transform.localPosition = Vector3.zero;
                transform.localScale = new Vector2(1.08f, 1.08f);

                SaveObj.GetComponent<SpriteRenderer>().enabled = false;

                SaveObj.GetComponent<Rigidbody2D>().simulated = false;
                SaveObj.GetComponent<BoxCollider2D>().enabled = false;
                
                gameObject.GetComponent<BoxCollider2D>().enabled = false;

                OnDragBenar.Invoke();

                // jika sukses
                GameSystem.instance.DataSaatIni++;
                Data.DataScore += 200;

                KumpulanSuara.instance.Panggil_sfx(1);
            }
            else
            {
                transform.position = SavePosisi;

                // jika salah
                Data.DataDarah -= 12;
                KumpulanSuara.instance.Panggil_sfx(5);
            }

        }
        else
        {
            transform.position = SavePosisi;
            // jika tempatnya ada
        }
    }

    private void OnMouseDrag()
    {
        if(!GameSystem.instance.GameSelesai)
        {
            Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Pos;
        }
    }


    private void OnTriggerStay2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Drop"))
        {
            IsDiatasObj = true;
            SaveObj = trig.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Drop"))
        {
            IsDiatasObj = false;
        }
    }

}
