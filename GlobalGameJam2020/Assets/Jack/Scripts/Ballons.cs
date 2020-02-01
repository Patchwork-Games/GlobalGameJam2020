using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballons : MonoBehaviour
{

    public GameObject balloonPoint = null;
    GameObject go;
    LineRenderer lr;
    GameObject tetherPoint;
    GameObject balloon;

    public Material ropeMat;

    private void Start()
    {
        go = gameObject;
        lr = go.AddComponent<LineRenderer>();

        tetherPoint = gameObject;
        balloon = balloonPoint;
    }


    void Update()
    {
        lr.SetPosition(0, tetherPoint.transform.position);
        lr.SetPosition(1, balloon.transform.position);
        lr.material = ropeMat;
        lr.startWidth = .2f;
        lr.endWidth = .2f;
    }
}
