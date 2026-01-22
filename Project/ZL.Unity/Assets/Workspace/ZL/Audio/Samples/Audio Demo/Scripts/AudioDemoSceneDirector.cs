#pragma warning disable

using UnityEngine;

using UnityEngine.SceneManagement;

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