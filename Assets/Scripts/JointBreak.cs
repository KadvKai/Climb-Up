using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JointBreak : MonoBehaviour
{
    public UnityEvent JointBreakEvent = new UnityEvent();

    private void OnJointBreak(float breakForce)
    {
        JointBreakEvent.Invoke();
    }
}
