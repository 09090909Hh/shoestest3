using Unity.PolySpatial.InputDevices;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using TMPro;
using System.Collections;

public class RestTimeController : MonoBehaviour
{
    public TextMeshPro textMeshPro; // TextMeshPro组件
    public GameObject otherTextObject; // 另一个文本组件的游戏对象
    public GameObject animationObject; // 动画对象
    public float countdownTime = 5f; // 倒计时时间
    [SerializeField]
    private string boolName = "YourBoolName"; // Animator中的bool变量名
    private Animator animationAnimator; // Animator组件
    private bool restTime = false;


    void Start()
    {
        if (animationObject != null)
        {
            animationAnimator = animationObject.GetComponent<Animator>(); // 获取 Animator 组件
            otherTextObject.SetActive(false); // 关闭另一个文本组件
        }
        else
        {
            Debug.LogError("Animation object is not assigned in the inspector.");
        }
    }

    void Update()
    {
        if (textMeshPro.text == "0.00")
    {
        otherTextObject.SetActive(true); // 开启另一个文本组件
        animationAnimator.SetBool(boolName, true); // 将Animator中的bool状态改为true
        StartCoroutine(Countdown()); // 开始倒计时
        restTime = true; // 开始倒计时，将restTime设置为true
    }

    var activeTouches = Touch.activeTouches;
    if (activeTouches.Count > 0)
    {
        var primaryTouchData = EnhancedSpatialPointerSupport.GetPointerState(activeTouches[0]);
        var touchedObject = primaryTouchData.targetObject;

        if (activeTouches[0].phase == TouchPhase.Began && touchedObject != null && touchedObject == animationObject)
        {
            // 触摸开始，检查restTime的状态
            if (restTime)
            {
                // 如果restTime为true，激活"Rest to Rest Pinch"
                animationAnimator.SetBool("Rest to Rest Pinch", true);
            }
        }
        else if (activeTouches[0].phase == TouchPhase.Ended)
        {
            // 触摸结束，结束动画
            animationAnimator.SetBool("Rest to Rest Pinch", false);
        }
    }
    }

    IEnumerator Countdown()
    {
        while (countdownTime > 0)
    {
        countdownTime -= Time.deltaTime;
        textMeshPro.text = countdownTime.ToString("0.00"); // 更新倒计时显示
        yield return null; // 等待下一帧
    }

        if (countdownTime <= 0.01f)
        {
            animationAnimator.SetBool(boolName, false); // 将Animator中的bool状态改为false
            countdownTime = 0f; // 重置倒计时时间
            textMeshPro.text = "Start Another Round?";
            otherTextObject.SetActive(false); // 开启另一个文本组件
        }
    }
}