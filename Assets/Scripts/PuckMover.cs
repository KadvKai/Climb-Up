using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PuckMover : MonoBehaviour
{
    [SerializeField] Rigidbody _masterRigidbody;
    [SerializeField] float _offsetY;
    [SerializeField] float _speed;
    [SerializeField] float _time;
    private Vector3 _position;
    private bool _state;
    private Rigidbody _rigidbody;
    private CapsuleCollider _capsuleCollider;
    private float _capsuleColliderRadius;
    public UnityEvent<bool> PuckSelected = new UnityEvent<bool>();
    public UnityEvent<PuckMover> Finish = new UnityEvent<PuckMover>();
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _capsuleColliderRadius = _capsuleCollider.radius;
        _capsuleCollider.radius = _capsuleColliderRadius * 5;
        _capsuleCollider.isTrigger = true;
    }

    private void FixedUpdate()
    {
        if (_state)
        {
            var moveDirection = new Vector3(_position.x,_position.y,0)  - new Vector3(_masterRigidbody.position.x, _masterRigidbody.position.y,0);
            if (moveDirection.magnitude>Time.fixedDeltaTime*_speed)
            {
                _masterRigidbody.MovePosition(_masterRigidbody.transform.position + _speed * Time.fixedDeltaTime * moveDirection.normalized);
            }
        }
    }

    public void SetStateMove(bool state)
    {
        _state = state;
        _masterRigidbody.position = _rigidbody.position;
        if (_state)
        {
            _rigidbody.isKinematic = false;
            _position = _masterRigidbody.position;
            _capsuleCollider.radius = _capsuleColliderRadius;
            _capsuleCollider.isTrigger = false;
        }
        else
        {
            StartCoroutine(SetKinematic());
        }
        _masterRigidbody.isKinematic = _state;
        PuckSelected.Invoke(_state);
    }

    public void SetMovePosition(Vector3 position)
    {
        _position =new Vector3(position.x,position.y+_offsetY) ;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Finish>()!=null)
        {
            Finish.Invoke(this);
        }
    }

    private IEnumerator SetKinematic()
    {
        var time = _time;
        while (_rigidbody.velocity.magnitude>0.01f || time>0)
        {
            if (_rigidbody.velocity.magnitude > 0.01f) time = _time;
            else time -= Time.deltaTime;
        yield return null;

        }
        _rigidbody.isKinematic = true;
            _capsuleCollider.radius = _capsuleColliderRadius*5;
        _capsuleCollider.isTrigger = true;
    }
}
