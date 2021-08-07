using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant
{
    public enum MouseEvent
    {
        Clicked,
        Pressed
    }
    public enum KeyBoardEvent
    {
        Clicked,
        Pressed,
        none
    }
    public enum State
    {
        Die,
        Move,
        Idle,
    }
    public enum PopupState
    {
        On,
        Closed,
    }
    public enum UIEvent
    {
        Click,
        Drag,
    }
}
