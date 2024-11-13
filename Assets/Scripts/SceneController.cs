using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Animator panelAnimator;
    [HideInInspector]
    public static SceneController instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    //public void NextScene()
    //{
    //    StartCoroutine(Load());
    //}

    public void LoadSceneByName(string name)
    {
        StartCoroutine(LoadByName(name));
    }

    public void Sleep1()
    {
        panelAnimator.SetTrigger("Sleep 1");
    }

    private IEnumerator Load()
    {
        panelAnimator.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    private IEnumerator LoadByName(string name)
    {
        panelAnimator.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(name);

    }

    public void FinalSleep()
    {
        panelAnimator.SetTrigger("Sleep fin");
        StartCoroutine(Quit());
    }
    private IEnumerator Quit()
    {
        yield return new WaitForSeconds(5f);
        Application.Quit();

    }

    public void Cut3()
    {
        panelAnimator.SetTrigger("Cut3");
        StartCoroutine(FinishCut());

    }

    private IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(0.5f);
        PlayerController.isAbleMove = true;
        LoadSceneByName("Final scene");
    }
}
