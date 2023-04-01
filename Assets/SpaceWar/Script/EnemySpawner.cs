using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public UIKodlar UIKod { get; set; }

    public GameObject gokTasiObje;

    public bool gokTasi;

    public float gokTasiSüre;
    public float goktasiOlus;


    void Start()
    {
        UIKod = FindObjectOfType<UIKodlar>();

        gokTasi = false;

        gokTasiSüre = 0f;
        goktasiOlus = Random.Range(250f, 1000f);
    }

    void FixedUpdate()
    {
        GokTasi_Olustur();
    }

    void GokTasi_Olustur ()
    {
        if (!gokTasi && gokTasiSüre < goktasiOlus)
        {
            gokTasiSüre += Random.Range(0.5f,2f);
        }
        else if (!gokTasi)
        {
            gokTasi = true;
            gokTasiSüre = 0f;
        }

        if (gokTasi && !UIKod.bitti)
        {
            Instantiate(gokTasiObje, transform.position, Quaternion.identity);
            if (UIKod.Skor < 100)
            {
                goktasiOlus = Random.Range(500f, 800f);
            }
            else if (UIKod.Skor < 300)
            {
                goktasiOlus = Random.Range(450f, 700f);
            }
            else if (UIKod.Skor < 500)
            {
                goktasiOlus = Random.Range(400f, 600f);
            }
            else if (UIKod.Skor < 1000)
            {
                goktasiOlus = Random.Range(350f, 500f);
            }
            gokTasi = false;
        }
    }
}

