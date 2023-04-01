using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloTurk : MonoBehaviour
{
    public UIKodlar UIkodlar { get; set; }
    public Arkaplan arkaplan { get; set; }

    public float karakterHiz;
    public float fireWait;
    public float donmeSüre;
    public float karakterCan;

    public float yatay;
    public float dikey;

    private float fireTime;

    public bool fire;

    private Camera kamera;

    public Joystick joystick;

    public Transform arkaPlan;

    public GameObject mermi;
    public GameObject canBar;
    public GameObject patlama;

    public Rigidbody2D myRigid { get; set; }
    public AudioSource atesSes { get; set; }

    void Start()
    {
        UIkodlar = FindObjectOfType<UIKodlar>();
        arkaplan = FindObjectOfType<Arkaplan>();

        kamera = Camera.main;

        atesSes = GameObject.FindGameObjectWithTag("atesSes").GetComponent<AudioSource>();

        myRigid = GetComponent<Rigidbody2D>();

        fire = false;

        fireTime = 0f;
        karakterCan = 2f;
    }

    void FixedUpdate()
    {
        Temel_Hareketler ();
        Arkaplan ();
        Fire ();
        Kontroller();
    }

    void Temel_Hareketler ()
    {
        yatay = joystick.Horizontal;
        dikey = joystick.Vertical;

        transform.position += new Vector3(yatay * karakterHiz, dikey * karakterHiz, 0); 

        //yatay = Input.GetAxis("Horizontal");
        //dikey = Input.GetAxis("Vertical");
    }

    void Fire ()
    {
        if (fireTime < fireWait)
        {
            fireTime++;
        }
        else if (fire && !UIkodlar.atesKes)
        {
            Instantiate (mermi, transform.position, Quaternion.identity);
            atesSes.Play();
            fireTime = 0f;
        }
    }

    void Kontroller()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            fire = true;
        }
        else
        {
            fire = false;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || yatay < -0.5f)
        {
            if (donmeSüre >= -30)
            {
                donmeSüre -= 2;
            }
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, donmeSüre, transform.eulerAngles.z);
        }
        else if (donmeSüre <= 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, donmeSüre, transform.eulerAngles.z);
            donmeSüre++;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || yatay > 0.5f)
        {
            if (donmeSüre <= 30)
            {
                donmeSüre += 2;
            }
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, donmeSüre, transform.eulerAngles.z);
        }
        else if (donmeSüre >= 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, donmeSüre, transform.eulerAngles.z);
            donmeSüre--;
        }
    }

    void Arkaplan ()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || dikey > 0)
        {
            arkaPlan.position -= new Vector3(0, arkaplan.arkaplanHiz, 0);
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "meteor")
        {
            karakterCan -= 0.25f;
            canBar.transform.localScale = new Vector3 (canBar.transform.localScale.x, karakterCan, canBar.transform.localScale.z);
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "can")
        {
            karakterCan = 2f;
            canBar.transform.localScale = new Vector3(canBar.transform.localScale.x, karakterCan, canBar.transform.localScale.z);
            Destroy(other.gameObject);
        }
    }
}
