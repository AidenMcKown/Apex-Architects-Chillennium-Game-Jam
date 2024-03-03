using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Transform startPos;
    [SerializeField]
    Transform endPos;
    [SerializeField]
    GameObject boat;
    [SerializeField]
    GameObject message1;
    [SerializeField]
    GameObject message2;

    bool canMovePlayerToBoat = true;
    bool canMovePlayerAndBoat = true;

    float step = 0;

    [SerializeField] Animator playerAnimator;
    float currentAnimVelocity, targetAnimVelocity, animRefVelocity;

    [SerializeField] AudioSource footstepsAudioSource;
    [SerializeField] List<AudioClip> footstepsSounds;
    float footstepTimer;

    void Start()
    {
        transform.position = startPos.position;
        targetAnimVelocity = currentAnimVelocity = 0;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, endPos.position) > 0.1f && canMovePlayerToBoat)
        {
            step += Time.deltaTime / 7f;
            // Lerp the player from the start position to the end position
            transform.position = Vector3.Lerp(startPos.position, endPos.position, step);
            Camera.main.transform.LookAt(transform.position);

            targetAnimVelocity = 0.5f;

            // Play footsteps sound
            footstepTimer += Time.deltaTime;
            if (footstepTimer >= 0.6f)
            {
                footstepTimer = 0;
                footstepsAudioSource.PlayOneShot(footstepsSounds[Random.Range(0, footstepsSounds.Count)]);
            }
        }
        if (Vector3.Distance(transform.position, endPos.position) < 0.1f && canMovePlayerAndBoat)
        {
            canMovePlayerToBoat = false;
            canMovePlayerAndBoat = false;
            StartCoroutine(MovePlayerAndBoat(boat));
            StartCoroutine(DisplayWinMessages(message1, message2));

            targetAnimVelocity = 0f;
        }

        // Animate the player
        currentAnimVelocity = Mathf.SmoothDamp(currentAnimVelocity, targetAnimVelocity, ref animRefVelocity, 0.2f);
        playerAnimator.SetFloat("Velocity", currentAnimVelocity);
    }


    IEnumerator MovePlayerAndBoat(GameObject boat)
    {
        transform.parent = boat.transform;
        Vector3 boatPosition = boat.transform.position;
        Vector3 offsetVector = new(0, 0, 0);
        while (true)
        {
            Camera.main.transform.LookAt(transform.position);
            offsetVector += new Vector3(3f, 0, 0) * Time.deltaTime;
            boat.transform.position = boatPosition + offsetVector;
            yield return null;
        }
    }

    IEnumerator DisplayWinMessages(GameObject message1, GameObject message2)
    {
        yield return new WaitForSeconds(1);
        message1.SetActive(true);

        yield return new WaitForSeconds(2);
        message2.SetActive(true);

        yield return new WaitForSeconds(10);
        Application.Quit();
    }
}