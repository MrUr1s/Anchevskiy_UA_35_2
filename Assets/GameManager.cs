using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool IsRace => _isRace;

    public TimeLap TimeLap => _timeLap; 

    [SerializeField]
    private bool _isRace=false;
    [SerializeField]
    private TimeLap _timeLap;
    [SerializeField]
    private RatingView _ratingView;

    private void Awake()
    {
        Instance = this;
    }

    public void RaceStart()
    { 
        _isRace = true;
        _timeLap.StartTimer();
    }
    public void RaceFinish()
    {
        _timeLap.StopTimer();
        _ratingView.gameObject.SetActive(true);
        _isRace = false;
    }

}
