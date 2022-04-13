using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuckMover : MonoBehaviour
{
    [SerializeField] Rigidbody _masterRigidbody;
    private Vector3 _position;
    private bool _state;
    private Rigidbody _rigidbody;
    public UnityEvent<bool> PuckSelected = new UnityEvent<bool>();
    public UnityEvent<PuckMover> Finish = new UnityEvent<PuckMover>();
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_state)
        {
            _masterRigidbody.MovePosition(new Vector3(_position.x, _position.y, _masterRigidbody.position.z));
        }
    }

    public void SetStateMove(bool state)
    {
        _state = state;
        _masterRigidbody.position = _rigidbody.position;
        if (_state)
        {
            _position = _masterRigidbody.position;
        }
        _masterRigidbody.isKinematic = _state;
        PuckSelected.Invoke(_state);
    }

    public void SetMovePosition(Vector3 position)
    {
        _position = position;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Finish>()!=null)
        {
            Debug.Log("Finish");
            Finish.Invoke(this);
        }
    }
}
