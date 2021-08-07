using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagers : MonoBehaviour
{
    public Action<Constant.MouseEvent> MouseAction = null;
    private bool MousePressed = false;
    public Action<Constant.KeyBoardEvent> KeyBoardAction = null;
    private bool KeyBorad_Any_Pressed = false;
    // Start is called before the first frame update
    public void OnUpdate()
    {
        if (MouseAction != null)
        {
            if (KeyBoardAction != null)
            {
                if (Input.anyKeyDown)
                {
                    KeyBorad_Any_Pressed = true;
                    KeyBoardAction.Invoke(Constant.KeyBoardEvent.Pressed);
                }
                else
                {
                    KeyBorad_Any_Pressed = false;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                MousePressed = true;
                MouseAction.Invoke(Constant.MouseEvent.Pressed);
            }
            else
            {
                MousePressed = false;
            }
        }
    }

}
