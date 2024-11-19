using UnityEngine;

namespace ZL
{
	[DisallowMultipleComponent]

	public sealed class LifeLimiter : MonoBehaviour
	{
        [Space]

		[SerializeField]

		private float lifeTime;

        public float LifeTime
        {
            get => lifeTime;

            set => lifeTime = value;
        }

        private float remainLifeTime;

        private void OnEnable()
        {
            remainLifeTime = lifeTime;
        }

        private void FixedUpdate()
		{
            if (remainLifeTime <= 0f)
            {
                gameObject.SetActive(false);
            }

            remainLifeTime -= Time.fixedDeltaTime;
        }
	}
}