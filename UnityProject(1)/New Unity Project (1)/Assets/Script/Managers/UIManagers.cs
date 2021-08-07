using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagers : MonoBehaviour
{
    Stack<UI_base> PopupStack = new Stack<UI_base>();
    Stack<UI_base> SceneStack = new Stack<UI_base>();
    public void ShowPopup<T>(string name) where T : UI_base
    {
        GameObject go = Managers.Resource.Instantiate($"Prefabs/Popup/{name}");
        T P = Utils.GetOrAddComponent<T>(go);
        PopupStack.Push(P);
    }
    public void ShowScene<T>(string name) where T : UI_base
    {
        GameObject go = Managers.Resource.Instantiate($"Prefabs/Scene/{name}");
        T P = Utils.GetOrAddComponent<T>(go);
        SceneStack.Push(P);
    }
    public void ClosePopup()
    {
        UI_base P = PopupStack.Pop();
        Managers.Resource.Destory(P.gameObject, 0.0f);
    }
}
