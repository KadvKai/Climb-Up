using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckMover : MonoBehaviour
{
    private Vector3 _position;
    private bool _state;
    private Rigidbody _rigidbody;
    private Transform _startTransform;

    private void Awake()
    {
        _rigidbody=GetComponent<Rigidbody>();

    }



    private void FixedUpdate()
    {
        if (_state)
        {
            _rigidbody.MovePosition(new Vector3(_position.x, _position.y,_rigidbody.position.z));
            //Debug.Log("_position="+ _position+ "  _rigidbody="+ _rigidbody.transform.position);
            //_rigidbody.position = _position;
        }
        
    }

    public void SetStateMove(bool state)
    {
        _state = state;
        if (_state)
        {
            _position = _rigidbody.position;
        }
        _rigidbody.useGravity = !_state;
    }

    public void SetMovePosition(Vector3 position)
    {
        _position = position;
    }
    
}
