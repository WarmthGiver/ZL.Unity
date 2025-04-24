#pragma warning disable

using TMPro;

using UnityEngine;

using ZL.Unity.Phys;

namespace ZL.Unity.Demo.VRDemo
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public sealed class Goal : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private TextMeshPro goalCountText;

        [SerializeField]

        private ColliderCheckBox colliderCheckBox;

        private bool isGoal = false;

        private int goalCount = 0;

        private void Update()
        {
            if (colliderCheckBox.Check() == true)
            {
                if (isGoal == false)
                {
                    isGoal = true;

                    ++goalCount;

                    goalCountText.text = goalCount.ToString();
                }
            }

            else
            {
                isGoal = false;
            }
        }
    }
}