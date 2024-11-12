using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine.EventSystems;

public class DialogueStart : MonoBehaviour
{
    public DialogueTrigger dt;
    public TiredScaleTrigger tsTrigger;

    private bool isSleep1;


    private bool isTyping = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //StartCoroutine(Output());
        tsTrigger.TakeTire(15f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "houseEnter":
                houseEnter();
                break;
            case "coridor":
                Coridor();
                break;
            case "tv":
                TV(); 
                break;
            case "bed":
                Bed();
                break;
            case "wake":
                Wake();
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "houseEnter":
                if (Input.GetKey(KeyCode.E))
                    SceneController.instance.NextScene();
                break;
            case "coridor":
                if (Input.GetKey(KeyCode.E))
                    SceneController.instance.NextScene();
                break;
            case "bed":
                if (Input.GetKey(KeyCode.E))
                {
                    SceneController.instance.Sleep1();
                    collision.gameObject.SetActive(false);
                    PlayerController.isAbleMove = false;
                    StartCoroutine(Sleep1Cut());
                }
                break;
        }

    }


    private IEnumerator Sleep1Cut()
    {
        yield return new WaitForSeconds(7f);
        PlayerController.isAbleMove = true;
        SceneController.instance.NextScene();
    }

    private void Wake()
    {
        if (isTyping)
            return;
        isTyping = true;

        StartCoroutine(WakeOutput());

        isTyping = false;
    }

    private void TV()
    {
        if (isTyping)
            return;
        isTyping = true;

        StartCoroutine(TVOutput());

        isTyping = false;
    }

    private void Bed()
    {
        if (isTyping)
            return;
        isTyping = true;

        dt.SetText("E to fall a sleep", delayClean: 5f);

        isTyping = false;
    }

    private void Coridor()
    {

        if (isTyping)
            return;
        isTyping = true;

        dt.SetText("E to enter home", delayClean: 5f);

        isTyping = false;
    }

    private void houseEnter()
    {

        if (isTyping)
            return;
        isTyping = true;

        dt.SetText("E to enter House", delayClean: 5f);

        isTyping = false;
    }

    private IEnumerator WakeOutput()
    {
        if (isTyping)
            yield return 0;
        isTyping = true;

        dt.SetText(" <color=#FF0000>AHHH FUCK</color>", typingSpeed: 0.2f, delayClean: 2.5f);
        yield return new WaitForSeconds(4f);
        dt.SetText(" <color=#FF0000>MY HEAD</color>", typingSpeed: 0.1f, delayClean: 2.5f);
        yield return new WaitForSeconds(4f);
        dt.SetText("Ahh..", typingSpeed: 0.05f, delayClean: 2f);


        isTyping = false;
    }

    private IEnumerator TVOutput()
    {
        if (isTyping)
            yield return 0;
        isTyping = true;


        dt.SetText("Bla-bla-bla", delayClean: 0.5f);
        yield return new WaitForSeconds(2f);
        dt.SetText("A suspicious man resembling \n a knight was spotted today", delayClean: 2f);
        yield return new WaitForSeconds(6f);
        dt.SetText("Witnesses claim to have seen \nhim at the pharmacy", delayClean: 2f);
        yield return new WaitForSeconds(6f);
        dt.SetText("further in the news", delayClean: 0.8f);
        yield return new WaitForSeconds(2f);
        dt.SetText("Bla-bla-bla", delayClean: 0.5f);
        yield return new WaitForSeconds(2f);
        dt.SetText("Bla-bla-bla", delayClean: 0.5f);

        isTyping = false;
    }
}
