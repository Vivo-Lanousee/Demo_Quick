using UniRx;
using UnityEngine;

/// <summary>
/// Demo版なので雑です。キャラクターに直アタッチ想定。(本番は絶対ダメ。
/// </summary>
public class AnimatorController : MonoBehaviour
{
    private Animator Animator;
    private Rigidbody2D _rb;

    //アニメーターのパラメーターをハッシュ化
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Horizontal_OnMove = Animator.StringToHash("Horizontal_OnMove");
    private static readonly int Vertical_OnMove = Animator.StringToHash("Vertical_OnMove");
    
    //テスト
    ReactiveProperty<Vector3> _MoveInit= new ReactiveProperty<Vector3>();

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();

        _MoveInit.Subscribe(_ => { 
            
        });
    }

    // Update is called once per frame
    void Update()
    {
        //velocityを取得して移動しているかどうか
        var move = _rb.linearVelocity;

        //縦方向の移動を入力
        //→追記。Inputの条件で『特定条件以外Inputを受け付けない』とすることでInputSystemの入力を入れてしまったほうが早いのでは？
        //→結局また面倒なことになりそう。強制終了させないとか色々やり方もありそうだし。
        //結局AnimationMapやなこれ(普通に動いたりする分にはいいけど特殊行動した時に詰む(今回のゲームの使用上問題なさそうな気はするけど細心の注意は必須。
        Animator.SetFloat(Vertical,move.y);
        //横方向を入力。
        Animator.SetFloat(Horizontal, move.x);
        
        //縦方向に0でなければ。
        //Reactiveで再現できないかこれ
        Animator.SetBool(Vertical_OnMove, move.y != 0);
        //横方向に0でなければ。
        Animator.SetBool(Horizontal_OnMove, move.x != 0);

        
    }
}
