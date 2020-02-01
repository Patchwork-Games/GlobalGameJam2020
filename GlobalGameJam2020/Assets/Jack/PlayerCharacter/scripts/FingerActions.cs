using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerActions : MonoBehaviour
{
    public Animator anim = null;


    // Update is called once per frame
    void Update()
    {

           

        if (PlayerMovement.Instance.beckon)
        {
            anim.enabled = true;
            anim.SetBool("Beckon", true);
        }
        else if (PlayerMovement.Instance.finger)
        {
            anim.enabled = true;
            anim.SetBool("Finger", true);
        }
        else
        {
            anim.Play("Beckon", -1, 0f);
            anim.Play("Finger", -1, 0f);
            anim.SetBool("Beckon", false);
            anim.SetBool("Finger", false);
            anim.enabled = false;
        }



    }
}
