using System;
using UnityEngine;

namespace PolySpatial.Samples
{
    public class SpatialUIButton2 : SpatialUI
    {
        public Action<string, MeshRenderer> WasPressed;

        public string ButtonText => m_ButtonText;
        public MeshRenderer MeshRenderer => m_MeshRenderer;

        [SerializeField]
        string m_ButtonText;

        [SerializeField]
        GameObject objectToDisable; // 添加 GameObject 的引用

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

            if (!isTouching)
            {
                timersManager.StartCountdown(countdownTime);
                isTouching = false; // 重置触摸状态，以便下次触摸
                objectToDisable.SetActive(false);
            }

            if (WasPressed != null)
            {
                //WasPressed.Invoke(m_ButtonText, m_MeshRenderer);
            }
        }
    }
}
