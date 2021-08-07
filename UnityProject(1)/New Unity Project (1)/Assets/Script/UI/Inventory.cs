using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : UI_base
{
    public static Constant.PopupState On_Off = Constant.PopupState.Closed;
    enum ObjectNames
    {
        Grid,
    }
    enum ButtonNames
    {
        CloseButton,
    }
    public void CloseButtonClick(PointerEventData evt)
    {
        Managers.UI.ClosePopup();
        On_Off = Constant.PopupState.Closed;
    }
    void Start()
    {
        Debug.Log("dsadasf");
        Bind<GameObject>(typeof(ObjectNames));
        Bind<Button>(typeof(ButtonNames));
        AddUIEvent(Get<Button>(0).gameObject, Constant.UIEvent.Click, CloseButtonClick);
        GameObject G = Get<GameObject>((int)ObjectNames.Grid);
        foreach (Transform Child in G.transform)
        {
            Managers.Resource.Destory(Child.gameObject);
        }
        for (int i = 0; i < 9; i++)
        {
            GameObject I = Managers.Resource.Instantiate("Prefabs/Popup/Item");
            I.transform.SetParent(G.transform);
        }
    }

}