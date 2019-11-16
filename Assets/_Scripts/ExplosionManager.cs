using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Design Pattern Example

public class ExplosionManager : MonoBehaviour
{
    // a collection to house the explosions
    private static Queue<GameObject> explosions;
    public int explosionNumber = 10;
    public GameObject explosionContainer;

    private static ExplosionManager _instance;

    private ExplosionManager() { } // private constructor function

    // Singleton Instance
    public static ExplosionManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ExplosionManager();
            return _instance;
        }

        return _instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        // instantiate a queue of type GameObject
        explosions = new Queue<GameObject>();

        BuildExplosionPool();
    }

    private void BuildExplosionPool()
    {
        // build the pool
        for (int i = 0; i < explosionNumber; i++)
        {
            var newExplosion = ExplosionFactory.GetInstance().createRandomExplosion();

            // set the parent to the explosion container
            newExplosion.transform.parent = explosionContainer.transform;
            explosions.Enqueue(newExplosion);
        }
    }

    public GameObject GetExplosion()
    {
        var returnedExplosion = explosions.Dequeue();
        returnedExplosion.SetActive(true);
        returnedExplosion.GetComponent<Animator>().Play("explosion");
        return returnedExplosion;
    }

    public void ResetExplosion(GameObject explosion)
    {
        explosion.SetActive(false);
        explosions.Enqueue(explosion);
    }
}
