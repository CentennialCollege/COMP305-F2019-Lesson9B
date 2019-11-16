using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Factory

public class ExplosionFactory : MonoBehaviour
{
    private GameController gameController;
    private static GameObject explosion; // explosion prefab

    private static ExplosionFactory _instance;

    private ExplosionFactory() { } // private constructor

    // static instance
    public static ExplosionFactory GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ExplosionFactory();
            return _instance;
        }

        return _instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        // references to game objects and scripts
        gameController = gameObject.GetComponent<GameController>();
        explosion = gameController.explosion;
    }

    public GameObject createRandomExplosion()
    {
        var randomColour = new Color(Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f), 0.8f);
        var randomRotation = Random.Range(0.0f, 5.0f);
        var randomScale = Random.Range(0.5f, 1.5f);
        var newExplosion = Instantiate(explosion, Vector2.zero, Quaternion.identity);
        newExplosion.GetComponent<SpriteRenderer>().material.color = randomColour;
        newExplosion.transform.Rotate(new Vector3(0.0f, 0.0f, randomRotation)); 
        newExplosion.transform.localScale = new Vector3(randomScale, randomScale, 1.0f);
        newExplosion.SetActive(false);
        return newExplosion;
    }
}
