using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine.EventSystems;
using System;

public class PlayerTriggers : MonoBehaviour
{
    public DialogueTrigger dt;
    public TiredScaleTrigger tsTrigger;

    private bool isSleep1 = false;//!!

    private bool isTyping = false;
    public static bool isFreezer = false;
    public static bool isGoingOut = false;


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
            case "refreg":
                TextTemplate("Take the medicines");
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
                    SceneController.instance.LoadSceneByName(isSleep1 ? "Shroom Hallway" : "Home Hallway");
                break;
            case "exitToCoridor":
                if (Input.GetKey(KeyCode.E))
                    SceneController.instance.LoadSceneByName(isSleep1 ? "Shroom coridor" : "Coridor");
                    break;
            case "leaveCoridor":
                if (Input.GetKey(KeyCode.E))
                    SceneController.instance.LoadSceneByName(isSleep1 ? "Shroom street" : "Street");
                    break;
            case "enterLiving":
                if (Input.GetKey(KeyCode.E))
                    SceneController.instance.LoadSceneByName(isSleep1 ? "Living shroom" : "Living room");
                break;
            case "bed": // cut scene
                if (Input.GetKey(KeyCode.E))
                {
                    SceneController.instance.Sleep1();
                    collision.gameObject.SetActive(false);
                    PlayerController.isAbleMove = false;
                    isSleep1 = true;

                    StartCoroutine(Sleep1Cut());
                }
                break;
            case "enterBed":
                if (Input.GetKey(KeyCode.E))
                    SceneController.instance.LoadSceneByName("Bed room");
                break;
            case "leaveBed":
                if (Input.GetKey(KeyCode.E))
                    SceneController.instance.LoadSceneByName(isSleep1? "Shroom Hallway" : "Home Hallway");
                break;
            case "leaveLiving":
                if (Input.GetKey(KeyCode.E))
                    SceneController.instance.LoadSceneByName(isSleep1 ? "Shroom Hallway" : "Home Hallway");
                break;
            case "refreg":
                if (Input.GetKey(KeyCode.E))
                {
                    SceneController.instance.LoadSceneByName("Refreg");
                    collision.gameObject.SetActive(false);
                }
                break;
        }
        if(isFreezer && collision.CompareTag("cut1"))
        {
            PlayerController.isAbleMove = false;
            isFreezer = false;
            isGoingOut = true;

            tsTrigger.TakeTire(15f);
            CoroutineTemplate("Cut1");
        }
        if (collision.CompareTag("cut3"))
        {
            collision.gameObject.SetActive(false);
            PlayerController.isAbleMove = false;
            SceneController.instance.Cut3();
            tsTrigger.GetTire(60f);
            
        }
    }


    private IEnumerator Sleep1Cut()
    {
        yield return new WaitForSeconds(7f);
        tsTrigger.GetTire(30f);

        PlayerController.isAbleMove = true;
        SceneController.instance.LoadSceneByName("Bed shroom");
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

    private IEnumerator Cut1()
    {
        if (isTyping)
            yield return 0;
        isTyping = true;

        dt.SetText("*Took the medicine*", delayClean: 2.5f);
        yield return new WaitForSeconds(3f);
        dt.SetText("Oh my god..", typingSpeed: 0.1f, delayClean: 2.5f);
        yield return new WaitForSeconds(3f);
        dt.SetText("A little bit better", typingSpeed: 0.05f, delayClean: 2f);
        yield return new WaitForSeconds(3f);
        dt.SetText("I have to go to the <color=#FFFF00>pharmacy</color>", typingSpeed: 0.05f, delayClean: 2f);
        yield return new WaitForSeconds(4f);

        PlayerController.isAbleMove = true;
        isTyping = false;
    }
}
