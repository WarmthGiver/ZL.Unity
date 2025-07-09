#pragma warning disable

using UnityEngine;

using UnityEngine.SceneManagement;

using ZL.Unity.Audio;

using ZL.Unity.Pooling;

namespace ZL.Unity.Demo.AudioDemo
{
    [AddComponentMenu("")]

    public sealed class AudioDemoSceneDirector : SceneDirector
	{
        [Space]

        [SerializeField]

        private ObjectPool clickSFXPool = null;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) == true)
            {
                clickSFXPool.Clone().Appear();
            }
        }
    }
}