using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

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
        switch (collision.transform.tag)
        {
            case "houseEnter":
                houseEnter();

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
                print("Enter");
            break;
        }

    }

    private void houseEnter()
    {

        if (isTyping)
            return;
        isTyping = true;

        dt.SetText("Click E to enter home", delayClean: 5f);

        isTyping = false;
    }

    private IEnumerator Output()
    {
        if (isTyping)
            yield return 0;
        isTyping = true;


        dt.SetText("H~i~~i.. \ni am-m Maren", delayClean: 2.5f);
        yield return new WaitForSeconds(3f);
        dt.SetText("...");
        yield return new WaitForSeconds(3f);
        dt.SetText("So~oo", delayClean: 1.5f);
        yield return new WaitForSeconds(3f);
        dt.SetText(" <color=#FF0000>I am monster?</color>", delayClean: 2f);

        isTyping = false;
    }
}
