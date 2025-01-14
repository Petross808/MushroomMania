using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    [SerializeField] private Transform _primaryParent;
    [SerializeField] private Transform _secondaryParent;

    [SerializeField] private Vector3 _primaryPosition;
    [SerializeField] private Vector3 _secondaryPosition;

    private Quaternion _primaryRotation;

    public void SetPrimary()
    {
        transform.parent = _primaryParent;
        transform.localPosition = _primaryPosition;
        transform.localRotation = _primaryRotation;
    }

    public void SetSecondary()
    {
        _primaryRotation = transform.localRotation;
        transform.parent = _secondaryParent;
        transform.localPosition = _secondaryPosition;
        transform.localRotation = Quaternion.identity;
    }
}
