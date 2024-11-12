using UnityEngine;

public class OpenHallwayDoor : MonoBehaviour
{
    public static OpenHallwayDoor Instance;
    private void Start()
    {
        Instance = this;
    }

    public void SetActiveDoor(bool set)
    {
        transform.gameObject.SetActive(set);
    }
}
