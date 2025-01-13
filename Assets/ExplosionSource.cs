using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSource : MonoBehaviour
{
    [SerializeField] private float _explosionPower;

    private const int MinNumberOfNewObjects = 2;
    private const int MaxNumberOfNewObjects = 6;
    private const float ExplosionPowerDividor = 2;

    private float _chanceToExplode = 1f;

    private void OnMouseDown()
    {
        float randomValue = Random.value;
        
        if (randomValue <= _chanceToExplode)
        {
            Explode();
        }

        Destroy(gameObject);
    }

    private void Explode()
    {
        int countOfNewObjects = Random.Range(MinNumberOfNewObjects, MaxNumberOfNewObjects);

        for (int i = 0; i < countOfNewObjects; i++)
        {
            GameObject newObject = Instantiate(gameObject);
            var newX = transform.position.x + Random.Range(-_explosionPower, _explosionPower);
            var newY = transform.position.y + Random.Range(-_explosionPower, _explosionPower);
            var newZ = transform.position.z + Random.Range(-_explosionPower, _explosionPower);
            newObject.transform.position = new Vector3(newX, newY, newZ);
            newObject.transform.localScale /= 2;
            ExplosionSource newExplosionSource = newObject.GetComponent<ExplosionSource>();

            if (newExplosionSource != null)
                newExplosionSource._chanceToExplode = _chanceToExplode / ExplosionPowerDividor;
            
            Cube cube = newObject.GetComponent<Cube>();
            cube?.SetRandomColor();
        }
    }

   
}
