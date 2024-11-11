using Unity.Cinemachine;
using UnityEngine;

public class WiggleCamera : MonoBehaviour
{
    public CinemachineCamera Camera;
    private float Force = 0.3f;

    private void Update()
    {
        float raw = Input.GetAxisRaw("Horizontal");
        Camera.Lens.Dutch += raw * Force;
    }
}
