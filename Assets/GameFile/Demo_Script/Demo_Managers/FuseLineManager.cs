using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

/// <summary>
/// ���ΐ��̃}�l�[�W���[_Demo
/// �Q�[���̃V�[���݂̂Ȃ̂�DontDestroyOnLoad�ɂ��Ȃ��B
/// �Q�[�����ɐV�K�ɌĂяo���l�ɁB
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
    /// �I�u�W�F�N�g�ƃ��C�������_���[�ɂȂ�̂��Ȃ��B�B�B
    /// </summary>
    Dictionary<Attach_Destructible_Object,LineRenderer> key=new Dictionary<Attach_Destructible_Object, LineRenderer> ();



    private async Task Awake()
    {
        await LineRendererProduct();
    }

    /// <summary>
    /// LineRenderer�𐶐��A�ݒ肷��B
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

        Debug.Log("�ǂݍ��ݐ���");
    }

    /// <summary>
    /// ��������
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
