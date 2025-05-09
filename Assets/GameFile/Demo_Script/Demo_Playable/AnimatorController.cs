using UniRx;
using UnityEngine;

/// <summary>
/// Demo�łȂ̂ŎG�ł��B�L�����N�^�[�ɒ��A�^�b�`�z��B(�{�Ԃ͐�΃_���B
/// </summary>
public class AnimatorController : MonoBehaviour
{
    private Animator Animator;
    private Rigidbody2D _rb;

    //�A�j���[�^�[�̃p�����[�^�[���n�b�V����
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Horizontal_OnMove = Animator.StringToHash("Horizontal_OnMove");
    private static readonly int Vertical_OnMove = Animator.StringToHash("Vertical_OnMove");
    
    //�e�X�g
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
        //velocity���擾���Ĉړ����Ă��邩�ǂ���
        var move = _rb.linearVelocity;

        //�c�����̈ړ������
        //���ǋL�BInput�̏����Łw��������ȊOInput���󂯕t���Ȃ��x�Ƃ��邱�Ƃ�InputSystem�̓��͂����Ă��܂����ق��������̂ł́H
        //�����ǂ܂��ʓ|�Ȃ��ƂɂȂ肻���B�����I�������Ȃ��Ƃ��F�X���������肻�������B
        //����AnimationMap��Ȃ���(���ʂɓ������肷�镪�ɂ͂������Ǔ���s���������ɋl��(����̃Q�[���̎g�p����Ȃ������ȋC�͂��邯�ǍאS�̒��ӂ͕K�{�B
        Animator.SetFloat(Vertical,move.y);
        //����������́B
        Animator.SetFloat(Horizontal, move.x);
        
        //�c������0�łȂ���΁B
        //Reactive�ōČ��ł��Ȃ�������
        Animator.SetBool(Vertical_OnMove, move.y != 0);
        //��������0�łȂ���΁B
        Animator.SetBool(Horizontal_OnMove, move.x != 0);

        
    }
}
