using System.Collections;
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
        // print("lightning warning done");
        StartCoroutine(SpawnLightning(playerPosition, lightningBolt));
    }

    IEnumerator SpawnLightning(Vector3 playerPosition, GameObject lightningBolt)
    {
        // print("spawn lightning");
        GameObject lightningGameObject;
        lightningGameObject = Instantiate(lightningBolt, playerPosition - new Vector3(0, 1, 0), Quaternion.Euler(-46.306f, Random.Range(0, 360), -87.125f));
        yield return new WaitForSeconds(1f);
        Destroy(lightningGameObject);
    }
}
