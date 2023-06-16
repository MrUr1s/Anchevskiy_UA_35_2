using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WheelComponent), typeof(BaseInputComponent), typeof(Rigidbody))]
public class CarComponent : MonoBehaviour
{
    private WheelComponent _wheelComponent;
    private BaseInputComponent _inputComponent;
    private Rigidbody _rb;

    [SerializeField]
    private WD _wd;
    [SerializeField]
    private float _maxSteerAngle=30f,_torgue=3000f,_handBrakeTorgue=float.MaxValue;
    [SerializeField]
    private Vector3 _centerOfMass;

    private void Awake()
    {
        _wheelComponent = GetComponent<WheelComponent>();
        _inputComponent = GetComponent<BaseInputComponent>();
        _rb = GetComponent<Rigidbody>();

        _rb.centerOfMass = _centerOfMass;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawSphere(transform.TransformPoint(_centerOfMass), 0.5f);
    }
    private void _inputComponent_OnHandBrakeEvent(bool value)
    {
        for (var i = 0; i < _wheelComponent.GetRearWheelCollider.Length; i++)
            if (value)
            {
                _wheelComponent.GetRearWheelCollider[i].brakeTorque = _handBrakeTorgue;
            }
            else
            {
                _wheelComponent.GetRearWheelCollider[i].brakeTorque = 0;
            }
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.IsRace)
        {
            _wheelComponent.UpdateVisual(_inputComponent.Rotate * _maxSteerAngle);
            MotorTorgue();
        }
    }

    private void OnDisable()
    {
        _inputComponent.OnHandBrakeEvent -= _inputComponent_OnHandBrakeEvent;
    }
    private void OnEnable()
    {
        _inputComponent.OnHandBrakeEvent += _inputComponent_OnHandBrakeEvent;
    }
    private void MotorTorgue()
    {
        float torgue = 0;
        if (_wd == WD.awd)
        {
            torgue = _inputComponent.Acceleration * _torgue / 4f;

            for (int i = 0; i < _wheelComponent.GetRearWheelCollider.Length; i++)
            {
                _wheelComponent.GetRearWheelCollider[i].motorTorque = torgue;
                _wheelComponent.GetFrontWheelCollider[i].motorTorque = torgue;
            }
        }
        else
        {
            torgue = _inputComponent.Acceleration * _torgue / 2f;
            if (_wd == WD.rwd)
            {
                for (int i = 0; i < _wheelComponent.GetRearWheelCollider.Length; i++)
                    _wheelComponent.GetRearWheelCollider[i].motorTorque = torgue;

            }
            else
            {
                for (int i = 0; i < _wheelComponent.GetFrontWheelCollider.Length; i++)
                    _wheelComponent.GetFrontWheelCollider[i].motorTorque = torgue;
            }

        }
    }


}

public enum WD { rwd,awd,fwd}
