using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static T FindChild<T>(GameObject go, string name, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
        {
            return null;
        }
        T[] components = go.GetComponentsInChildren<T>();//¹è¿­
        for (int i = 0; i < components.Length; i++)
        {
            if (components[i].name == name)
            {
                return components[i];
            }
        }
        return null;
    }
    public static GameObject FindChild(GameObject go, string name, bool recursive = false)
    {
        Transform F = FindChild<Transform>(go, name, recursive);
        return F.gameObject;
    }
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T C = go.GetComponent<T>();
        if (C == null)
        {
            C = go.AddComponent<T>();
        }
        return C;
    }
}

