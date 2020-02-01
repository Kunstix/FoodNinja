using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] fruits;
    public GameObject bomb;

    public Transform[] spawnPoints;
    public float minWait = 0.3F;
    public float maxWait = 1F;
    public float minSpeed = 12F;
    public float maxSpeed = 19F;

    public int chanceToSpawn = 10;

    void Start()
    {
        StartCoroutine(spawnFruit());
    }

    private IEnumerator spawnFruit()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            Transform spawnPlace = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Debug.Log(spawnPlace);

            GameObject fruit = null;
            int choosePrefab = Random.Range(0,100);

            if(chanceToSpawn > 90)
            {
                chanceToSpawn = 90;
            } else if (chanceToSpawn < 0)
            {
                chanceToSpawn = 0;
            }

            if(choosePrefab < chanceToSpawn)
            {
                fruit = bomb;
            } else
            {
                fruit = fruits[Random.Range(0, fruits.Length)];
            }

            GameObject fruitInstance = Instantiate(fruit, spawnPlace.transform.position, spawnPlace.transform.rotation);

            Rigidbody2D fruitBody = fruitInstance.GetComponent<Rigidbody2D>();
            fruitBody.AddForce(spawnPlace.transform.up*Random.Range(minSpeed, maxSpeed), ForceMode2D.Impulse);

            Destroy(fruitInstance, 5F);
            Debug.Log(fruitInstance);
        }

    }
}
