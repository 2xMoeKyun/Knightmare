using UnityEngine;
using UnityEngine.SceneManagement;

public class DogController : MonoBehaviour
{
    public Transform player;          // Ссылка на игрока
    public float detectionRange = 10f; // Радиус, в котором собака начинает преследовать
    public float speed = 5f;          // Скорость собаки
    private bool isChasing = false;   // Флаг, отслеживающий, преследует ли собака

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Если игрок в пределах видимости, начинаем преследовать
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
        // Поворачиваемся к игроку
        Vector2 direction = (player.position - transform.position).normalized;

        // Двигаем собаку в сторону игрока
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);


        // Поворачиваем спрайт собаки в сторону игрока
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
        // Рисуем радиус обнаружения вокруг собаки
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
