using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    public float speed = 5f;  // �������� ��������
    public Vector2 moveDirection = Vector2.left; // ����������� �������� (� ������)

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
        transform.localScale += Vector3.one*(speed/10000);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // �������� �� ������������ � �������
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.CompareTag("Dog"))
        {
            Destroy(other.gameObject);
        }
    }
}
