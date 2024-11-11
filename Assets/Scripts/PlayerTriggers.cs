using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using System.Net.NetworkInformation;

public class DialogueStart : MonoBehaviour
{
    public DialogueTrigger dt;
    public TiredScaleTrigger tsTrigger;


    private bool isTyping = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //StartCoroutine(Output());
        tsTrigger.TakeTire(15f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);  
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
                    SceneController.instance.Sleep1();
                break;
        }

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

    private IEnumerator TVOutput()
    {
        if (isTyping)
            yield return 0;
        isTyping = true;


        dt.SetText("Bla-bla-bla", delayClean: 0.5f);
        yield return new WaitForSeconds(3f);
        dt.SetText("A suspicious man resembling \n a knight was spotted today", delayClean: 2f);
        yield return new WaitForSeconds(6f);
        dt.SetText("Witnesses claim to have seen \nhim at the pharmacy", delayClean: 2f);
        yield return new WaitForSeconds(6f);
        dt.SetText("further in the news", delayClean: 0.8f);
        yield return new WaitForSeconds(3f);
        dt.SetText("Bla-bla-bla", delayClean: 0.5f);
        yield return new WaitForSeconds(3f);
        dt.SetText("Bla-bla-bla", delayClean: 0.5f);

        isTyping = false;
    }
}
