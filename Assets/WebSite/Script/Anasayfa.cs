using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anasayfa : MonoBehaviour
{


    void Start()
    {
        
    }

    void Update()
    {
        Kontroller ();
    }

    void Kontroller()
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y <= 2)
        {
            transform.position += new Vector3 (0, 0.1f,0);
        }

        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y >= -3f)
        {

            transform.position += new Vector3(0, -0.1f, 0);
        }          
    }
}
