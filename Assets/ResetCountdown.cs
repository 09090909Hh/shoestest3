using System;
using UnityEngine;

namespace PolySpatial.Samples
{
    public class ResetCountdown : SpatialUI
    {
        public Action<string, MeshRenderer> WasPressed;

        public string ButtonText => m_ButtonText;
        public MeshRenderer MeshRenderer => m_MeshRenderer;

        [SerializeField]
        string m_ButtonText;

        [SerializeField]
        TimersManager timersManager; // 添加 TimersManager 的引用

        [SerializeField]
        float countdownTime; // 添加倒计时时间的引用


        MeshRenderer m_MeshRenderer;

        bool isTouching = false; // 添加触摸状态的引用

        void OnEnable()
        {
            m_MeshRenderer = GetComponent<MeshRenderer>();
        }

        public override void Press(Vector3 position)
        {
            base.Press(position);

            if (WasPressed != null)
            {
                WasPressed.Invoke(m_ButtonText, m_MeshRenderer);
                Debug.Log("1");
            }

            // 调用ResetCountdown方法
            if (timersManager != null)
            {
                timersManager.ResetCountdown();
                Debug.Log("Reset countdown");
            }
        }
    }
}
