using UnityEngine;

namespace ZL.Unity
{
    public abstract class
        
        SingletonReceiver<TSingleton> : MonoBehaviour
        
        where TSingleton : MonoBehaviour, ISingleton<TSingleton>
    {
        protected TSingleton Target
        {
            get => ISingleton<TSingleton>.Instance;
        }
    }
}