using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadIngScene : MonoBehaviour
{
    private static LoadIngScene instance;
    private Text progress;
    private float progressValue;
    private Slider slider;

    private AsyncOperation async = null;

    void Awake()
    {
        instance = this;
        progress = FindObjectOfType<Text>();
        slider = FindObjectOfType<Slider>();
    }


    public IEnumerator LoadScene(string sceneName)
    {
        async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            if (async.progress < 0.9f)
                progressValue = async.progress;
            else
                progressValue = 1.0f;

            slider.value = progressValue;
            progress.text = (int)(slider.value * 100) + " %";

            if (progressValue >= 0.9)
            {
                async.allowSceneActivation = true;
            }

            yield return null;
        }

    }

}
