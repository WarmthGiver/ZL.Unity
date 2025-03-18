using Firebase;

using Firebase.Auth;

using Firebase.Database;

using Firebase.Extensions;

using System;

using System.Threading.Tasks;

using UnityEngine;

namespace ZL.Unity.Server.Firebase.Auth
{
    [AddComponentMenu("ZL/Server/Firebase/Firebase DB Manager (Singleton)")]

    [DisallowMultipleComponent]

    public sealed class FirebaseDBManager : MonoBehaviour, IMonoSingleton<FirebaseDBManager>
    {
        public DatabaseReference Database { get; private set; } = null;

        private FirebaseUser User;

        private void Awake()
        {
            if (ISingleton<FirebaseDBManager>.TrySetInstance(this) == false)
            {
                return;
            }

            FirebaseApp.

            CheckAndFixDependenciesAsync().

            ContinueWithOnMainThread(task =>
            {
                if (task.Result == DependencyStatus.Available)
                {
                    Database = FirebaseDatabase.DefaultInstance.RootReference;

                    Debug.Log("Firebase DB load Successful.");
                }

                else
                {
                    Debug.LogError($"Firebase DB load failed: {task.Result}");
                }
            });
        }

        private void Start()
        {
            User = ISingleton<FirebaseAuthManager>.Instance.User;
        }

        private void OnDestroy()
        {
            ISingleton<FirebaseDBManager>.Release(this);
        }

        public void SetValue(object value, params string[] paths)
        {
            var database = Database.Child(paths);

            var task = database.SetValueAsync(value);

            var routine = task.WaitForCompleted();

            StartCoroutine(routine);
        }

        public void GetValue(Action<Task<DataSnapshot>> callback, params string[] paths)
        {
            var database = Database.Child(paths);

            var task = database.GetValueAsync();

            var routine = task.WaitForCompleted(callback);

            StartCoroutine(routine);
        }
    }

    public static class DatabaseReferenceExtensions
    {
        public static DatabaseReference Child(this DatabaseReference instance, string[] paths)
        {
            foreach (var path in paths)
            {
                instance = instance.Child(path);
            }

            return instance;
        }
    }
}