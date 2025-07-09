using UnityEngine;

namespace ZL.Unity.Demo.EnumAttributeDemo
{
    [AddComponentMenu("")]

    [ExecuteAlways]

    public sealed class EnumAttributeDemoScene : MonoBehaviour
    {
        private void Update()
        {
            FixedDebug.ClearLog();

            FixedDebug.Log(DemoEnum.Bool.GetBool());

            FixedDebug.Log(DemoEnum.Int.GetInt());

            FixedDebug.Log(DemoEnum.Float.GetFloat());

            FixedDebug.Log(DemoEnum.String.GetString());

            FixedDebug.Log(DemoEnum.RedColor.GetColor());

            FixedDebug.Log(DemoEnum.GreenColor.GetColor());

            FixedDebug.Log(DemoEnum.BlueColor.GetColor());
        }
    }
}