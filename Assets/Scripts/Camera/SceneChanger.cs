using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    #region �����o
    /// <summary>�V���O���g�������邽�߂̗B��C���X�^���X�ւ̃A�N�Z�b�T</summary>
    static SceneChanger _instance = null;

    [SerializeField, Tooltip("�V�[���J�ڂ܂łɂ�����x������")]
    float _SceneChangeDelay = 1f;

    [SerializeField, Tooltip("�ʂ̃V�[���ɔ�Ԏ��ɂ�����Ó]���\�b�h")]
    UnityEvent FadeIn = null;

    [SerializeField, Tooltip("�ʂ̃V�[��������ł������ɂ�����Ó]���A���\�b�h")]
    UnityEvent FadeOut = null;
    #endregion

    #region �v���p�e�B
    /// <summary>�V���O���g�������邽�߂̗B��C���X�^���X�ւ̃A�N�Z�b�T</summary>
    public static SceneChanger Instance 
    {
        get
        {
            //�Ώۂ̃V���O���g���R���|�[�l���g���o�^����ĂȂ���΁A���݂̃V�[������E���Ă���
            if (!_instance)
            {
                _instance = (SceneChanger)FindObjectOfType(typeof(SceneChanger));
                if (!_instance) Debug.LogError("�V���O���g���R���|�[�l���g�� " + typeof(SceneChanger) + " ���A���݂̃V�[���ɑ��݂��܂���I");
            }
            return _instance;
        }
    }

    #endregion

    void Awake()
    {
        //�o�^����Ă���V���O���g���R���|�[�l���g�������̃C���X�^���X�Ɠ����Ȃ�ADontDestroyOnLoad�ɓo�^����
        //�قȂ�΁A������j������
        if (this != Instance) Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this.gameObject);
            SceneManager.activeSceneChanged += ComeFromOtherScene;
        }
    }

    void OnDestroy()
    {
        //���̃C���X�^���X��static���珜��
        _instance = null;
    }

    /// <summary>�ʂ̃V�[���ֈڍs���鎞�Ɏ��{���郁�\�b�h</summary>
    /// <param name="sceneName">�ڍs��V�[����</param>
    public void GoToOtherScene(string sceneName)
    {
        StartCoroutine(DelaySceneChange(sceneName));
    }

    /// <summary>�V�[���J�ڂɒx���������Ď��s����R���[�`��</summary>
    /// <param name="sceneName">�J�ڐ�V�[����</param>
    IEnumerator DelaySceneChange(string sceneName)
    {
        FadeIn?.Invoke();
        yield return new WaitForSeconds(_SceneChangeDelay);
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>�ʂ̃V�[������ڍs���Ă������Ɏ��{���郁�\�b�h</summary>
    /// <param name="current">�ڍs���V�[��</param>
    /// <param name="next">�ڍs��V�[��</param>
    void ComeFromOtherScene(Scene current, Scene next)
    {
        FadeOut?.Invoke();
    }
}
