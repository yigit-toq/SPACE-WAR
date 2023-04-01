using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public SoloTurk karakterCode { get; set; }
    public UIKodlar UIKod;

    public float can;
    public float boyut;
    public float savrulma_y;

    private AudioSource patlama;
    private Rigidbody2D meteorRigid;

    void Start()
    {
        UIKod = FindObjectOfType<UIKodlar>();
        karakterCode = FindObjectOfType<SoloTurk>();
        meteorRigid = GetComponent<Rigidbody2D>();
        patlama = GameObject.FindGameObjectWithTag("patlamaSes").GetComponent<AudioSource>();
        boyut = Random.Range(0.5f, 1.2f);
        can = 100 * boyut;
        transform.localScale = new Vector3(boyut, boyut, transform.localScale.z);
    }

    void Update()
    {
        if (can <= 0)
        {
            StartCoroutine(Carpısma());
            UIKod.Skor += 10;
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "mermi")
        {
            Destroy(other.gameObject);
            savrulma_y = Random.Range(0.2f, 0.6f);
            transform.position += new Vector3(0, savrulma_y, 0);
            can = can - Random.Range(10, 15);
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        
        if (other.gameObject.tag == "karakter")
        {
            StartCoroutine(Carpısma());
        }

        if (other.gameObject.tag == "yokEt")
        {
            UIKod.uzayüssüCan -= boyut * 100f;
            StartCoroutine(Carpısma());
        }
    }

    IEnumerator Carpısma ()
    {
        Instantiate(karakterCode.patlama, transform.position, Quaternion.identity);
        patlama.Play();
        Destroy(gameObject);
        yield return null;
    }
}
