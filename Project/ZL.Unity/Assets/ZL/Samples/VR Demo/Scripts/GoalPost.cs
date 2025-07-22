#pragma warning disable

using TMPro;

using UnityEngine;

using ZL.Unity.Phys;

namespace ZL.Unity.Demo.VRDemo
{
    [AddComponentMenu("")]

    public sealed class GoalPost : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private TextMeshPro goalCountText = null;

        private int goalCount = 0;

        public void Goal()
        {
            ++goalCount;

            goalCountText.text = goalCount.ToString();
        }

        public void Clear()
        {
            goalCount = 0;

            goalCountText.text = "0";
        }
    }
}