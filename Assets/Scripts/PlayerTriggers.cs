using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine.EventSystems;
using System;

public class DialogueStart : MonoBehaviour
{
    public DialogueTrigger dt;
    public TiredScaleTrigger tsTrigger;

    private bool isSleep1;

    private bool isTyping = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "houseEnter":
                TextTemplate("E to enter House");
                break;
            case "coridor":
                TextTemplate("E to enter home");
                break;
            case "leaveCoridor":
                TextTemplate("E to leave");
                break;
            case "exitToCoridor":
                TextTemplate("E to leave");
                break;
            case "bed":
                TextTemplate("E to fall a sleep");
                break;
            case "wake":
                CoroutineTemplate("WakeOutput");
                break;
            case "enterLiving":
                TextTemplate("E to enter living room");
                break;
            case "leaveLiving":
                TextTemplate("E to leave living room");
                break;
            case "enterBed":
                TextTemplate("E to enter bedroom");
                break;
            case "leaveBed":
                TextTemplate("E to leave bedroom");
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "houseEnter":
                if (Input.GetKey(KeyCode.E))
                    SceneController.instance.LoadSceneByName("Coridor");
                break;
            case "coridor":
                if (Input.GetKey(KeyCode.E))
                    SceneController.instance.LoadSceneByName("Home Hallway");
                break;
            case "bed": // cut scene
                if (Input.GetKey(KeyCode.E))
                {
                    SceneController.instance.Sleep1();
                    collision.gameObject.SetActive(false);
                    PlayerController.isAbleMove = false;

                    StartCoroutine(Sleep1Cut());
                }
                break;
            case "exitToCoridor":
                if (Input.GetKey(KeyCode.E))
                    SceneController.instance.LoadSceneByName("Coridor");
                    break;
            case "leaveCoridor":
                if (Input.GetKey(KeyCode.E))
                    SceneController.instance.LoadSceneByName("Street");
                    break;
            case "enterLiving":
                if (Input.GetKey(KeyCode.E))
                    SceneController.instance.LoadSceneByName("Living room");
                break;
            case "enterBed":
                if (Input.GetKey(KeyCode.E))
                    SceneController.instance.LoadSceneByName("Bed room");
                break;
            case "leaveBed":
                if (Input.GetKey(KeyCode.E))
                    SceneController.instance.LoadSceneByName("Home Hallway");
                break;
            case "leaveLiving":
                if (Input.GetKey(KeyCode.E))
                    SceneController.instance.LoadSceneByName("Home Hallway");
                break;
        }

    }


    private IEnumerator Sleep1Cut()
    {
        yield return new WaitForSeconds(7f);
        tsTrigger.GetTire(30f);

        PlayerController.isAbleMove = true;
        SceneController.instance.NextScene();
    }

    private void TextTemplate(string text)
    {
        if (isTyping)
            return;
        isTyping = true;

        dt.SetText(text, delayClean: 5f);

        isTyping = false;
    }

    private void CoroutineTemplate(string coroutineName)
    {
        if (isTyping)
            return;
        isTyping = true;

        StartCoroutine(coroutineName);

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


}
