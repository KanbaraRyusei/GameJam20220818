using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiComentContoller : MonoBehaviour
{
    //ÉRÉÅÉìÉgë¨ìx
    [SerializeField] float _move = 15f;
    //
    Vector2 _ComentPozission;

    // Start is called before the first frame update
    void Start()
    {
        _ComentPozission = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _ComentPozission = transform.position;
        _ComentPozission.x = _ComentPozission.x + 0.03f;
    }

}
