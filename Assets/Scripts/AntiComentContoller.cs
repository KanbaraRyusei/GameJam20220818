using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiComentContoller : MonoBehaviour
{
    //コメント速度
    [SerializeField] float _SpeedX = 15f;
    Vector3 ComentPozzision ;
    float _timer;
    [SerializeField] int _score;

    // Start is called before the first frame update
    void Start()
    {
        ComentPozzision = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _timer += Time.deltaTime;
        float posX = _SpeedX * -_timer;
        float posY = 0;
        Vector3 pos = ComentPozzision + new Vector3(posX, posY, 0);
        transform.position = pos;   // 座標を直接代入することで移動させる
    }


    public void OnClick()
    {
        Destroy(gameObject);
    }
}
