using Firebase;

using Firebase.Auth;

using Firebase.Database;
using Firebase.Extensions;
using System;

using System.Collections;

using System.Threading.Tasks;

using TMPro;

using UnityEngine;

using UnityEngine.UI;

namespace ZL.Unity.Server.Firebase.Auth
{
    [AddComponentMenu("ZL/Server/Firebase/Firebase Auth Manager (Singleton)")]

    [DisallowMultipleComponent]

    public sealed class FirebaseAuthManager : MonoBehaviour, IMonoSingleton<FirebaseAuthManager>
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

        private void Awake()
        {
            if (ISingleton<FirebaseAuthManager>.TrySetInstance(this) == false)
            {
                return;
            }

            FirebaseApp.

            CheckAndFixDependenciesAsync().

            ContinueWithOnMainThread(task =>
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

        private void OnDestroy()
        {
            ISingleton<FirebaseAuthManager>.Release(this);
        }

        public void SignIn(string id, string pw)
        {
            if (Auth == null)
            {
                return;
            }

            var task = Auth.SignInWithEmailAndPasswordAsync(id, pw);

            var routine = task.WaitForCompleted(task => User = task.Result.User);

            StartCoroutine(routine);
        }

        public void SignUp(string id, string pw)
        {
            if (Auth == null)
            {
                return;
            }

            var task = Auth.CreateUserWithEmailAndPasswordAsync(id, pw);

            StartCoroutine(task.WaitForCompleted((task) => User = task.Result.User));
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

    public static partial class TaskExtensions
    {
        public static IEnumerator WaitForCompleted<TTask>(this TTask instance, Action<TTask> callback = null)

            where TTask : Task
        {
            while (instance.IsCompleted == false)
            {
                yield return null;
            }

            callback?.Invoke(instance);
        }

        public static bool IsExceptionThrown(this Task instance, out FirebaseException exception)
        {
            return IsExceptionThrown(instance, out exception);
        }

        public static bool IsExceptionThrown(this Task instance, out Exception exception)
        {
            exception = instance.Exception;

            return exception != null;
        }
    }
}