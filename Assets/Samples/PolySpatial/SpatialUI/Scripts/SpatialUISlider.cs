using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PolySpatial.Samples
{
    public class SpatialUISlider : SpatialUI
    {
        [SerializeField]
        MeshRenderer m_FillRenderer;

        [SerializeField]
        TextMeshPro m_TextMeshPro; 

        [SerializeField]
        Material m_Material;

        float m_BoxColliderSizeX;

        void Start()
        {
            m_BoxColliderSizeX = GetComponent<BoxCollider>().size.x;
            // 将滑动条的位置设置为 0%
            m_FillRenderer.material.SetFloat("_Percentage", 1.0f);
            m_Material.SetFloat("_alpha", -20.0f);  // 将 Alpha 参数的值设置为 -20
            m_TextMeshPro.SetText("0.0%");  // 将显示的百分比设置为 0%
        }

        public override void Press(Vector3 position)
        {
            base.Press(position);
            var localPosition = transform.InverseTransformPoint(position);
            // 将滑动条的位置从 [-m_BoxColliderSizeX/2, m_BoxColliderSizeX/2] 映射到 [0, 1]
            var percentage = (localPosition.x + m_BoxColliderSizeX / 2) / m_BoxColliderSizeX;
            percentage = Mathf.Clamp(percentage, 0.0f, 1.0f);  // 将百分比限制在 0.0 和 1.0 之间

            m_FillRenderer.material.SetFloat("_Percentage", percentage);
            // 反转百分比，然后显示
            var reversedPercentage = 1.0f - percentage;
            m_TextMeshPro.SetText($"{(reversedPercentage * 100).ToString("F1")}%");

            // 将反转后的百分比从 [0, 1] 映射到 [-20, 1.14]，然后设置材质的 Alpha 值
            var alpha = Mathf.Lerp(-26, -13f, reversedPercentage);
            m_Material.SetFloat("_alpha", alpha);  // 使用 SetFloat 方法来设置 Alpha 参数的值
        }
        
    }
}
