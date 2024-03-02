// using System.Collections;
// using UnityEngine;

// public class BeeChallenge : Challenge
// {

//     [SerializeField]
//     GameObject bee;
//     GameObject beeGameObject;

//     public override void Spawn()
//     {
//         SpawnBee();
//         StartCoroutine(BeeAI());
//     }

//     void SpawnBee()
//     {
//         beeGameObject = Instantiate(bee, transform.position, Quaternion.identity);
//     }

//     IEnumerator BeeAI()
//     {
//         while (true)
//         {
//             beeGameObject.transform.position += new Vector3(0.01f, 0, 0.01f);
//             yield return new WaitForSeconds(0.01f);
//         }
//     }

// }
