using Unity.PolySpatial.InputDevices;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class ClickableObject0001 : MonoBehaviour
{
    public GameObject clickableObject; // 添加你的游戏对象
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
    public Vector3 _rotationSpeed = new Vector3(0 , 30 , 0);

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
                        clickableObject.transform.SetParent(leftWrist.transform);
                        clickableObject.transform.localPosition = new Vector3(0.0f,-22.0f,0.0f);
                        clickableObject.transform.localRotation = Quaternion.Euler(new Vector3(180f , 0f , 0f));
                    }
                    else
                    {
                        clickableObject.transform.SetParent(rightWrist.transform);
                        clickableObject.transform.localPosition = new Vector3(0.0f,-22.0f,0.0f);
                        clickableObject.transform.localRotation = Quaternion.Euler(new Vector3(180f , 0f , 0f));

                    }
                
                
                }
                else
                {
                    clickableObject.transform.SetParent(null);
                    clickableObject.transform.position = new Vector3(2.7f , 1.0f , 5.0f);
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

}