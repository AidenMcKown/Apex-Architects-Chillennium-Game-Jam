using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningChallenge : Challenge
{


    [SerializeField]
    GameObject lightningWarning1;
    [SerializeField]
    GameObject lightningWarning2;
    [SerializeField]

    GameObject lightningWarning3;
    [SerializeField]
    GameObject lightningBolt;

    [Header("Audio Settings")]
    [SerializeField]
    List<AudioClip> lightningSounds;


    public override void Spawn()
    {
        LightningAI();
    }

    void LightningAI()
    {
        StartCoroutine(ShowLightningWarning(lightningWarning1, lightningWarning2, lightningWarning3, lightningBolt));
    }

    IEnumerator ShowLightningWarning(GameObject lightningWarning1, GameObject lightningWarning2, GameObject lightningWarning3, GameObject lightningBolt)
    {
        int count = 0;
        GameObject lightningWarningGameObject;
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        // Entire warning lasts 2 seconds
        // Every 0.5 seconds, spawn a warning
        while (count < 30)
        {
            lightningWarningGameObject = Instantiate(lightningWarning1, playerPosition, Quaternion.Euler(-90, Random.Range(0, 360), 0));
            yield return new WaitForSeconds(0.0667f);
            count++;
            Destroy(lightningWarningGameObject);
            lightningWarningGameObject = Instantiate(lightningWarning2, playerPosition, Quaternion.Euler(-90, Random.Range(0, 360), 0));
            yield return new WaitForSeconds(0.0667f);
            count++;
            Destroy(lightningWarningGameObject);
            lightningWarningGameObject = Instantiate(lightningWarning3, playerPosition, Quaternion.Euler(-90, Random.Range(0, 360), 0));
            yield return new WaitForSeconds(0.0667f);
            count++;
            Destroy(lightningWarningGameObject);
        }
        StartCoroutine(SpawnLightning(playerPosition, lightningBolt));
    }

    IEnumerator SpawnLightning(Vector3 playerPosition, GameObject lightningBolt)
    {
        GameObject lightningGameObject = Instantiate(lightningBolt, playerPosition - new Vector3(0, 1, 0), Quaternion.Euler(-46.306f, Random.Range(0, 360), -87.125f));

        // Give lightning a randomized sound
        AudioSource audioSource = lightningGameObject.GetComponent<AudioSource>();
        audioSource.clip = lightningSounds[Random.Range(0, lightningSounds.Count)];
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.Play();

        yield return new WaitForSeconds(1f);
        Destroy(lightningGameObject);
    }
}
