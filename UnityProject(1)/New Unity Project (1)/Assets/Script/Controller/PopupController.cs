using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public static void PopupOnOff()
    {
        if (Inventory.On_Off == Constant.PopupState.Closed)
        {
            Inventory.On_Off = Constant.PopupState.On;
            Managers.UI.ShowPopup<Inventory>("Inventory");
        }
        else
        {
            Managers.UI.ClosePopup();
            Inventory.On_Off = Constant.PopupState.Closed;
        }
    }
}
