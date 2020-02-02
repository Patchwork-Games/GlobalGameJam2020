using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowPPklayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CinemachineFreeLook>().Follow = GameObject.FindGameObjectWithTag("Player").transform;
        GetComponent<CinemachineFreeLook>().LookAt = GameObject.FindGameObjectWithTag("Player").transform;
    }

}
