using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : Singleton<SceneController>
{
    public GameObject playerPrefab;

    public SceneFader sceneFaderPrefab;

    GameObject player;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "UITestScene")
        //{
        //    GameManager.Instance.playerStats.attackData.minDamage = 4;
        //    GameManager.Instance.playerStats.attackData.maxDamage = 6;
        //    TransitionToMain();
        //}
    }

    public void TransitionToDestination(TransitionPoint transitionPoint)
    {
        switch (transitionPoint.transitionType)
        {
            case TransitionPoint.TransitionType.SameScene:
                StartCoroutine(Transition(SceneManager.GetActiveScene().name, transitionPoint.destinationTag));
                break;
            case TransitionPoint.TransitionType.DifferentScene:
                StartCoroutine(Transition(transitionPoint.sceneName, transitionPoint.destinationTag));
                break;
        }
    }
    IEnumerator Transition(string sceneName, TransitionDestination.DestinationTag destinationTag)
    {
        //保存數據
        SaveManager.Instance.SavePlayerData();
        SceneFader fade = Instantiate(sceneFaderPrefab);
        
        //轉換不同場景
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene("Loading");
            GameManager.Instance.Ken_Human = true;
            yield return StartCoroutine(fade.FadeOut(2f));
            yield return SceneManager.LoadSceneAsync(sceneName);
            yield return Instantiate(playerPrefab, GetDestination(destinationTag).transform.position, GetDestination(destinationTag).transform.rotation);
            SaveManager.Instance.LoadPlayerData();
            yield return StartCoroutine(fade.FadeIn(2f));
            yield break;
        }
        //相同場景
        else
        {
        player = GameManager.Instance.playerStats.gameObject;
        player.transform.SetPositionAndRotation(GetDestination(destinationTag).transform.position, GetDestination(destinationTag).transform.rotation);
        yield return null;
        }
    }

    private TransitionDestination GetDestination(TransitionDestination.DestinationTag destinationTag)
    {
        var entrances = FindObjectsOfType<TransitionDestination>();
        for(int i = 0; i< entrances.Length; i++)
        {
            if (entrances[i].destinationTag == destinationTag)
                return entrances[i];
        }
        return null;
    }

    public void TransitionToMain()
    {
        StartCoroutine(LoadMain());
    }

    public void TransitionToLoadGame()
    {
        StartCoroutine(LoadLevel(SaveManager.Instance.SceneName));
    }
    //轉到第一個場景
    public void TransitionToFirstLevel()
    {
        StartCoroutine(LoadLevel("最終村莊"));
    }

    public void TransitionToOpeningAnim()
    {
        StartCoroutine(LoadOpeningAnim("OpeningAnimation"));
    }

    IEnumerator LoadLevel(string scene)
    {
        SceneFader fade = Instantiate(sceneFaderPrefab);

        if(scene != "")
        {
            yield return StartCoroutine(fade.FadeOut(2f));
            yield return SceneManager.LoadSceneAsync(scene);
            yield return player = Instantiate(playerPrefab, GameManager.Instance.GetEntrance().position, GameManager.Instance.GetEntrance().rotation);

            //保存遊戲
            SaveManager.Instance.SavePlayerData();
            //AudioSetting.instance.GetSoundVolume();
            yield return StartCoroutine(fade.FadeIn(2f));
            yield break;
        }
    }

    IEnumerator LoadOpeningAnim(string scene)
    {
        SceneFader fade = Instantiate(sceneFaderPrefab);

        if (scene != "")
        {
            yield return StartCoroutine(fade.FadeOut(2f));
            yield return SceneManager.LoadSceneAsync(scene);
            yield return StartCoroutine(fade.FadeIn(2f));
            yield break;
        }
    }
    //轉到主頁面
    IEnumerator LoadMain()
    {
        SceneFader fade = Instantiate(sceneFaderPrefab);
        yield return StartCoroutine(fade.FadeOut(2f));
        yield return SceneManager.LoadSceneAsync("UITestScene");
        yield return StartCoroutine(fade.FadeIn(1f));
        yield break;
    }

    public void DeadScene(string scene)
    {
        StartCoroutine(deadScene(scene));
    }

    IEnumerator deadScene(string scene)
    {
        SceneFader fade = Instantiate(sceneFaderPrefab);
        if (scene != "")
        {
            NewPlayerController.instance.HumanState("Human_Dead");
            NewPlayerController.instance.DemonState("Demon_Dead");
            yield return StartCoroutine(fade.FadeOut(1.5f));
            yield return SceneManager.LoadSceneAsync(scene);
            yield return StartCoroutine(fade.FadeIn(2f));
            yield break;
        }
    }

    
}
