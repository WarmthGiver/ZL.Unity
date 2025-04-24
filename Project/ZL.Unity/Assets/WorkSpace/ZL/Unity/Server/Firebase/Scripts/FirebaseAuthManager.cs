using Firebase;

using Firebase.Auth;

using Firebase.Extensions;

using System;

using System.Collections;

using System.Threading.Tasks;

using UnityEngine;

using ZL.CS.Threading;

using ZL.Unity.Singleton;

namespace ZL.Unity.Server.Firebase.Auth
{
    [AddComponentMenu("ZL/Server/Firebase/Firebase Auth Manager (Singleton)")]

    [DefaultExecutionOrder(-2)]

    public sealed class FirebaseAuthManager : MonoSingleton<FirebaseAuthManager>
    {
        /*[Space]

        [SerializeField]

        [UsingCustomProperty]

        [Alias("ID Input Field")]

        private TMP_InputField idInputField;

        [SerializeField]

        [UsingCustomProperty]

        [Alias("PW Input Field")]

        private TMP_InputField pwInputField;

        [Space]

        [SerializeField]

        private Button loginButton;*/

        public FirebaseAuth Auth { get; private set; } = null;

        public FirebaseUser User { get; private set; } = null;

        protected override void Awake()
        {
            base.Awake();

            FirebaseApp.

                CheckAndFixDependenciesAsync().

                ContinueWithOnMainThread((task) =>
                {
                    if (task.Result == DependencyStatus.Available)
                    {
                        Auth = FirebaseAuth.DefaultInstance;
                        
                        Debug.Log("Firebase Auth load successful.");
                    }
                    
                    else
                    {
                        Debug.LogError($"Firebase Auth load failed: {task.Result}");
                    }
                });
        }

        public void SignIn(string id, string pw)
        {
            if (Auth == null)
            {
                return;
            }

            var task = Auth.SignInWithEmailAndPasswordAsync(id, pw);

            var routine = task.WaitForCompleted((task) => User = task.Result.User);

            StartCoroutine(routine);
        }

        public void SignUp(string id, string pw)
        {
            if (Auth == null)
            {
                return;
            }

            var task = Auth.CreateUserWithEmailAndPasswordAsync(id, pw);

            var routine = task.WaitForCompleted((task) => User = task.Result.User);

            StartCoroutine(routine);
        }

        public void UpdateUserProfile(UserProfile userProfile, Func<Task, IEnumerator> routine = null)
        {
            if (User == null)
            {
                return;
            }

            var task = User.UpdateUserProfileAsync(userProfile);

            if (routine != null)
            {
                StartCoroutine(routine(task));
            }
        }
    }
}