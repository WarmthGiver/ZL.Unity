using UnityEngine;

using ZL.Unity.Collections;

namespace ZL.Unity.Pooling
{
    [AddComponentMenu("ZL/Pooling/Object Generator")]

    public sealed class ObjectGenerator : ObjectGenerator<Transform>
    {

    }

    public abstract class ObjectGenerator<TComponent> : MonoBehaviour

        where TComponent : Component
    {
        [Space]

        [SerializeField]

        protected SerializableDictionary<string, ObjectPool<TComponent>> poolDictionary = null;

        public virtual void Generate(string key)
        {
            poolDictionary[key].Generate().SetActive(true);
        }
    }
}