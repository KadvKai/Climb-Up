using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InputController))]
public class Character : MonoBehaviour
{
    private List<PuckMover>  _puckMovers = new List<PuckMover>();
    public UnityEvent EndLevel = new UnityEvent();
    public UnityEvent GameOver = new UnityEvent();

    private void Awake()
    {
        _puckMovers = GetComponentsInChildren<PuckMover>().ToList();
        foreach (var puckMover in _puckMovers)
        {
            puckMover.Finish.AddListener(PuckMoverFinish);
        }
        var jointBreaks = GetComponentsInChildren<JointBreak>();
        foreach (var jointBreak in jointBreaks)
        {
            jointBreak.JointBreakEvent.AddListener(JointBreak);
        }
    }

    private void JointBreak()
    {
        GetComponent<InputController>().enabled = false;
        var camera = GetComponentInChildren<CinemachineVirtualCamera>();
        if (camera!=null) camera.enabled = false;
        GameOver.Invoke();
    }

    private void PuckMoverFinish(PuckMover puckMover)
    {
        _puckMovers.Remove(puckMover);
        if (_puckMovers.Count <= 0) EndLevel.Invoke();
    }
}
