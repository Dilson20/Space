using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astmanager : MonoBehaviour
{
    public GameObject AsteroidPrefab;

    public float MinSpeedX = -1.0f;
    public float MaxSpeedX = -2.0f;
    public float MinSpeedY = -1.0f;
    public float MaxSpeedY = 1.0f;

    public float MinY = -5.0f;
    public float MaxY = 5.0f;

    public float MinRotate = -180.0f;
    public float MaxRotate = 180.0f;

    public float SpawnTimeMin = 1.0f;
    public float SpawnTimeMax = 2.0f;

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;
        if (timer < 0.0f)
        {
            SpawnAsteroid();
            timer = Random.Range(SpawnTimeMin, SpawnTimeMax);
        }
    }

    public void SpawnAsteroid()
    {
        GameObject newObject = Instantiate(AsteroidPrefab);

        Vector3 pos = transform.position;
        pos.y += Random.Range(MinY, MaxY);

        newObject.transform.position = pos;

        float randomX = Random.Range(MinSpeedX, MaxSpeedX);
        float randomY = Random.Range(MinSpeedY, MaxSpeedY);

        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(randomX, randomY);
        rb.angularVelocity = Random.Range(MinRotate, MaxRotate);
    }
}
