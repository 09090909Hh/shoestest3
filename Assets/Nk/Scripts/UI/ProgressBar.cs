using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public SpriteRenderer UI_Progress;

    public string leftHandName = "HandManager/LeftHandDebugDrawJoints/ThumbMetacarpal/Cube";
    public string rightHandName = "HandManager/RightHandDebugDrawJoints/ThumbMetacarpal/Cube";
    private GameObject leftHand;
    private GameObject rightHand;

    public int _number = 0;
    public Sprite[] progress; 

    public float _x;
    public float _y;
    public float _z;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ObjectCheck();
        if (rightHand != null && transform.parent == null)
        {
            transform.SetParent(rightHand.transform);
            transform.localPosition = new Vector3(0.106123579f,4.1507638f,4.9356432f);
        }
            transform.rotation = Quaternion.Euler(0f , 0f , 0f);

        UI_Progress.sprite = progress[_number];




        
    }

        void ObjectCheck()
    {
        if (rightHand == null)
        {
            rightHand = GameObject.Find(rightHandName);

        }

        



    }




}
