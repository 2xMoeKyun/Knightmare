using UnityEngine;

public class OpenHallwayDoor : MonoBehaviour
{
    public GameObject target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerTriggers.isGoingOut && collision.CompareTag("cut2"))
        {
            PlayerTriggers.isGoingOut = false;
            target.SetActive(true);
        }
    }
}
