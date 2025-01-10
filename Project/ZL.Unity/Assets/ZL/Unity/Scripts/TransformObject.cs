using UnityEngine;

namespace ZL.Unity
{
    [DisallowMultipleComponent]

    public class TransformObject : MonoBehaviour
    {
        private TransformData transformData;

        public void Initialize(TransformData transformData)
        {
            this.transformData = transformData;

            LoadTransformInfo();
        }

        public void LoadTransformInfo()
        {
            transform.Set(transformData);
        }

        public void SaveTransformInfo()
        {
            transformData.Set(transform);
        }
    }
}