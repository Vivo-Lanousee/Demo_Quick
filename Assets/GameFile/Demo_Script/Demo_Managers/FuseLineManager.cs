using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

/// <summary>
/// 導火線のマネージャー_Demo
/// ゲームのシーンのみなのでDontDestroyOnLoadにしない。
/// ゲーム時に新規に呼び出す様に。
/// </summary>
public class FuseLineManager : DestroyAvailable_MonoBehaviourBase<FuseLineManager>
{
    protected static FuseLineManager _fuseLineManager;
    private LineRenderer _lineRenderer;

    [SerializeField]
    private GameObject CharacterObject;
    private LinkedList<Transform> Transform= new LinkedList<Transform>();

    //
    private Material LineMaterial=null;
    private AsyncOperationHandle<Material> MaterialHandle;


    /// <summary>
    /// オブジェクトとラインレンダラーになるのかなぁ。。。
    /// </summary>
    Dictionary<Attach_Destructible_Object,LineRenderer> key=new Dictionary<Attach_Destructible_Object, LineRenderer> ();



    private async Task Awake()
    {
        await LineRendererProduct();
    }

    /// <summary>
    /// LineRendererを生成、設定する。
    /// </summary>
    private async UniTask LineRendererProduct()
    {
        _lineRenderer = gameObject.AddComponent<LineRenderer>();
        _lineRenderer.sortingOrder = 3;
        if(LineMaterial != null)
        {
            var Task = Addressables.LoadAssetAsync<Material>("LineMaterial");
            MaterialHandle = Task;
            await Task;
            _lineRenderer.material = Task.Result;
        }

        Debug.Log("読み込み成功");
    }

    /// <summary>
    /// 線を引く
    /// </summary>
    public void LineCreate()
    {
        
    }

    void OnDestroy() 
    {
        if (MaterialHandle.IsValid())
        {
            Addressables.Release(MaterialHandle);
        }
    }
}
