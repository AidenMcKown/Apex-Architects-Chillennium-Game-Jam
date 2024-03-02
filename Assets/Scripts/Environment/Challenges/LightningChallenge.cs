using System.Collections;
using UnityEngine;

public class LightningChallenge : Challenge
{

    [SerializeField]
    GameObject lightningWarning1;
    [SerializeField]
    GameObject lightningWarning2;
    [SerializeField]
    GameObject lightningBolt;


    public override void Spawn()
    {
        LightningAI();
    }

    void LightningAI()
    {
        StartCoroutine(ShowLightningWarning(lightningWarning1, lightningWarning2, lightningBolt));
    }

    IEnumerator ShowLightningWarning(GameObject lightningWarning1, GameObject lightningWarning2, GameObject lightningBolt)
    {
        int count = 0;
        GameObject lightningWarningGameObject;
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        // Entire warning lasts 2 seconds
        // Every 0.5 seconds, spawn a warning
        while (count < 20)
        {
            lightningWarningGameObject = Instantiate(lightningWarning1, playerPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            count++;
            Destroy(lightningWarningGameObject);
            lightningWarningGameObject = Instantiate(lightningWarning2, playerPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            count++;
            Destroy(lightningWarningGameObject);
        }
        print("lightning warning done");
        StartCoroutine(SpawnLightning(playerPosition, lightningBolt));
    }

    IEnumerator SpawnLightning(Vector3 playerPosition, GameObject lightningBolt)
    {
        print("spawn lightning");
        GameObject lightningGameObject;
        lightningGameObject = Instantiate(lightningBolt, playerPosition, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(lightningGameObject);
    }
}
