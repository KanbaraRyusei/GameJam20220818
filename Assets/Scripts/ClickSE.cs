using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSE : MonoBehaviour
{

    [SerializeField] AudioClip _se;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SoundManager.Instance.PlaySE(_se);
        }
    }
}
