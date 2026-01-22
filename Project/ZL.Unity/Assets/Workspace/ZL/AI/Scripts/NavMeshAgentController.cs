using System;

using UnityEngine;

using UnityEngine.AI;

using UnityEngine.Animations;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/AI/Nav MeshAgent Controller")]

    [RequireComponent(typeof(NavMeshAgent))]

    [DefaultExecutionOrder((int)ScriptExecutionOrder.NavMeshAgent)]

    public sealed class NavMeshAgentController : MonoBehaviour
    {
        [Space]

        [Require]

        [UsingCustomProperty]

        [SerializeField]

        private NavMeshAgent _navMeshAgent = null;

        public NavMeshAgent NavMeshAgent
        {
            get => _navMeshAgent;
        }

        [AddIndent]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private bool _isArrived = true;

        public bool IsArrived
        {
            get => _isArrived;

            private set => _isArrived = value;
        }

        private bool pathRequesting = false;

        [AddIndent]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private Vector3 _destination;

        public Vector3 Destination
        {
            get => _destination;

            set
            {
                if (_destination != value)
                {
                    IsArrived = false;

                    pathRequesting = true;
                }

                _destination = value;

                _navMeshAgent.destination = _destination;
            }
        }

        [Space]

        [SerializeField]

        private float _speed = 3.5f;

        public float Speed
        {
            get => _speed;

            set
            {
                _speed = value;

                NavMeshAgent.speed = _speed * SpeedMultiplier;
            }
        }

        [AddIndent]

        [Alias("Multiplier")]

        [UsingCustomProperty]

        [SerializeField]

        private float _speedMultiplier = 1f;

        public float SpeedMultiplier
        {
            get => _speedMultiplier;

            set
            {
                _speedMultiplier = value;

                NavMeshAgent.speed = Speed * _speedMultiplier;
            }
        }

        [SerializeField]

        private float _angularSpeed = 120f;

        public float AngularSpeed
        {
            get => _angularSpeed;

            set
            {
                _angularSpeed = value;

                NavMeshAgent.angularSpeed = _angularSpeed * AngularSpeedMultiplier;
            }
        }

        [AddIndent]

        [Alias("Multiplier")]

        [UsingCustomProperty]

        [SerializeField]

        private float _angularSpeedMultiplier = 1f;

        public float AngularSpeedMultiplier
        {
            get => _angularSpeedMultiplier;

            set
            {
                _angularSpeedMultiplier = value;

                NavMeshAgent.angularSpeed = AngularSpeed * _angularSpeedMultiplier;
            }
        }

        private Vector3 velocity = Vector3.zero;

        private void OnValidate()
        {
            if (NavMeshAgent == null)
            {
                return;
            }

            SpeedMultiplier = SpeedMultiplier;

            AngularSpeedMultiplier = AngularSpeedMultiplier;
        }

        private void OnEnable()
        {
            if (!IsArrived)
            {
                NavMeshAgent.destination = Destination;
            }

            NavMeshAgent.velocity = velocity;
        }

        private void OnDisable()
        {
            velocity = NavMeshAgent.velocity;
        }

        private void Start()
        {
            SpeedMultiplier = SpeedMultiplier;

            AngularSpeedMultiplier = AngularSpeedMultiplier;

            NavMeshAgent.updateRotation = false;
        }

        private void Update()
        {
            if (IsArrived)
            {
                return;
            }

            if (NavMeshAgent.pathPending)
            {
                pathRequesting = false;
            }

            else if (NavMeshAgent.hasPath && NavMeshAgent.remainingDistance > NavMeshAgent.stoppingDistance)
            {
                pathRequesting = false;
            }

            else if (pathRequesting)
            {
                pathRequesting = false;
            }

            else
            {
                IsArrived = true;
            }

            transform.TryLookTowards(NavMeshAgent.steeringTarget, Axis.Y, NavMeshAgent.angularSpeed * Time.deltaTime);
        }

        public void ForceStop()
        {
            NavMeshAgent.ResetPath();

            IsArrived = true;

            pathRequesting = false;

            ClearDestination();
        }

        public void ClearDestination()
        {
            _destination = transform.position;
        }

        public void SetSpeedAndMultiplier(float speed, float multiplier)
        {
            Speed = speed;

            SpeedMultiplier = multiplier;
        }

        public void SetAngularSpeedAndMultiplier(float angularSpeed, float multiplier)
        {
            AngularSpeed = angularSpeed;

            AngularSpeedMultiplier = multiplier;
        }

        [Serializable]

        public sealed class Data : IData<NavMeshAgentController>
        {
            [SerializeField]

            private TransformData transformData = new TransformData();

            [SerializeField]

            private bool isArrived;

            [SerializeField]

            private Vector3 destination;

            [SerializeField]

            private float stoppingDistance;

            [SerializeField]

            private Vector3 velocity;

            [SerializeField]

            private bool isStopped;

            [SerializeField]

            private float speed;

            [SerializeField]

            private float speedMultiplier;

            [SerializeField]

            private float angularSpeed;

            [SerializeField]

            private float angularSpeedMultiplier;

            [SerializeField]

            private float acceleration;

            public void Save(NavMeshAgentController instance)
            {
                transformData.Save(instance.transform);

                isArrived = instance.IsArrived;

                if (isArrived == false)
                {
                    destination = instance.Destination;
                }

                stoppingDistance = instance.NavMeshAgent.stoppingDistance;

                velocity = instance.NavMeshAgent.velocity;

                isStopped = instance.NavMeshAgent.isStopped;

                speed = instance.Speed;

                speedMultiplier = instance.SpeedMultiplier;

                angularSpeed = instance.AngularSpeed;

                angularSpeedMultiplier = instance.SpeedMultiplier;

                acceleration = instance.NavMeshAgent.acceleration;
            }

            public void Load(NavMeshAgentController instance)
            {
                transformData.Load(instance.NavMeshAgent);

                if (isArrived)
                {
                    instance.ForceStop();
                }

                else
                {
                    instance.ClearDestination();

                    instance.Destination = destination;
                }

                instance.NavMeshAgent.stoppingDistance = stoppingDistance;

                instance.NavMeshAgent.velocity = velocity;

                instance.NavMeshAgent.isStopped = isStopped;

                instance.SetSpeedAndMultiplier(speed, speedMultiplier);

                instance.SetAngularSpeedAndMultiplier(angularSpeed, angularSpeedMultiplier);

                instance.NavMeshAgent.acceleration = acceleration;
            }
        }
    }
}