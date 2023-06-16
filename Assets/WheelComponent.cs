using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelComponent : MonoBehaviour
{
    [SerializeField]
    private WheelCollider _frontLeftWheelCollider, _frontRightWheelCollider, _rearLeftWheelCollider, _rearRightWheelCollider;
    [SerializeField]
    private Transform _frontLeftWheelTransform, _frontRightWheelTransform, _rearLeftWheelTransform, _rearRightWheelTransform;


    public Transform[] GetFrontWheelTransofrm { get; private set; }
    public Transform[] GetRearWheelTransofrm { get; private set; }
    public WheelCollider[] GetFrontWheelCollider { get; private set; }
    public WheelCollider[] GetRearWheelCollider { get; private set; }

    private void Start()
    {
        GetFrontWheelCollider = new[] { _frontLeftWheelCollider, _frontRightWheelCollider };
        GetRearWheelCollider = new[] { _rearLeftWheelCollider, _rearRightWheelCollider };
        GetFrontWheelTransofrm = new[] { _frontLeftWheelTransform, _frontRightWheelTransform };
        GetRearWheelTransofrm = new[] { _rearLeftWheelTransform, _rearRightWheelTransform };
    }

    public void UpdateVisual(float angle)
    {
        for(var i=0; i< GetFrontWheelCollider.Length; i++)
        {
            GetFrontWheelCollider[i].steerAngle = angle;

            GetFrontWheelCollider[i].GetWorldPose(out var pos, out var rot);
            GetFrontWheelTransofrm[i].SetPositionAndRotation(pos, rot);

            GetRearWheelCollider[i].GetWorldPose(out pos, out  rot);
            GetRearWheelTransofrm[i].SetPositionAndRotation(pos, rot); 
        }


    }


}
