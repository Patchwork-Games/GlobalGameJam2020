using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBalloonColour : MonoBehaviour
{


    public Material balloonMat1;
    public Material balloonMat2;
    public Material balloonMat3;
    public Material balloonMat4;
    public Material balloonMat5;
    public Material balloonMat6;


    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(1, 7);


        switch (rand)
        {
            case 1:
                {
                    GetComponent<Renderer>().material = balloonMat1;
                    break;
                }
            case 2:
                {
                    GetComponent<Renderer>().material = balloonMat2;
                    break;
                }
            case 3:
                {
                    GetComponent<Renderer>().material = balloonMat3;
                    break;
                }
            case 4:
                {
                    GetComponent<Renderer>().material = balloonMat4;
                    break;
                }
            case 5:
                {
                    GetComponent<Renderer>().material = balloonMat5;
                    break;
                }
            case 6:
                {
                    GetComponent<Renderer>().material = balloonMat6;
                    break;
                }
            default:
                GetComponent<Renderer>().material = balloonMat1;
                break;
        }
    }

}
