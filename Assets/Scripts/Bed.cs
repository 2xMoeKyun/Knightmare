using UnityEngine;


public class Bed : MonoBehaviour
{

    public DialogueTrigger dt;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        dt.SetText("Click E to sleep");

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            dt.SetText("*Затменение экрана*");

        }
    }
}
