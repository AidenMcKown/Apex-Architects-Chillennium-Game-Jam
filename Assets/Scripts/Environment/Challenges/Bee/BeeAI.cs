using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAI : MonoBehaviour
{
    [Header("References")]
    public AudioSource beeAudioSource;

    [Header("Bee Settings")]
    bool beeline = false;
    Vector3 playerPosition;
    Vector3 beelineDirection;
    float startTime;
    float circleRadius = 0;
    Vector3 circleCenter;

    void Start()
    {
        startTime = Time.time;
        circleCenter = transform.parent.transform.position;
        StartCoroutine(BeeAICoroutine());
    }

    IEnumerator BeeAICoroutine()
    {

        while (!beeline)
        {
            playerPosition = GameObject.Find("Player").transform.position;
            HandleBeeAudio();
            if (Vector3.Distance(transform.position, playerPosition) > 50)
            {
                Destroy(gameObject);
            }
            if (Vector3.Distance(transform.position, playerPosition) < 6)
            {
                beeline = true;
                beelineDirection = (playerPosition - transform.position).normalized / 10;
            }
            else
            {
                transform.position = circleCenter + new Vector3(circleRadius * Mathf.Cos(Time.time - startTime), 0, circleRadius * Mathf.Sin(Time.time - startTime));
                circleRadius = 1.5f + Mathf.Sin(Time.time - startTime) * Mathf.Sin((Time.time - startTime) / 1.2f) * 2;
            }

            yield return new WaitForSeconds(0.01f);
        }
        while (beeline)
        {
            HandleBeeAudio();
            if (Vector3.Distance(transform.position, playerPosition) > 50)
            {
                Destroy(gameObject);
            }

            transform.position += beelineDirection;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void HandleBeeAudio()
    {
        if (Vector3.Distance(transform.position, playerPosition) > 20)
        {
            beeAudioSource.mute = true;
        }
        else
        {
            beeAudioSource.mute = false;
        }
    }
}
