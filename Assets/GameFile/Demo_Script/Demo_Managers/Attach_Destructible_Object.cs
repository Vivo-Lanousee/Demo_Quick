using UniRx;
using UniRx.Triggers;
using UnityEngine;
using System;

/// <summary>
/// ���j�\�I�u�W�F�N�g�ɃA�^�b�`����
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
    /// �����瑤�ɔ�������o�[�W����
    /// </summary>
    public void Test()
    {
        Enter=this.OnTriggerEnter2DAsObservable()
            .Where(_ => _.gameObject?.GetComponent<Attach_Character>() != null)
            .Subscribe(_ => 
            {
                Debug.Log("������");
            }).AddTo(this);
        Exit=this.OnTriggerExit2DAsObservable()
            .Where(_=> _.gameObject?.GetComponent<Attach_Character>() != null)
            .Subscribe(_ =>
            {
                Debug.Log("�o��");
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
