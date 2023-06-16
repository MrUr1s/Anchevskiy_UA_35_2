using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputComponent : BaseInputComponent
{

    private PlayerControler _controler;

    private void OnEnable()
    {
        _controler.Player.Enable();
    }


    private void OnDisable()
    {
        _controler.Player.Disable();
    }
    private void OnDestroy()
    {
        _controler.Dispose();
    }
    protected override void FixedUpdate()
    {
        Acceleration=_controler.Player.Acceleration.ReadValue<float>();
        var dir= _controler.Player.Rotate.ReadValue<float>();

        CallHandBrake(_controler.Player.HandBrake.IsPressed());
        if (dir==0f)
        {
            Rotate = Rotate > 0f
                ? - Time.fixedDeltaTime
                : + Time.fixedDeltaTime;
        }
        else
        {
            Rotate = Mathf.Clamp(Rotate+dir*Time.fixedTime, -1f, 1f);
        }
    }

    protected void Awake()
    {
        _controler = new PlayerControler();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Finish")
            GameManager.Instance.RaceFinish();

    }
}
