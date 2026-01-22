using UnityEngine;

namespace ZL.Unity
{
    public abstract class MaterialController : MonoBehaviour
    {
        public abstract Material Material { get; }

        public abstract string PropertyName { get; set; }

        public void SetInt(int value)
        {
            Material.SetInt(PropertyName, value);
        }

        public void SetInt(string propertyName, int value)
        {
            Material.SetInt(propertyName, value);
        }
        public void SetFloat(float value)
        {
            Material.SetFloat(PropertyName, value);
        }

        public void SetFloat(string propertyName, float value)
        {
            Material.SetFloat(propertyName, value);
        }

        public void SetColor(Color value)
        {
            Material.SetColor(PropertyName, value);
        }

        public void SetColor(string propertyName, Color value)
        {
            Material.SetColor(propertyName, value);
        }
    }
}