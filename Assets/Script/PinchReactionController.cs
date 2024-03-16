using Unity.PolySpatial.InputDevices;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class ClickableObject : MonoBehaviour
{
    public GameObject animationObject; // 添加你的游戏对象
    private Animator animationAnimator; // 添加 Animator 变量
    [SerializeField]
    private string boolName = "YourAnimationName"; // 你的动画名称

    void Start()
    {
        if (animationObject != null)
        {
            animationAnimator = animationObject.GetComponent<Animator>(); // 获取 Animator 组件
        }
        else
        {
            Debug.LogError("Animation object is not assigned in the inspector.");
        }
    }

    void Update()
    {
        var activeTouches = Touch.activeTouches;

        if (activeTouches.Count > 0)
        {
            var primaryTouchData = EnhancedSpatialPointerSupport.GetPointerState(activeTouches[0]);
            var touchedObject = primaryTouchData.targetObject;

            if (activeTouches[0].phase == TouchPhase.Began && touchedObject != null && touchedObject == animationObject)
            {
                // 触摸开始，开始动画
                animationAnimator.SetBool(boolName, true);
            }
            else if (activeTouches[0].phase == TouchPhase.Ended)
            {
                // 触摸结束，结束动画
                animationAnimator.SetBool(boolName, false);
            }
        }
    }
}