using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{

    public GameObject slicedFruitPrefab;
    public float explosionRadius = 8F;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Blade")
        {
            SliceFruit();
        }
    }

    private void SliceFruit()
    {
        FindObjectOfType<GameManager>().PlaySliceSound();

        GameObject slicedFruit = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);
        Rigidbody[] slicedFruitParts = slicedFruit.transform.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody slicedFruitPart in slicedFruitParts)
        {
            slicedFruitPart.transform.rotation = Random.rotation;
            slicedFruitPart.AddExplosionForce(Random.Range(500,2000), transform.position, explosionRadius);
        }

        FindObjectOfType<GameManager>().IncreaseScore(5);

        Destroy(gameObject);
        Debug.Log(gameObject);
        Destroy(slicedFruit, 5);
        Debug.Log(slicedFruit);
    }
}
