using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class HeadRotation : MonoBehaviour
{
    [SerializeField] PuckMover _puckL;
    [SerializeField] PuckMover _puckR;
    [SerializeField] MultiAimConstraint _multiAimConstraint;
    [SerializeField] float _spiedRotation=1f;

    private void Awake()
    {
        _multiAimConstraint.data.sourceObjects = new WeightedTransformArray { new WeightedTransform(_puckL.transform, 0), new WeightedTransform(_puckR.transform, 0) };
        _puckL.PuckSelected.AddListener(PuckLSelected);
        _puckR.PuckSelected.AddListener(PuckRSelected);
    }

    private void PuckLSelected(bool selected)
    {
        if (selected)
        {
            StartCoroutine(WeightChange(0, 1));
        }
        else
        {
            StartCoroutine(WeightChange(0, 0));
        }
    }
    private void PuckRSelected(bool selected)
    {
        if (selected)
        {
            StartCoroutine(WeightChange(1, 1));
        }
        else
        {
            StartCoroutine(WeightChange(1, 0));
        }
    }

    private IEnumerator WeightChange(int index,float weight)
    {
        var currentweight = _multiAimConstraint.data.sourceObjects[index].weight;
        if (currentweight< weight)
        {
            while (currentweight < weight)
            {
                currentweight += Time.deltaTime* _spiedRotation;
                var data = _multiAimConstraint.data.sourceObjects;
                data.SetWeight(index, currentweight);
                _multiAimConstraint.data.sourceObjects = data;
                yield return null;
            }
        }
        if (currentweight > weight)
        {
            while (currentweight > weight)
            {
                currentweight -= Time.deltaTime* _spiedRotation;
                var data = _multiAimConstraint.data.sourceObjects;
                data.SetWeight(index, currentweight);
                _multiAimConstraint.data.sourceObjects = data;
                yield return null;
            }
        }
    }
}
