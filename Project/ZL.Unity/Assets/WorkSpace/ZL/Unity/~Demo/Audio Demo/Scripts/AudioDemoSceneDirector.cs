#pragma warning disable

using UnityEngine;

using UnityEngine.SceneManagement;

using ZL.Unity.Audio;

using ZL.Unity.Directing;

using ZL.Unity.Pooling;

namespace ZL.Unity.Demo.AudioDemo
{
    [AddComponentMenu("")]

    public sealed class AudioDemoSceneDirector : SceneDirector
	{
        [Space]

        [SerializeField]

        private ObjectPool<AudioSource> clickSFXPool = null;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) == true)
            {
                clickSFXPool.Generate().SetActive(true);
            }
        }
    }
}