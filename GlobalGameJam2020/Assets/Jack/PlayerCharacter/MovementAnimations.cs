using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimations : MonoBehaviour
{

    ParticleSystem footStep = null;
    Transform footPos = null;


    private void Awake()
    {
        footStep = GetComponent<ParticleSystem>();
        footPos = GameObject.FindGameObjectWithTag("FootPos").transform;
    }



    public void PlayFirstFoot()
    {
        AudioManager.instance.PlaySound("HandWalkingFirstStep");
        footStep.transform.position = footPos.position;
        footStep.Play();
    }


    public void PlaySecondFoot()
    {
        AudioManager.instance.PlaySound("HandWalkingSecondStep");
        footStep.transform.position = footPos.position;
        footStep.Play();
    }







}
