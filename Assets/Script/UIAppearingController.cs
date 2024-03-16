using Unity.PolySpatial.InputDevices;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.LowLevel;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class TouchActivateObjectManager : MonoBehaviour
{
    public GameObject touchInputObject;
    public GameObject objectToActivate;
    public float longTouchDuration = 2f; // 长触摸时间
    public float scaleDuration = 1f; // 对象缩放的时间

    private float touchStartTime;
    private bool isTouching;

    void Start()
    {
        objectToActivate.transform.localScale = new Vector3(0, 0, 1);
        objectToActivate.SetActive(false);
        
    }

void Update()
{
    var activeTouches = Touch.activeTouches;

    if (activeTouches.Count > 0)
    {
        var primaryTouchData = EnhancedSpatialPointerSupport.GetPointerState(activeTouches[0]);
        var touchedObject = primaryTouchData.targetObject;

        if (activeTouches[0].phase == TouchPhase.Began && touchedObject != null && touchedObject == touchInputObject)
        {
            // 触摸开始，开始计时
            touchStartTime = Time.time;
            isTouching = true;
        }
        else if (activeTouches[0].phase == TouchPhase.Ended)
        {
            // 触摸结束，重置触摸状态
            isTouching = false;
        }

        // 如果正在触摸，并且已经触摸超过longTouchDuration秒，切换objectToActivate的状态
        if (isTouching && Time.time - touchStartTime >= longTouchDuration)
        {
            if (objectToActivate.activeSelf)
            {
                StartCoroutine(ScaleDownObject());
            }
            else
            {
                objectToActivate.SetActive(true);
                StartCoroutine(ScaleUpObject());
            }

            isTouching = false; // 重置触摸状态，以便下次触摸
        }
    }
}

IEnumerator ScaleUpObject()
{
    float startTime = Time.time;
    float originalZScale = objectToActivate.transform.localScale.z;
    while (Time.time - startTime < scaleDuration)
    {
        float t = (Time.time - startTime) / scaleDuration;
        objectToActivate.transform.localScale = new Vector3(t, t, originalZScale);
        yield return null;
    }
    objectToActivate.transform.localScale = new Vector3(1, 1, originalZScale);
}

IEnumerator ScaleDownObject()
{
    float startTime = Time.time;
    float originalZScale = objectToActivate.transform.localScale.z;
    while (Time.time - startTime < scaleDuration)
    {
        float t = 1 - ((Time.time - startTime) / scaleDuration);
        objectToActivate.transform.localScale = new Vector3(t, t, originalZScale);
        yield return null;
    }
    objectToActivate.transform.localScale = new Vector3(0, 0, originalZScale);
    objectToActivate.SetActive(false);
}
}