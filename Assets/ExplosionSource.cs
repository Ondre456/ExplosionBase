using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSource : MonoBehaviour
{
    [SerializeField] private float _power = 5;

    private const int MinNumberOfNewObjects = 2;
    private const int MaxNumberOfNewObjects = 6;

    private void OnMouseDown()
    {
        int numberOfNewObjects = Random.Range(MinNumberOfNewObjects, MaxNumberOfNewObjects);

        for (int i = 0; i < numberOfNewObjects; i++)
        {
            GameObject newObject = Instantiate(gameObject);
            var newX = transform.position.x + Random.Range(-_power, _power);
            var newY = transform.position.y + Random.Range(-_power, _power);
            var newZ = transform.position.z + Random.Range(-_power, _power);
            newObject.transform.position = new Vector3(newX, newY, newZ);
            newObject.transform.localScale /= 2;
        }

        Destroy(gameObject);
    }
}
