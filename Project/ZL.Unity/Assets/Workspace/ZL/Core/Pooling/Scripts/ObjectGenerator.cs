using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Pooling/Object Generator")]

    public class ObjectGenerator : MonoBehaviour
    {
        [Space]

        [Essential]

        [UsingCustomProperty]

        [SerializeField]

        private string key;

        public void Generate()
        {
            var clone = ObjectPoolManager.Instance.Clone(key);

            clone.transform.SetPositionAndRotation(transform.position, transform.rotation);

            clone.gameObject.SetActive(true);
        }
    }
}