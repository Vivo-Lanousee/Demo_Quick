using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SceneManager : SingletonMonoBehaviourBase<SceneManager>
{
    private Dictionary<string, AsyncOperationHandle<Scene>> test;


    /// <summary>
    /// �V�[���ύX����(Addressable�ŃV�[�����Ăяo���ύX����)
    /// </summary>
    /// <param name="SceneName"></param>
    public async UniTask SceneChange(string SceneName)
    {
        //Scene�ύX���ł̃A�j���[�V�����Ăяo���ł��Ȃ�ł��ҋ@����Ηǂ��B

        //
        var scene = Addressables.LoadSceneAsync(SceneName, LoadSceneMode.Single, true);
        await scene.Task;


    }
    /// <summary>
    /// �V�[���ύX���ł͖����A�V�[����ǉ��i�Q�[���̒ǉ���ʁj���s�����B
    /// </summary>
    /// <param name="AdditiveSceneName"></param>
    /// <returns></returns>
    public async UniTask AdditiveScene(string AdditiveSceneName)
    {
        var scene = Addressables.LoadSceneAsync(AdditiveSceneName, LoadSceneMode.Additive,true);
        await scene.Task;
    }
    /// <summary>
    /// Additive�V�[���̍폜
    /// </summary>
    /// <returns></returns>
    public async UniTask UnloadAdditive()
    {

    }
}
