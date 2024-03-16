using Unity.Mathematics;
using Unity.PolySpatial.InputDevices;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UIElements;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class ClickableObject0002 : MonoBehaviour
{
    public GameObject clickableObject;
    public ProgressBar progressBar;
    private bool isCounted = false;
    
    #region ObjectInfo
    public string leftFingerName = "HandManager/LeftHandDebugDrawJoints/ThumbTip/Cube";
    public string rightFingerName = "HandManager/RightHandDebugDrawJoints/ThumbTip/Cube";
    public string leftWristName = "HandManager/LeftHandDebugDrawJoints/Wrist/Cube";
    public string rightWristName = "HandManager/RightHandDebugDrawJoints/Wrist/Cube";
    public string leftPalmName = "HandManager/LeftHandDebugDrawJoints/Palm/Cube";
    public string rightPalmName = "HandManager/RightHandDebugDrawJoints/Palm/Cube";
    private GameObject leftFinger;
    private GameObject rightFinger;
    private GameObject leftWrist;
    private GameObject rightWrist;
    private GameObject leftPalm;
    private GameObject rightPalm;

    #endregion

    
    private bool isOnHand = false;
    private bool leftOrRight = false;
    public Vector3 _rotationSpeed = new Vector3(0 , 30 , 0);
    public float positionSmoothSpeed = 0.125f;
    public float rotationSmoothSpeed = 0.125f;



    private Vector3 rotationAll = new Vector3(0.0f , 0.0f , 0.0f);

    void Start()
    {
        
    }

    void Update()
    {
        ObjectCheck();
        var activeTouches = Touch.activeTouches;

        if (activeTouches.Count > 0)
        {
            var primaryTouchData = EnhancedSpatialPointerSupport.GetPointerState(activeTouches[0]);
            var touchedObject = primaryTouchData.targetObject;

            if (activeTouches[0].phase == TouchPhase.Began && touchedObject != null && touchedObject == clickableObject)
            {

                if (!isOnHand)
                {
                    if(Vector3.Distance(clickableObject.transform.position , leftPalm.transform.position) < Vector3.Distance(clickableObject.transform.position , rightPalm.transform.position))
                    {
                        clickableObject.transform.position = leftWrist.transform.position;
                        //clickableObject.transform.localPosition = new Vector3(0.0f,0.0f,0.0f);
                        clickableObject.transform.rotation = leftWrist.transform.rotation * Quaternion.Euler(new Vector3(180f , 0f , 0f));
                        leftOrRight = true;

                    }
                    else
                    {
                        clickableObject.transform.position = rightWrist.transform.position;
                        //clickableObject.transform.localPosition = new Vector3(0.0f,0.0f,0.0f);
                        clickableObject.transform.rotation = rightWrist.transform.rotation * Quaternion.Euler(new Vector3(180f , 0f , 0f)); 
                        leftOrRight = false;

                    }

                    if(!isCounted)
                    {
                        isCounted = true;
                        progressBar._number += 1;


                    }

                
                
                }
                else
                {
                    clickableObject.transform.position = new Vector3(-0.880421519f,0.607187331f,0.387081861f);
                    clickableObject.transform.rotation = Quaternion.Euler(new Vector3(0f , 0f , 0f));
                    

                }

                isOnHand = !isOnHand;
            }
            else if (activeTouches[0].phase == TouchPhase.Ended)
            {



            }
        }
    
        if (isOnHand)
        {
            if (leftOrRight)
            {
                PositionSmooth(leftWrist.transform);
                RotationSmooth(leftWrist.transform);


            }
            else
            {
                PositionSmooth(rightWrist.transform);
                RotationSmooth(rightWrist.transform);


            }
        }

        if (isOnHand)
        {
            Vector3 rotationPerSecond = _rotationSpeed * Time.deltaTime;
            rotationAll += rotationPerSecond; 
            clickableObject.transform.rotation *= Quaternion.Euler(rotationAll);



        }
        if (!isOnHand)
        {
            Vector3 rotationPerSecond = _rotationSpeed * Time.deltaTime;
            
            clickableObject.transform.rotation *= Quaternion.Euler(rotationPerSecond);


        }





    
    
    
    
    
    }

    void ObjectCheck()
    {
        if (leftFinger == null || leftWrist == null || leftPalm == null)
        {
            leftFinger = GameObject.Find(leftFingerName);
            leftWrist = GameObject.Find(leftWristName);
            leftPalm = GameObject.Find(leftPalmName);
        }
        if (rightFinger == null)
        {
            rightFinger = GameObject.Find(rightFingerName);
            rightWrist = GameObject.Find(rightWristName);
            rightPalm = GameObject.Find(rightPalmName);
        }
        if (leftFinger != null)
        {
            //leftFingerPos = leftFinger.transform.position;
        }
        if (rightFinger != null)
        {
            //rightFingerPos = rightFinger.transform.position;
        }




    }

    void PositionSmooth(Transform _target)
    {
        Vector3 targetPosition = _target.position;
        Vector3 smoothPosition = Vector3.Lerp(clickableObject.transform.position , targetPosition , positionSmoothSpeed);
        smoothPosition = smoothPosition - _target.up * 0.03f + _target.forward * 0.01f ;
        clickableObject.transform.position = smoothPosition;

    }

    void RotationSmooth(Transform _target)
    {
        clickableObject.transform.rotation = _target.transform.rotation;
        clickableObject.transform.Rotate(new Vector3(180.0f , 0.0f , 0.0f));



    }





}