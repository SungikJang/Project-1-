using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 5.0f;
    private Vector3 _destination;
    private float Run_Wait_Ratio = 0.0f;
    private Constant.State CharecterState = Constant.State.Idle;
    private void Move()
    {
        Vector3 MoveVector = _destination - transform.position;
        Debug.DrawRay(Camera.main.transform.position, _destination, Color.red, 1.0f);
        if (MoveVector.magnitude < 0.00001f)
        {
            CharecterState = Constant.State.Idle;
            return;
        }
        if (MoveVector.magnitude < (MoveVector.normalized * _speed * Time.deltaTime).magnitude)
        {
            transform.position += MoveVector;
        }
        else
        {
            transform.position += MoveVector.normalized * _speed * Time.deltaTime;

        }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(MoveVector), 0.4f);

        Animator Movement = GetComponent<Animator>();
        //Movement.SetFloat("Run_Wait_Ratio", 1.0f);
        Run_Wait_Ratio = Mathf.Lerp(Run_Wait_Ratio, 1.0f, 0.2f);
        Movement.SetFloat("Run_Wait_Ratio", Run_Wait_Ratio);
        Movement.Play("Run_Wait");
    }
    private void Die() { }
    private void Idle()
    {
        Animator Movement = GetComponent<Animator>();
        //Movement.SetFloat("Run_Wait_Ratio", 0.0f);
        Run_Wait_Ratio = Mathf.Lerp(Run_Wait_Ratio, 0.0f, 0.2f);
        Movement.SetFloat("Run_Wait_Ratio", Run_Wait_Ratio);
        Movement.Play("Run_Wait");
    }
    private void Jump()
    {
        if(CharecterState == Constant.State.Idle)
        {

        }
        if (CharecterState == Constant.State.Move)
        {

        }
    }
    private void OnMouseClick(Constant.MouseEvent evt)
    {
        //Vector3 point_3d = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

        // Vector3 DirVtr = point_3d - transform.position;
        //DirVtr = DirVtr.normalized;
        if (CharecterState == Constant.State.Die) { return; }
        RaycastHit onHit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log(Physics.Raycast(ray, out onHit, 200, LayerMask.GetMask("Land")));
        //Debug.DrawRay(Camera.main.transform.position, ray.direction*500.0f, Color.red, 1.0f);
        if (Physics.Raycast(ray, out onHit, 200, LayerMask.GetMask("Land")) == true)
        {
            _destination = onHit.point;
            CharecterState = Constant.State.Move;
        }
    }
    private void KeyBoard_Action(Constant.KeyBoardEvent evt)
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            PopupController.PopupOnOff();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Managers.Input.MouseAction -= OnMouseClick;
        Managers.Input.MouseAction += OnMouseClick;
        Managers.Input.KeyBoardAction -= KeyBoard_Action;
        Managers.Input.KeyBoardAction += KeyBoard_Action;
        Managers.UI.ShowScene<ButtonClick>("UIClicker");
        //Managers.UI.ShowPopup<Inventory>("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        switch (CharecterState)
        {
            case Constant.State.Die:
                Die();
                break;
            case Constant.State.Move:
                Move();
                break;
            case Constant.State.Idle:
                Idle();
                break;
        }
    }
}
