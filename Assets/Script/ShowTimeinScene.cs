using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PolySpatial.Samples
{
    public class SpatialUIButton : SpatialUI
    {
        public Action<string, MeshRenderer> WasPressed;

        public string ButtonText => m_ButtonText;
        public MeshRenderer MeshRenderer => m_MeshRenderer;

        [SerializeField]
        string m_ButtonText;

        [SerializeField]
        GameObject m_TargetObject; // 要切换激活状态的游戏对象

        MeshRenderer m_MeshRenderer;

        void OnEnable()
        {
            m_MeshRenderer = GetComponent<MeshRenderer>();
        }

        public override void Press(Vector3 position)
        {
            base.Press(position);

            // 切换 m_TargetObject 的激活状态
            m_TargetObject.SetActive(!m_TargetObject.activeSelf);

            if (WasPressed != null)
            {
                WasPressed.Invoke(m_ButtonText, m_MeshRenderer);
            }
        }
    }
}