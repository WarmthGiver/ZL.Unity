using System.Collections;

using UnityEngine;

using UnityEngine.UI;

namespace ZL.UI
{
    [DisallowMultipleComponent]
    
    [RequireComponent(typeof(Image))]

    public sealed class ImageFillAmountTweener : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private Image image;

        public float FillAmount
        {
            get => image.fillAmount;

            set => image.fillAmount = value;
        }

        public void StartLerpFillAmountRoutine(float targetFillAmount, float fillSpeed)
        {
            if (lerpFillAmountRoutine != null)
            {
                StopLerpFillAmountRoutine();
            }

            lerpFillAmountRoutine = LerpFillAmountRoutine(targetFillAmount, fillSpeed);

            StartCoroutine(lerpFillAmountRoutine);
        }

        public void StopLerpFillAmountRoutine()
        {
            if (lerpFillAmountRoutine != null)
            {
                StopCoroutine(lerpFillAmountRoutine);

                lerpFillAmountRoutine = null;
            }
        }

        private IEnumerator lerpFillAmountRoutine = null;

        private IEnumerator LerpFillAmountRoutine(float targetFillAmount, float fillSpeed)
        {
            targetFillAmount = Mathf.Clamp01(targetFillAmount);

            if (fillSpeed > 0f)
            {
                float time = 0f;

                IEnumerator LerpInFixedTime()
                {
                    yield return WaitFor.FixedUpdate();

                    time += Time.fixedDeltaTime;

                    image.fillAmount = Mathf.Lerp(image.fillAmount, targetFillAmount, time * fillSpeed);
                }

                float adjustedTargetFillAmount = targetFillAmount;

                if (image.fillAmount < targetFillAmount)
                {
                    adjustedTargetFillAmount -= 0.001f;

                    while (image.fillAmount < adjustedTargetFillAmount)
                    {
                        yield return LerpInFixedTime();
                    }
                }

                else if (image.fillAmount > targetFillAmount)
                {
                    adjustedTargetFillAmount += 0.001f;

                    while (image.fillAmount > adjustedTargetFillAmount)
                    {
                        yield return LerpInFixedTime();
                    }
                }
            }

            image.fillAmount = targetFillAmount;

            lerpFillAmountRoutine = null;
        }
    }
}