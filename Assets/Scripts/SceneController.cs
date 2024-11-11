using System.Collections;
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

    public void NextScene()
    {
        StartCoroutine(Load());
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

}
