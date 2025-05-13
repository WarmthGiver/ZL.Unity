#pragma warning disable

using UnityEngine;

using UnityEngine.SceneManagement;

using ZL.Unity.Audio;

using ZL.Unity.Directing;

namespace ZL.Unity.Demo.AudioDemo
{
    [AddComponentMenu("")]

    public sealed class AudioDemoSceneDirector : SceneDirector
	{
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) == true)
            {
                AudioSourcePoolManager.Instance.Generate("Click");
            }
        }
    }
}