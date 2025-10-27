using UnityEngine;

using ZL.CS.Singleton;

using ZL.Unity.Tweening;

namespace ZL.Unity.UI
{
    [DefaultExecutionOrder((int)ScriptExecutionOrder.Singleton)]

    public abstract class ScreenUI<TScreenUI> : ScreenUI, ISingleton<TScreenUI>

        where TScreenUI : ScreenUI<TScreenUI>
    {
        public static TScreenUI Instance
        {
            get => ISingleton<TScreenUI>.Instance;
        }

        protected virtual void Awake()
        {
            ISingleton<TScreenUI>.TrySetInstance((TScreenUI)this);
        }

        protected virtual void OnDestroy()
        {
            ISingleton<TScreenUI>.Release((TScreenUI)this);
        }
    }

    [AddComponentMenu("ZL/UI/Screen (UI)")]

    public class ScreenUI : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private CanvasGroup canvasGroup = null;

        [Space]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private Fader fader = null;

        public Fader Fader
        {
            get => fader;
        }

        [Space]

        [SerializeField]

        private ScreenUIGroup screenGroup = null;

        [Space]

        [PropertyField]

        [Margin]

        [ReadOnlyIfEditMode]

        [Button(nameof(Appear))]

        [Button(nameof(Disappear))]

        [UsingCustomProperty]

        [SerializeField]

        private bool isAppeared = true;

        private void Awake()
        {
            if (isAppeared == true)
            {

            }
        }

        public virtual void Appear()
        {
            if (screenGroup != null)
            {
                screenGroup.SwapCurrentScreen(this);
            }

            fader.FadeIn();
        }

        public virtual void Disappear()
        {
            fader.FadeOut();
        }
    }
}