using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField]
    private TimeLap _timeLap;
    [SerializeField]
    private Countdown _countdown;

    private void Awake()
    {
        Instance = this;
    }
}
