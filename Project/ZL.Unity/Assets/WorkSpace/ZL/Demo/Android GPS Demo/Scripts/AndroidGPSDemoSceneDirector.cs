#pragma warning disable

using System.Collections;

using UnityEngine;

using ZL.Unity.Directing;

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