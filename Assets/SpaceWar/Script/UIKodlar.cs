using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UIKodlar : MonoBehaviour
{
    public Arkaplan arkaplan { get; set; }
    public SoloTurk soloTurk { get; set; }

    public float stamina2;
    public float uzayüssüCan;

    public int Skor;
    public int sonSkor;

    public bool atesKes;
    public bool bitti;
    public bool kazandin;

    //public float mesafeHiz;
    //public GameObject kazananEkrani;
    //public RectTransform mesafeRect;

    public GameObject bitisEkrani;

    public Text skorText;
    public Text sonucSkor;

    public Transform staminaBar2;

    public RectTransform uzayüssüRect;

    void Start()
    {
        arkaplan = FindObjectOfType<Arkaplan>();
        soloTurk = FindObjectOfType <SoloTurk>();

        int yeniSkor = PlayerPrefs.GetInt("skor");

        sonSkor = yeniSkor;

        uzayüssüCan = 720f;
        stamina2 = 2f;

        atesKes = false;
        kazandin = false;
        bitti = false;

        Skor = 0;
    }

    void FixedUpdate()
    {
        if (soloTurk.fire)
        {
            stamina2 -= 0.005f;
            atesKes = false;
            staminaBar2.localScale = new Vector3(staminaBar2.localScale.x, stamina2, staminaBar2.localScale.z);
        }
        else if (stamina2 <= 2)
        {
            stamina2 += 0.010f;
            atesKes = false;
            staminaBar2.localScale = new Vector3(staminaBar2.localScale.x, stamina2, staminaBar2.localScale.z);
        }

        if (stamina2 <= 0)
        {
            atesKes = true;
            stamina2 = 0f;
        }

        if (Skor >= 0)
        {
            skorText.text = Skor.ToString();
        }
        else
        {
            bitti = true;
        }

        if (uzayüssüCan <= 0)
        {
            bitti = true;
        }

        if (soloTurk.karakterCan <= 0)
        {
            bitti = true;
        }

        if (bitti)
        {
            bitisEkrani.SetActive(true);
            if (sonSkor < Skor)
            {
                sonSkor = Skor;
                PlayerPrefs.SetInt("skor", sonSkor);
            }
            sonucSkor.text = sonSkor.ToString();
        }

        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && !bitti && !kazandin)
        //{
        //mesafeHiz = arkaplan.arkaplanHiz * 10;
        //}
        //else if (!bitti && !kazandin)
        //{
        //mesafeHiz = arkaplan.arkaplanHiz * 5;
        //}

        //if (mesafeRect.sizeDelta.y <= 50)
        //{
        //kazandin = true;
        //}

        //if (kazandin)
        //{
        //kazananEkrani.SetActive(true);
        //}
        //else
        //{
        //kazananEkrani.SetActive(false);
        //}

        //if (!bitti && !kazandin) 
        //{
        //mesafeRect.sizeDelta -= new Vector2(uzayüssüRect.sizeDelta.x, mesafeHiz); 
        //}

        uzayüssüRect.sizeDelta = new Vector2(uzayüssüCan, uzayüssüRect.sizeDelta.y);
    }

    public void Play ()
    {
        SceneManager.LoadScene(1);
    }

    public void Main_Menu ()
    {
        SceneManager.LoadScene(0);
    }
}
