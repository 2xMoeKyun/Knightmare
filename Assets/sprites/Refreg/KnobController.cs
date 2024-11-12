using UnityEngine;
using UnityEngine.SceneManagement;

public class KnobController : MonoBehaviour
{
    private HingeJoint2D hingeJoint;
    private JointMotor2D motor;
    public static int knobPoints;

    private Vector2 lastMousepos;
    private bool isMouseDown;

    private void Start()
    {
        hingeJoint = GetComponent<HingeJoint2D>();
        motor = hingeJoint.motor;

        lastMousepos = Input.mousePosition;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void Update()
    {
        print(knobPoints);
        if (knobPoints == 3)
        {
            SceneManager.LoadScene("Living shroom");
        }

        float AxisY = ((Input.mousePosition.y - lastMousepos.y) / Time.deltaTime) / Screen.height;
        lastMousepos = Input.mousePosition;
        if (!isMouseDown) {
            motor.motorSpeed = Mathf.Lerp(motor.motorSpeed, -20, 10f);
            hingeJoint.motor = motor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        knobPoints++;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        knobPoints--;
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
        motor.motorSpeed = lastMousepos.y;
        hingeJoint.motor = motor;
    }


    private void OnMouseUp()
    {
        isMouseDown = false;
    }
}
