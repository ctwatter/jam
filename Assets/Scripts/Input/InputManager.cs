using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class InputManager : MonoBehaviour
{

    private TouchControls touchControls;

    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;


    public Vector2 currTouchPosition;

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    private void Start()
    {
        touchControls.Touch.TouchPosition.performed += ctx => updatePosition(ctx);
        touchControls.Touch.TouchPress.started += ctx => touchStart(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => touchEnd(ctx);
    }

    private void updatePosition(InputAction.CallbackContext context)
    {
        currTouchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        //Debug.Log(currTouchPosition);
    }

    private void touchStart(InputAction.CallbackContext context)
    {
        if(OnStartTouch != null)
        {
            Debug.Log("Touch Started");
            OnStartTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
        }
    }

    private void touchEnd(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null)
        {
            OnEndTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
        }
    }
}
