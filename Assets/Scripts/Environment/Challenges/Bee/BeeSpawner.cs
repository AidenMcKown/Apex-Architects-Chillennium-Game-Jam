using System.Collections;
using UnityEngine;

public class BeeSpawner : Challenge
{

    [SerializeField]
    GameObject bee;
    GameObject beeGameObject;

    public override void Spawn()
    {
        SpawnBee();
    }

    void SpawnBee()
    {
        beeGameObject = Instantiate(bee, transform.position, Quaternion.identity);
        beeGameObject.transform.parent = transform;
        beeGameObject.AddComponent<BeeAI>();
    }

}
