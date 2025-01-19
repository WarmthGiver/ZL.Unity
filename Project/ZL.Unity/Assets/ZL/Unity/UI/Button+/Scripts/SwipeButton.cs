using System.Collections;

using UnityEngine;

using UnityEngine.EventSystems;

using UnityEngine.Events;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Button (Swipe)")]

    public sealed class SwipeButton : AutoButton
    {
        [SerializeField, ReadOnly]

        private float swipeMagnitude = 0f;

        [SerializeField]

        private float requiredSwipeMagnitude = 0f;

        [SerializeField]

        private UnityEvent onSwipeUp = null;

        public UnityEvent OnSwipeUp => onSwipeUp;

        [SerializeField]

        private UnityEvent onSwipeDown = null;

        public UnityEvent OnSwipeDown => onSwipeDown;

        [SerializeField]

        private UnityEvent onSwipeRight = null;

        public UnityEvent OnSwipeRight => onSwipeRight;

        [SerializeField]

        private UnityEvent onSwipeLeft = null;

        public UnityEvent OnSwipeLeft => onSwipeLeft;

        private readonly UnityEvent onSwipe = new();

        private readonly Vector2 normalizedOne = new(0.7071068f, -0.7071068f);

        private Vector3 pointerDownPosition;

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (swipeMagnitude < requiredSwipeMagnitude)
            {
                base.OnPointerClick(eventData);
            }
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);

            if (IsInteractable() && swipeRoutine == null)
            {
                swipeRoutine = SwipeRoutine();

                StartCoroutine(swipeRoutine);
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);

            if (swipeRoutine != null)
            {
                StopCoroutine(swipeRoutine);

                swipeRoutine = null;
            }
        }

        private IEnumerator swipeRoutine = null;

        private IEnumerator SwipeRoutine()
        {
            while (true)
            {
                pointerDownPosition = Input.mousePosition;

                yield return WaitFor.FixedUpdate();

                var swipeDirection = Input.mousePosition - pointerDownPosition;

                swipeMagnitude = swipeDirection.magnitude;

                if (swipeMagnitude >= requiredSwipeMagnitude)
                {
                    StopAutoClick();

                    onSwipe.RemoveAllListeners();

                    FixedDebug.DrawLine(pointerDownPosition, Input.mousePosition, Color.red, 1f);

                    swipeDirection.Normalize();

                    if (swipeDirection.x < normalizedOne.x && swipeDirection.x > normalizedOne.y)
                    {
                        if (swipeDirection.y > 0f)
                        {
                            onSwipe.AddListener(() => onSwipeUp.Invoke());
                        }

                        else if (swipeDirection.y < 0f)
                        {
                            onSwipe.AddListener(() => onSwipeDown.Invoke());
                        }
                    }

                    else if (swipeDirection.y < normalizedOne.x && swipeDirection.y > normalizedOne.y)
                    {
                        if (swipeDirection.x > 0f)
                        {
                            onSwipe.AddListener(() => onSwipeRight.Invoke());
                        }

                        else if (swipeDirection.x < 0f)
                        {
                            onSwipe.AddListener(() => onSwipeLeft.Invoke());
                        }
                    }

                    onSwipe.Invoke();

                    StartAutoClick(onSwipe);

                    break;
                }
            }
        }
    }
}