using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Scene Director Receiver")]

    public sealed class SceneDirectorReceiver :
        
        SceneDirectorReceiver<SceneDirector>
    {

    }

    public abstract class SceneDirectorReceiver<TSceneDirector> :
        
        SingletonReceiver<TSceneDirector>

        where TSceneDirector : SceneDirector<TSceneDirector>
    {
        public void LoadScene(string scaneName)
        {
            Target.FadeScene(scaneName);
        }

        public void Pause()
        {
            Target.Pause();
        }

        public void Resume()
        {
            Target.Resume();
        }

        public void Quit()
        {
            Target.Quit();
        }
    }
}