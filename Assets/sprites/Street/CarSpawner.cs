using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CarSpawner : MonoBehaviour
{
    public List<GameObject> cars;
    public List<Transform> spawnPoints;


    private void Start()
    {
        StartCoroutine(Spawning(new List<Transform>() { spawnPoints[0], spawnPoints[1] }, 0));
        StartCoroutine(Spawning(new List<Transform>() { spawnPoints[2], spawnPoints[3] }, 2));
        StartCoroutine(Spawning(new List<Transform>() { spawnPoints[4] }, 4));
    }

    private IEnumerator Spawning(List<Transform> points, int trimIndex)
    {
        while (true)
        {
            GameObject randomCar = cars[Random.Range(0, cars.Count)];
            Transform randomSpawn = spawnPoints[Random.Range(trimIndex, points.Count+trimIndex)];

            randomSpawn.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            yield return new WaitForSeconds(1.8f);
            GameObject car = Instantiate(randomCar, randomSpawn.position, randomCar.transform.rotation);
            randomSpawn.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0);

            yield return new WaitForSeconds(Random.Range(1f, 2f));
            StartCoroutine(DestroyCar(car));
        }
    }
    private IEnumerator DestroyCar(GameObject car)
    {
        yield return new WaitForSeconds(3);
        Destroy(car);
    }
}
