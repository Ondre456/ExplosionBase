using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSource : MonoBehaviour
{
    [SerializeField] private float _power;

    private const int MinNumberOfNewObjects = 2;
    private const int MaxNumberOfNewObjects = 6;

    private float _chance = 1f;

    private void OnMouseDown()
    {
        float randomValue = Random.value;
        
        if (randomValue <= _chance)
        {
            Explode();
        }

        Destroy(gameObject);
    }

    private void Explode()
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
            ExplosionSource newExplosionSource = newObject.GetComponent<ExplosionSource>();

            if (newExplosionSource != null)
                newExplosionSource._chance = _chance / 2;

            SetRandomColor(newObject);
        }
    }

    private void SetRandomColor(GameObject targetObject)
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        Renderer renderer = targetObject.GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.color = randomColor;
        }
        else
        {
            SpriteRenderer spriteRenderer = targetObject.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
                spriteRenderer.color = randomColor;
        }
    }
}
