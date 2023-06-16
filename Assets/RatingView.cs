using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RatingView : MonoBehaviour
{
    [SerializeField]
    private RatingComponent _ratingComponent;
    [SerializeField]
    private TMP_InputField _inputField;
   
    public void OnClick()
    {
        _ratingComponent.AddRating(_inputField.text, GameManager.Instance.TimeLap.Timer);
    }

}
