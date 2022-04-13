using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class HeadRotation : MonoBehaviour
{
    [SerializeField] PuckMover _puckL;
    [SerializeField] PuckMover _puckR;
    [SerializeField] MultiAimConstraint _multiAimConstraint;

    private void Awake()
    {
        _multiAimConstraint.data.sourceObjects = new WeightedTransformArray { new WeightedTransform(_puckL.transform, 0), new WeightedTransform(_puckR.transform, 0) };
        _puckL.PuckSelected.AddListener(PuckLSelected);
        _puckR.PuckSelected.AddListener(PuckRSelected);
    }
    private void Start()
    {
        //Debug.Log(_multiAimConstraint.data.sourceObjects[0].weight);
        //_multiAimConstraint.data.sourceObjects.Add(_puckL.transform);
        //_multiAimConstraint.data.sourceObjects.Add(new WeightedTransform(_puckR.transform, 0));
    }

    private void PuckLSelected(bool selected)
    {
        if (selected)
        {
            var data =_multiAimConstraint.data.sourceObjects;
            data .SetWeight(0,1);
            _multiAimConstraint.data.sourceObjects = data ;
        }
        else
        {
            var data = _multiAimConstraint.data.sourceObjects;
            data.SetWeight(0, 0);
            _multiAimConstraint.data.sourceObjects = data;
        }
    }
    private void PuckRSelected(bool selected)
    {
        if (selected)
        {
            var data = _multiAimConstraint.data.sourceObjects;
            data.SetWeight(1, 1);
            _multiAimConstraint.data.sourceObjects = data;
        }
        else
        {
            var data = _multiAimConstraint.data.sourceObjects;
            data.SetWeight(1, 0);
            _multiAimConstraint.data.sourceObjects = data;
        }
    }
}
