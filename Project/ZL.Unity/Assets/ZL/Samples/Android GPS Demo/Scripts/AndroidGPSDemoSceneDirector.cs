#pragma warning disable

using System.Collections;

using UnityEngine;

namespace ZL.Unity.Demo.AndroidGPSDemo
{
    [AddComponentMenu("")]

    public sealed class AndroidGPSDemoSceneDirector : SceneDirector
    {
        protected override IEnumerator Start()
        {
            yield return base.Start();


        }
    }
}