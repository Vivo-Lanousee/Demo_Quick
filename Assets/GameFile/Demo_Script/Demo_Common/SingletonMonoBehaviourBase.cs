using UnityEngine;
/// <summary>
/// �V���O���g���N���X�̃x�[�X�N���X�iMonoBehaviour����j
/// </summary>
public class SingletonMonoBehaviourBase<T> : MonoBehaviour where T : SingletonMonoBehaviourBase<T>
{
    /// <summary>
    /// �ÓI�ȕϐ�
    /// </summary>
    protected static T instance;

    /// <summary>
    /// �{�̂̎擾
    /// </summary>
    /// <returns></returns>
    public static T Instance()
    {
        // �Ȃ���΁AGameObject�Ő�����Dontdestroy�Ɉړ�������
        if (instance == null)
        {
            var gameObject = new GameObject(typeof(T).Name);
            instance = gameObject.AddComponent<T>();
            DontDestroyOnLoad(gameObject);
        }

        return instance;
    }
}