using UnityEngine;

public class ActionMapManager : SingletonMonoBehaviourBase<ActionMapManager>
{
    private ActionMapAssets _ActionMapsAssets;

    /// <summary>
    /// �A�N�V�����}�b�v�̏����擾����
    /// </summary>
    /// <returns></returns>
    public ActionMapAssets GetControllersConnect()
    {
        if (_ActionMapsAssets == null)
        {
            _ActionMapsAssets = new ActionMapAssets();
        }
        return _ActionMapsAssets;
    }

    /// <summary>
    /// Player���̗͂L����
    /// </summary>
    public void PlayerEnable()
    {
        _ActionMapsAssets?.Player.Enable();
        _ActionMapsAssets?.UI.Disable();
    }

    /// <summary>
    /// UI���̗͂L����
    /// </summary>
    public void UIEnable()
    {
        _ActionMapsAssets?.Player.Disable();
        _ActionMapsAssets?.UI.Enable();
    }

    /// <summary>
    /// Player���̖͂�����
    /// </summary>
    public void PlayerDisable()
    {
        _ActionMapsAssets?.Player.Disable();
        Debug.Log("�v���C���[���얳����");
    }

    /// <summary>
    /// UI���̗͂L����
    /// </summary>
    public void UIDisable()
    {
        _ActionMapsAssets?.UI.Disable();
        Debug.Log("UI���얳����");
    }
}
