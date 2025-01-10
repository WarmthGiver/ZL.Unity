using System.Collections;

using UnityEngine;

using UnityEngine.EventSystems;

using UnityEngine.Events;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Button(Auto)")]

    public class AutoButton : NewButton
    {
        [SerializeField]

        protected float clickDelay;

        [SerializeField]

        private bool useCurve = false;

        public bool UseCurve => useCurve;

        [SerializeField]

        private float clickCoolTime;

        [SerializeField]

        private AnimationCurve clickCoolTimeCurve;

        private float pressedTime = 0f;

        private UnityEvent onAutoClick;

        protected override void Reset()
        {
            base.Reset();

            clickDelay = 1f;

            clickCoolTime = 0.1f;

            var keyframes = new Keyframe[]
            {
                new(0f, 1f),

                new(3f, 0.1f),
            };

            clickCoolTimeCurve = new(keyframes);

            FixedAnimationUtility.SetKeyRightTangentMode(clickCoolTimeCurve, 0, FixedTangentMode.Auto);

            FixedAnimationUtility.SetKeyLeftTangentMode(clickCoolTimeCurve, 1, FixedTangentMode.Auto);
        }

        public override void OnPointerDown(PointerEventData pointEventData)
        {
            base.OnPointerDown(pointEventData);

            if (IsInteractable() == true)
            {
                StartAutoClick(onClick);
            }
        }

        public override void OnPointerUp(PointerEventData pointEventData)
        {
            base.OnPointerUp(pointEventData);

            StopAutoClick();
        }

        public override void OnPointerClick(PointerEventData pointEventData)
        {
            if (pressedTime > 0f || clickDelay == 0f)
            {
                pressedTime = 0f;
            }

            else
            {
                base.OnPointerClick(pointEventData);
            }
        }

        protected void StartAutoClick(UnityEvent onAutoClick)
        {
            if (autoClickRoutine == null)
            {
                this.onAutoClick = onAutoClick;

                autoClickRoutine = AutoClickRoutine();

                StartCoroutine(autoClickRoutine);
            }
        }

        protected void StopAutoClick()
        {
            if (autoClickRoutine != null)
            {
                StopCoroutine(autoClickRoutine);

                autoClickRoutine = null;
            }
        }

        private IEnumerator autoClickRoutine;

        protected virtual IEnumerator AutoClickRoutine()
        {
            pressedTime = 0f;

            float coolTime = clickDelay;

            if (useCurve == true)
            {
                while (true)
                {   
                    yield return AutoClickRoutine_Core(coolTime);

                    coolTime = clickCoolTimeCurve.Evaluate(pressedTime);
                }
            }

            while (true)
            {
                yield return AutoClickRoutine_Core(coolTime);

                coolTime = clickCoolTime;
            }
        }

        private IEnumerator AutoClickRoutine_Core(float coolTime)
        {
            yield return WaitFor.Seconds(coolTime);

            pressedTime += coolTime;

            onAutoClick.Invoke();
        }
    }
}