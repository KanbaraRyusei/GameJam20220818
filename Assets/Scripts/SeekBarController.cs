using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeekBarController : MonoBehaviour
{
    [SerializeField]
    [Header("�V�[�N�o�[")]
    Slider _slider;

    private void Update()
    {
        _slider.value = TimeManager.Instance.SeekBarValue;
    }
}
