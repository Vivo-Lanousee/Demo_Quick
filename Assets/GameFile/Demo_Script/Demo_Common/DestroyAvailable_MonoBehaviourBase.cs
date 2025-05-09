using UnityEngine;


/// <summary>
/// �j��\�V���O���g��
/// </summary>
/// <typeparam name="T"></typeparam>
public class DestroyAvailable_MonoBehaviourBase<T> : MonoBehaviour where T : DestroyAvailable_MonoBehaviourBase<T>
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
        }
        return instance;
    }
}
