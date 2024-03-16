using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolySpatial;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject cameraToLookAt;
    public GameObject shoe;
    void Start()
    {
        
    }


    void Update()
    {
        transform.LookAt(cameraToLookAt.transform);
        transform.Rotate(0 , 180 , 0);
        transform.position = shoe.transform.position + cameraToLookAt.transform.right * -0.2f;
    }
}
