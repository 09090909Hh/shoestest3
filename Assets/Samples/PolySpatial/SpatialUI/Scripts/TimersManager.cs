using Unity.PolySpatial.InputDevices;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.LowLevel;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using TMPro;

namespace PolySpatial.Samples
{
public class TimersManager : MonoBehaviour
    {
        public TextMeshPro timerText;
        private float longTouchDuration;
        private bool isCounting;

        void Update()
        {
            if (isCounting)
            {
                if (longTouchDuration > 0)
                {
                    longTouchDuration -= Time.deltaTime;
                    timerText.text = longTouchDuration.ToString("0.00"); // 更新倒计时显示
                }
                else
                {
                    longTouchDuration = 0; // 当倒计时小于0时，将其设置为0
                    timerText.text = longTouchDuration.ToString("F2");
                    Debug.Log("Start animation");
                    isCounting = false;
                }
            }
        }

        public void StartCountdown(float time)
        {
            longTouchDuration = time;
            isCounting = true;
        }
        public void ResetCountdown()
        {
            longTouchDuration = 0; // 将倒计时设置为0
            timerText.text = longTouchDuration.ToString("F2");
            isCounting = false;
        }
    }
}