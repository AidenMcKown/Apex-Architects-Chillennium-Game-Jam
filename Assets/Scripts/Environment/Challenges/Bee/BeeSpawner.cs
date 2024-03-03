using System.Collections.Generic;
using UnityEngine;

public class BeeSpawner : Challenge
{
    [SerializeField] GameObject beePrefab;
    [SerializeField] List<AudioClip> beeBuzzingSounds;

    public override void Spawn()
    {
        SpawnBee();
    }

    void SpawnBee()
    {
        GameObject beeGameObject = Instantiate(beePrefab, transform.position, Quaternion.identity);
        beeGameObject.transform.parent = transform;
        BeeAI beeAI = beeGameObject.GetComponent<BeeAI>();

        // Give bee a random buzzing sound
        beeAI.beeAudioSource.clip = beeBuzzingSounds[Random.Range(0, beeBuzzingSounds.Count)];
        beeAI.beeAudioSource.pitch = Random.Range(0.8f, 1.2f);
        beeAI.beeAudioSource.Play();
    }

}
