using System;
using System.Threading.Tasks;
using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using UnityEngine;

namespace CodeBase.Infrastructure.Firebase
{
    public class FirebaseInitializer : MonoBehaviour
    {
        private void Awake()
        {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(OnDependencyStatusReceived);
        }

        private void OnDependencyStatusReceived(Task<DependencyStatus> task)
        {
            try
            {
                if (!task.IsCompletedSuccessfully)
                    throw new Exception("Could not resolve all Firebase dependencies", task.Exception);
            
                var status = task.Result;
                if(status != DependencyStatus.Available)
                    throw new Exception($"Could not resolve all Firebase dependencies: {status}");
                
                
                print("Firebase initialized successfully");
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private void Start()
        {
            LogTestEvent();
        }

        public void LogTestEvent()
        {
            if (FirebaseApp.DefaultInstance != null)
            {
                FirebaseAnalytics.LogEvent("test_event", new Parameter("level", 1));
                Debug.Log("Test event sent successfully");
            }
            else
            {
                Debug.LogError("Firebase not initialized yet");
            }
        }
    }
}

