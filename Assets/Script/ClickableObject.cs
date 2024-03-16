/*using Unity.PolySpatial.InputDevices;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class ClickableObject : MonoBehaviour
{
    public TimersManager timersManager;
    public float countdownTime;
    public float longTouchThreshold = 0.5f; // 长触摸的阈值
    public GameObject objectToDisable;
    private float touchStartTime;
    private bool isTouching;

    void Update()
    {
        var activeTouches = Touch.activeTouches;

        if (activeTouches.Count > 0)
        {
            var primaryTouchData = EnhancedSpatialPointerSupport.GetPointerState(activeTouches[0]);
            var touchedObject = primaryTouchData.targetObject;

            if (activeTouches[0].phase == TouchPhase.Began && touchedObject != null && touchedObject == gameObject)
            {
                // 触摸开始，开始计时
                touchStartTime = Time.time;
                isTouching = true;
                //Debug.Log("Touch began");
            }
            else if (activeTouches[0].phase == TouchPhase.Ended)
            {
                // 触摸结束，重置触摸状态
                isTouching = false;
            }

            // 如果正在触摸，并且已经触摸超过longTouchThreshold秒，开始倒计时
            if (isTouching && Time.time - touchStartTime >= longTouchThreshold)
            {
                timersManager.StartCountdown(countdownTime);
                isTouching = false; // 重置触摸状态，以便下次触摸
                //Debug.Log("Start countdown");
                objectToDisable.SetActive(false);
            }
        }
    }
}*/