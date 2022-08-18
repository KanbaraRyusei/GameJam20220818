using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisplayScore : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public Animator _targetAnim;

    /// <summary>
    /// �X�R�A�\��(PanelSlide)
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        var go = eventData.pointerCurrentRaycast.gameObject;
        var panel = go.GetComponent<DisplayScore>();

        Debug.Log("�X�R�A�\��");
        panel.ScoreDisplay();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreDisplay()
    {
        _targetAnim.SetBool("Move", true);
    }
}
