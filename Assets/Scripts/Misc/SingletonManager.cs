using UnityEngine;

public static class SingletonManager
{
    public static void ManageSingleton(MonoBehaviour script)
    {
        int instanceCount = Object.FindObjectsOfType(script.GetType()).Length;

        if (instanceCount > 1)
        {
            script.gameObject.SetActive(false);
            Object.Destroy(script.gameObject);
        }
        else
        {
            Object.DontDestroyOnLoad(script.gameObject);
        }
    }
}
