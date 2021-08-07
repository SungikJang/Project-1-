using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManagers
{
    public T Load<T>(string path) where T : UnityEngine.Object
    {
        return Resources.Load<T>(path);
    }
    public GameObject Instantiate(string path)
    {
        GameObject go = Load<GameObject>(path);
        if (go == null)
        {
            Debug.Log("Fucked up");
            return null;
        }
        return Object.Instantiate(go);
    }
    public void Destory(Object obj, float t = 0.0f)
    {
        Object.Destroy(obj);
    }
}

