using UnityEngine;

public class ActionMapManager : SingletonMonoBehaviourBase<ActionMapManager>
{
    private ActionMapAssets _ActionMapsAssets;

    /// <summary>
    /// アクションマップの情報を取得する
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
    /// Player入力の有効化
    /// </summary>
    public void PlayerEnable()
    {
        _ActionMapsAssets?.Player.Enable();
        _ActionMapsAssets?.UI.Disable();
    }

    /// <summary>
    /// UI入力の有効化
    /// </summary>
    public void UIEnable()
    {
        _ActionMapsAssets?.Player.Disable();
        _ActionMapsAssets?.UI.Enable();
    }

    /// <summary>
    /// Player入力の無効化
    /// </summary>
    public void PlayerDisable()
    {
        _ActionMapsAssets?.Player.Disable();
        Debug.Log("プレイヤー操作無効化");
    }

    /// <summary>
    /// UI入力の有効化
    /// </summary>
    public void UIDisable()
    {
        _ActionMapsAssets?.UI.Disable();
        Debug.Log("UI操作無効化");
    }
}
