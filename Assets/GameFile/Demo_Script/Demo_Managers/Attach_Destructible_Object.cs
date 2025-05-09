using UniRx;
using UniRx.Triggers;
using UnityEngine;
using System;

/// <summary>
/// 爆破可能オブジェクトにアタッチする
/// </summary>
public class Attach_Destructible_Object : MonoBehaviour
{
    IDisposable Enter;
    IDisposable Exit;


    private void Awake()
    {
        Test();
    }
    /// <summary>
    /// こちら側に判定を作るバージョン
    /// </summary>
    public void Test()
    {
        Enter=this.OnTriggerEnter2DAsObservable()
            .Where(_ => _.gameObject?.GetComponent<Attach_Character>() != null)
            .Subscribe(_ => 
            {
                Debug.Log("入った");
            }).AddTo(this);
        Exit=this.OnTriggerExit2DAsObservable()
            .Where(_=> _.gameObject?.GetComponent<Attach_Character>() != null)
            .Subscribe(_ =>
            {
                Debug.Log("出た");
            }).AddTo(this);
    }

    void Dispose()
    {
        Enter?.Dispose();
        Exit?.Dispose();
    }

    private void OnDestroy()
    {
        Dispose();
    }
}
