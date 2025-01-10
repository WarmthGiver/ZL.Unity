using System;

using TMPro;

using UnityEngine;

using UnityEngine.EventSystems;

using UnityEngine.UI;

namespace ZL.Unity
{
    public static class Creator
    {
        public static Text CreateText(string textString)
        {
            return CreateText("Text", textString);
        }

        public static Text CreateText(string name, string textString)
        {
            var text = CreateGraphic<Text>(name);

            text.text = textString;

            text.fontSize = 100;

            text.alignment = TextAnchor.MiddleCenter;

            text.color = Color.black;

            return text;
        }

        public static TextMeshProUGUI CreateTextMeshPro(string textString)
        {
            return CreateTextMeshPro("Text (TMP)", textString);
        }

        public static TextMeshProUGUI CreateTextMeshPro(string name, string textString)
        {
            var textMeshPro = CreateGraphic<TextMeshProUGUI>(name);

            textMeshPro.text = textString;

            textMeshPro.fontSize = 0f;

            textMeshPro.enableAutoSizing = true;

            textMeshPro.fontSizeMin = 0f;

            textMeshPro.fontSizeMax = 32767;

            textMeshPro.color = Color.black;

            textMeshPro.alignment = TextAlignmentOptions.Midline;

            return textMeshPro;
        }


        public static TGraphic CreateGraphic<TGraphic>(params Type[] component)

            where TGraphic : Graphic
        {
            return CreateGraphic<TGraphic>(typeof(TGraphic).Name.ToTitleCase(), component);
        }

        public static TGraphic CreateGraphic<TGraphic>(string name, params Type[] component)

            where TGraphic : Graphic
        {
            var graphic = CreateUI<TGraphic>(name, component);

            graphic.rectTransform.SetAnchorStrech();

            return graphic;
        }

        public static TUIBehaviour CreateUI<TUIBehaviour>(params Type[] component)

            where TUIBehaviour : UIBehaviour
        {
            return CreateUI<TUIBehaviour>(typeof(TUIBehaviour).Name.ToTitleCase(), component);
        }

        public static TUIBehaviour CreateUI<TUIBehaviour>(string name, params Type[] component)
            
            where TUIBehaviour : UIBehaviour
        {
            return CreateUI<TUIBehaviour>(name, null, component);
        }

        public static TUIBehaviour CreateUI<TUIBehaviour>(string name, Transform parent, params Type[] component)

            where TUIBehaviour : UIBehaviour
        {
#if UNITY_EDITOR

            if (UnityEditor.Selection.activeGameObject != null)
            {
                parent = UnityEditor.Selection.activeGameObject.transform;

                if (parent.GetComponentInParent<Canvas>() == null)
                {
                    parent = CreateCanvas(parent).transform;
                }
            }

#endif

            if (parent == null)
            {
                var canvas = UnityEngine.Object.FindObjectOfType<Canvas>();

                if (canvas == null)
                {
                    canvas = CreateCanvas();
                }

                parent = canvas.transform;
            }

            var uiBehaviour = Create<TUIBehaviour>(name, parent, component);

            uiBehaviour.gameObject.layer = 5;

            return uiBehaviour;
        }

        public static Canvas CreateCanvas(Transform parent = null)
        {
            var canvas = Create<Canvas>(null, parent, typeof(CanvasScaler), typeof(GraphicRaycaster));

            canvas.gameObject.layer = 5;

            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            TryCreateEventSystem();

            return canvas;
        }

        public static void TryCreateEventSystem()
        {
            if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
            {
                Create<EventSystem>(null, typeof(StandaloneInputModule));
            }
        }

        public static TComponent Create<TComponent>(Transform parent, params Type[] components)

           where TComponent : Component
        {
            var name = typeof(TComponent).Name.ToTitleCase();

            return Create<TComponent>(name, parent, components);
        }

        public static TComponent Create<TComponent>(string name, Transform parent, params Type[] components)

           where TComponent : Component
        {
            var component = Create<TComponent>(name, parent);

            component.AddComponents(components);

            return component;
        }

        public static TComponent Create<TComponent>(string name, Transform parent)

           where TComponent : Component
        {
            var gameObject = CreateGameObject(name, parent);

            return gameObject.AddComponent<TComponent>();
        }

        public static GameObject CreateGameObject(string name, Transform parent, params Type[] components)
        {
            var gameObject = CreateGameObject(name, components);

            gameObject.transform.SetParent(parent, false);

            return gameObject;
        }

        public static GameObject CreateGameObject(string name, params Type[] components)
        {
            GameObject gameObject = new(name, components);

            FixedUndo.RegisterCreatedObjectUndo(gameObject, $"Create {gameObject.name}");

            return gameObject;
        }
    }
}