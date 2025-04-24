using Firebase;

using Firebase.Auth;

using Firebase.Database;

using Firebase.Extensions;

using System;

using System.Threading.Tasks;

using UnityEngine;

using ZL.CS.Singleton;

using ZL.CS.Threading;

using ZL.Unity.Singleton;

namespace ZL.Unity.Server.Firebase.Auth
{
    [AddComponentMenu("ZL/Server/Firebase/Firebase DB Manager (Singleton)")]

    public sealed class FirebaseDBManager : MonoSingleton<FirebaseDBManager>
    {
        public DatabaseReference Database { get; private set; } = null;

        private FirebaseUser User;

        protected override void Awake()
        {
            base.Awake();

            FirebaseApp.
                
                CheckAndFixDependenciesAsync().
                
                ContinueWithOnMainThread((task) =>
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

            User = ISingleton<FirebaseAuthManager>.Instance.User;
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
}