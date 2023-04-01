using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arkaplan : MonoBehaviour
{
    public float arkaplanHiz;

    public Transform yildiz1;
    public Transform yildiz2;

    void Start()
    {
        arkaplanHiz = 0.02f;
    }

    void FixedUpdate()
    {
        yildiz1.position -= new Vector3 (0, arkaplanHiz, 0);
        yildiz2.position -= new Vector3(0, arkaplanHiz, 0);

        if (yildiz1.position.y <= -19f)
        {
            yildiz1.position = new Vector3 (0, 20, 0);
        }

        if (yildiz2.position.y <= -19f)
        {
            yildiz2.position = new Vector3(0, 20, 0);
        }
    }
}
