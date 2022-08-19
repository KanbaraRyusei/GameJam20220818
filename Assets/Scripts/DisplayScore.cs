using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisplayScore : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public Animator _targetAnim;
    [SerializeField] AudioClip _audio;

    /// <summary>
    /// スコア表示(PanelSlide)
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        var go = eventData.pointerCurrentRaycast.gameObject;
        var panel = go.GetComponent<DisplayScore>();

        panel.ScoreDisplay();
    }

    void Awake()
    {
        SoundManager.Instance.PlayBGM(_audio);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _targetAnim.SetBool("Move", true);
        }
    }

    public void ScoreDisplay()
    {
        _targetAnim.SetBool("Move", true);
        Debug.Log("高評価、低評価数を表示します");
    }
}
