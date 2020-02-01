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

    public Material ropeMat1;
    public Material ropeMat2;
    public Material ropeMat3;
    public Material ropeMat4;
    public Material ropeMat5;
    public Material ropeMat6;

    private void Start()
    {
        go = gameObject;
        lr = go.AddComponent<LineRenderer>();

        tetherPoint = gameObject;
        balloon = balloonPoint;

        int rand = Random.Range(1, 7);

        switch (rand)
        {
            case 1:
                {
                    lr.material = ropeMat1;
                    break;
                }
            case 2:
                {
                    lr.material = ropeMat2;
                    break;
                }
            case 3:
                {
                    lr.material = ropeMat3;
                    break;
                }
            case 4:
                {
                    lr.material = ropeMat4;
                    break;
                }
            case 5:
                {
                    lr.material = ropeMat5;
                    break;
                }
            case 6:
                {
                    lr.material = ropeMat6;
                    break;
                }
            default:
                lr.material = ropeMat1;
                break;
        }
    }


    void Update()
    {
        lr.SetPosition(0, tetherPoint.transform.position);
        lr.SetPosition(1, balloon.transform.position);

        lr.startWidth = .2f;
        lr.endWidth = .2f;
    }
}
