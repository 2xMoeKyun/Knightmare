using UnityEngine;
using UnityEngine.SceneManagement;

public class DogController : MonoBehaviour
{
    public Transform player;          // ������ �� ������
    public float detectionRange = 10f; // ������, � ������� ������ �������� ������������
    public float speed = 5f;          // �������� ������
    private bool isChasing = false;   // ����, �������������, ���������� �� ������

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // ���� ����� � �������� ���������, �������� ������������
        if (distanceToPlayer < detectionRange)
        {
            isChasing = true;
        }

        if (isChasing)
        {
            ChasePlayer(distanceToPlayer);
        }
    }

    private void ChasePlayer(float distanceToPlayer)
    {
        // �������������� � ������
        Vector2 direction = (player.position - transform.position).normalized;

        // ������� ������ � ������� ������
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);


        // ������������ ������ ������ � ������� ������
        if (direction.x > 0 && transform.localScale.x < 0 || direction.x < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag(player.tag))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    private void OnDrawGizmosSelected()
    {
        // ������ ������ ����������� ������ ������
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
