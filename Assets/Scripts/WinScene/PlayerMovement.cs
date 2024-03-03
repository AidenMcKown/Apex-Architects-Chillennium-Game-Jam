using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        print("Starting!");


        transform.position = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, endPos.position) > 0.1f && canMovePlayerToBoat)
        {
            step += Time.deltaTime / 7f;
            // print(Time.deltaTime / 7f);
            // Lerp the player from the start position to the end position
            transform.position = Vector3.Lerp(startPos.position, endPos.position, step);
            Camera.main.transform.LookAt(transform.position);
            // print("Moving player to the end position!");
        }
        if (Vector3.Distance(transform.position, endPos.position) < 0.1f && canMovePlayerAndBoat)
        {
            canMovePlayerToBoat = false;
            canMovePlayerAndBoat = false;
            StartCoroutine(MovePlayerAndBoat(boat));
            StartCoroutine(DisplayWinMessages(message1, message2));
        }
    }


    IEnumerator MovePlayerAndBoat(GameObject boat)
    {
        // print("Moving player and boat!");
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
        // print("Displaying win messages!");
        yield return new WaitForSeconds(1);
        message1.SetActive(true);
        yield return new WaitForSeconds(1);
        message2.SetActive(true);
        yield return new WaitForSeconds(10);
        Application.Quit();
    }


}
