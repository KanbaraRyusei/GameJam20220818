using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeekBarController : MonoBehaviour
{
    [SerializeField]
    [Header("シークバー")]
    Slider _slider;

    private void Update()
    {
        _slider.value = TimeManager.Instance.SeekBarValue;
    }
}
