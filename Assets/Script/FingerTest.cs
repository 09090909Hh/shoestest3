using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerTest : MonoBehaviour
{
    public GameObject leftFinger;
    public GameObject rightFinger;
    public string leftFingerName = "HandManager/LeftHandDebugDrawJoints/ThumbTip/Cube";
    public string rightFingerName = "HandManager/RightHandDebugDrawJoints/ThumbTip/Cube";
    private Vector3 leftFingerPos;
    private Vector3 rightFingerPos;
    public Material mat;
    void Start()
    {
        
        
    }

    private void TouchTest()
    {
        if (leftFinger != null && rightFinger != null)
        {
            if (Vector3.Distance(leftFingerPos, rightFingerPos) < 0.2f)
            {
                Debug.Log("Touch");
                mat.color = Color.red;
            }
            else
            {
                mat.color = Color.white;
            }

        }
    }



    // Update is called once per frame
    void Update()
    {
        if (leftFinger == null)
        {
            leftFinger = GameObject.Find(leftFingerName);
        }
        if (rightFinger == null)
        {
            rightFinger = GameObject.Find(rightFingerName);
        }
        if (leftFinger != null)
        {
            leftFingerPos = leftFinger.transform.position;
        }
        if (rightFinger != null)
        {
            rightFingerPos = rightFinger.transform.position;
        }
        TouchTest();

        
    }
}
