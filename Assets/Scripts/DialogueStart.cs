using System.Collections;
using UnityEngine;

public class DialogueStart : MonoBehaviour
{
    public DialogueTrigger dt;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Output());
    }


    private IEnumerator Output()
    {
        dt.SetText("H~i~~i.. \ni am-m Maren", delayClean: 2.5f);
        yield return new WaitForSeconds(3f);
        dt.SetText("...");
        yield return new WaitForSeconds(3f);
        dt.SetText("So~oo", delayClean: 1.5f);
        yield return new WaitForSeconds(3f);
        dt.SetText("<color=#FF0000>I am monster?</color>", delayClean: 2f);
        yield return new WaitForSeconds(3f);
        dt.SetText(" <color=#FF0000>I am monster?</color>", delayClean: 2f);
    }
}
