using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    private PlayerInput _playerInput;
    private PuckMover _puckMover;
    private void Awake()
    {
        Debug.Log(mask);
        _playerInput = new PlayerInput();
        _playerInput.Character.Selection.started += ctx => Selection_started();
        _playerInput.Character.Selection.canceled += ctx => Selection_canceled();
    }


    private void OnEnable()
    {
        _playerInput.Enable();
    }
    private void OnDisable()
    {
        _playerInput.Disable();
    }
    private void Selection_started()
    {
        _playerInput.Character.Position.performed += Position_performed;
        var ray = Camera.main.ScreenPointToRay(_playerInput.Character.Position.ReadValue<Vector2>());
        if (Physics.Raycast(ray, out var hit, 100))
        {
            _puckMover = hit.collider.GetComponent<PuckMover>();
            if (_puckMover != null) _puckMover.SetStateMove(true);
        }
    }
    private void Selection_canceled()
    {
        _playerInput.Character.Position.performed -= Position_performed;
        if (_puckMover != null)
        {
            _puckMover.SetStateMove(false);
        _puckMover = null;
        }
    }
    private void Position_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (_puckMover != null)
        {
            var ray = Camera.main.ScreenPointToRay(context.ReadValue<Vector2>());
            if (Physics.Raycast(ray, out var hit, 100, mask))
            {
                //Debug.Log("Hit="+hit.point);
                _puckMover.SetMovePosition(hit.point);
            }
        }
    }
}
