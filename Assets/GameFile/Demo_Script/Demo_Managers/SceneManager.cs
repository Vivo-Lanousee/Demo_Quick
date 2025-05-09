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
    /// シーン変更処理(Addressableでシーンを呼び出し変更する)
    /// </summary>
    /// <param name="SceneName"></param>
    public async UniTask SceneChange(string SceneName)
    {
        //Scene変更時でのアニメーション呼び出しでもなんでも待機すれば良い。

        //
        var scene = Addressables.LoadSceneAsync(SceneName, LoadSceneMode.Single, true);
        await scene.Task;


    }
    /// <summary>
    /// シーン変更時では無く、シーンを追加（ゲームの追加画面）を行う時。
    /// </summary>
    /// <param name="AdditiveSceneName"></param>
    /// <returns></returns>
    public async UniTask AdditiveScene(string AdditiveSceneName)
    {
        var scene = Addressables.LoadSceneAsync(AdditiveSceneName, LoadSceneMode.Additive,true);
        await scene.Task;
    }
    /// <summary>
    /// Additiveシーンの削除
    /// </summary>
    /// <returns></returns>
    public async UniTask UnloadAdditive()
    {

    }
}
