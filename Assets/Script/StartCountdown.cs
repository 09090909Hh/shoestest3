using System;
using UnityEngine;

namespace PolySpatial.Samples
{
    public class StartButton : SpatialUI
    {
        public Action<string, MeshRenderer> WasPressed;

        public string ButtonText => m_ButtonText;
        public MeshRenderer MeshRenderer => m_MeshRenderer;

        [SerializeField]
        string m_ButtonText;

        [SerializeField]
        Animator m_Animator; // 添加 Animator 的引用

        MeshRenderer m_MeshRenderer;

        void OnEnable()
        {
            m_MeshRenderer = GetComponent<MeshRenderer>();
        }

        public override void Press(Vector3 position)
        {
            base.Press(position);

            // 设置 Animator Controller 中的 "showcase to Default" 为 true
            m_Animator.SetBool("showcase to Default", true);

            if (WasPressed != null)
            {
                WasPressed.Invoke(m_ButtonText, m_MeshRenderer);
            }
        }
    }
}