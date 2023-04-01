using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static UIKodlar UIKod;

    public GameObject canObje;

    public bool can;

    public float canSüre;
    public float canOlus;

    private float konum1 = -2.5f;
    private float konum2 =    0f;
    private float konum3 =  2.5f;

    public int konumNe;

    void Start()
    {
        UIKod = FindObjectOfType<UIKodlar>();

        can = false;

        konumNe = 0;
        canSüre = 0f;
        canOlus = Random.Range(1250f, 5000f);
    }

    void FixedUpdate()
    {
        Can_Olustur();

        if (konumNe == 1)
        {
            transform.position = new Vector2(konum1, transform.position.y);
        }
        else if (konumNe == 2)
        {
            transform.position = new Vector2(konum2, transform.position.y);
        }
        else if (konumNe == 3)
        {
            transform.position = new Vector2(konum3, transform.position.y);
        }
    }

    void Can_Olustur()
    {
        if (!can && canSüre < canOlus)
        {
            canSüre += Random.Range(0.5f, 2f);
        }
        else if (!can)
        {
            can = true;
            canSüre = 0f;
            konumNe = Random.Range(0, 4);
        }

        if (can && !UIKod.bitti)
        {
            Instantiate(canObje, transform.position, Quaternion.identity);
            if (UIKod.Skor < 100)
            {
                canOlus = Random.Range(4000f, 6000f);
            }
            else if (UIKod.Skor < 300)
            {
                canOlus = Random.Range(4500f, 6500f);
            }
            else if (UIKod.Skor < 500)
            {
                canOlus = Random.Range(5000f, 7000f);
            }
            else if (UIKod.Skor < 1000)
            {
                canOlus = Random.Range(5500f, 7500f);
            }
            can = false;
        }
    }
}
