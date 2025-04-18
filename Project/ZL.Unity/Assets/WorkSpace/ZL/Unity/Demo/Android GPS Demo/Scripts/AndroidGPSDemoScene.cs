using System.Collections;

using UnityEngine;

namespace ZL.Unity.Demo.AndroidGPSDemo
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public sealed class AndroidGPSDemoScene : SceneDirector
    {
        protected override IEnumerator Start()
        {
            yield return base.Start();


        }
    }
}