using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    #region メンバ
    /// <summary>シングルトン化するための唯一インスタンスへのアクセッサ</summary>
    static SceneChanger _instance = null;

    [SerializeField, Tooltip("シーン遷移までにかける遅延時間")]
    float _SceneChangeDelay = 1f;

    [SerializeField, Tooltip("別のシーンに飛ぶ時にかける暗転メソッド")]
    UnityEvent FadeIn = null;

    [SerializeField, Tooltip("別のシーンから飛んできた時にかける暗転復帰メソッド")]
    UnityEvent FadeOut = null;
    #endregion

    #region プロパティ
    /// <summary>シングルトン化するための唯一インスタンスへのアクセッサ</summary>
    public static SceneChanger Instance 
    {
        get
        {
            //対象のシングルトンコンポーネントが登録されてなければ、現在のシーンから拾ってくる
            if (!_instance)
            {
                _instance = (SceneChanger)FindObjectOfType(typeof(SceneChanger));
                if (!_instance) Debug.LogError("シングルトンコンポーネントの " + typeof(SceneChanger) + " が、現在のシーンに存在しません！");
            }
            return _instance;
        }
    }

    #endregion

    void Awake()
    {
        //登録されているシングルトンコンポーネントが自分のインスタンスと同じなら、DontDestroyOnLoadに登録する
        //異なれば、自分を破棄する
        if (this != Instance) Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this.gameObject);
            SceneManager.activeSceneChanged += ComeFromOtherScene;
        }
    }

    void OnDestroy()
    {
        //このインスタンスをstaticから除去
        _instance = null;
    }

    /// <summary>別のシーンへ移行する時に実施するメソッド</summary>
    /// <param name="sceneName">移行先シーン名</param>
    public void GoToOtherScene(string sceneName)
    {
        StartCoroutine(DelaySceneChange(sceneName));
    }

    /// <summary>シーン遷移に遅延をかけて実行するコルーチン</summary>
    /// <param name="sceneName">遷移先シーン名</param>
    IEnumerator DelaySceneChange(string sceneName)
    {
        FadeIn?.Invoke();
        yield return new WaitForSeconds(_SceneChangeDelay);
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>別のシーンから移行してきた時に実施するメソッド</summary>
    /// <param name="current">移行元シーン</param>
    /// <param name="next">移行先シーン</param>
    void ComeFromOtherScene(Scene current, Scene next)
    {
        FadeOut?.Invoke();
    }
}
