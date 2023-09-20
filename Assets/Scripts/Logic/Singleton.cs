using System;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError($"Exists more than 1 instance of {typeof(T).Name} class!");

            throw new Exception();
        }

        Instance = this as T;
    }
}