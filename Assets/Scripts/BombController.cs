using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Blade")
        {
            FindObjectOfType<GameManager>().OnBombCollision();
        }
    }
}
