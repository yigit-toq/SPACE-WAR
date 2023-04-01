using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yok_Et : MonoBehaviour
{

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "mermi")
        {
            Destroy(other.gameObject);
        }
    }
}
