using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buton : MonoBehaviour
{

    public Animator butonAnim;
    void OnMouseDrag()
    {
        butonAnim = GetComponent<Animator>();
        butonAnim.SetBool("buton",true);
    }

    public void Oyna ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene (1);
    }
}
