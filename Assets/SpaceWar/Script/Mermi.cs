using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour
{
    public bool ilerle;

    public float mermiHiz;

    void Start()
    {
        ilerle = true;
    }

    void FixedUpdate()
    {
        if (ilerle)
        {
            transform.position += new Vector3 (0, mermiHiz, 0);
        }
    }
}
