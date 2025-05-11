using UnityEngine;
using UniRx;
using System;



/// <summary>
/// 実際に動かす用
/// </summary>
public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private GameObject Chara;
    private Rigidbody2D rb;

    IDisposable _Move;
    IDisposable _Concent;
    IDisposable _SelectSwitch_Previous;
    IDisposable _SelectSwitch_Next;


    private ActionMapManager actionMapManager;
    private ActionMapAssets actionMap;

    private readonly RaycastHit[] _raycastHits = new RaycastHit[1];

    [SerializeField]
    private float Speed = 2.0f;



    private void Awake()
    {
        FuseLineManager.Instance();


        actionMapManager = ActionMapManager.Instance();
        actionMap = actionMapManager.GetControllersConnect();

        CharacterMove();
    }
    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {

    }

    /// <summary>
    /// 移動処理
    /// </summary>
    public void CharacterMove()
    {
        actionMapManager.PlayerEnable();

        rb = Chara?.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        
        _Move = Observable.EveryUpdate()
            .Subscribe(_ => {
                Vector2 vector = actionMap.Player.Move.ReadValue<Vector2>();
                rb.linearVelocity = new Vector3(vector.x*Speed,vector.y*Speed,0);
                             }).AddTo(Chara);
    }




    /// <summary>
    /// コンセントを伸ばす。
    /// </summary>
    public void CharacterConcentConnect_Event()
    {
        _Concent = Observable.EveryUpdate()
                    .Where(_=>actionMap.Player.Attack.WasPressedThisFrame())
                    .Throttle(TimeSpan.FromSeconds(1f))//1秒間のインターバル
                    .Subscribe(_ => 
                    {
                        

                    }).AddTo(Chara);
    }

    /// <summary>
    /// ダッシュ
    /// </summary>
    public void CharacterDash_Event()
    {
        _Concent = Observable.EveryUpdate()
                    .Where(_ => actionMap.Player.Jump.WasPressedThisFrame())//押したとき
                    .Throttle(TimeSpan.FromSeconds(1f))//2秒間のインターバル
                    .Subscribe(_ =>
                    {
                        rb.linearVelocity = Vector3.zero;
                    }).AddTo(Chara);
    }


    /// <summary>
    /// Next_Previousのインプットシステムで対象を変更する。
    /// </summary>

    public void SelectSwitch_Event()
    {
        _SelectSwitch_Next = Observable.EveryUpdate()
            .Where(_ => actionMap.Player.Next.WasPressedThisFrame())
            .Subscribe(_ => 
            { 
            });
    }

    public void Dispose()
    {
        _Move?.Dispose();
        _Concent?.Dispose();
        _SelectSwitch_Previous?.Dispose();
        _SelectSwitch_Next?.Dispose();
    }
}