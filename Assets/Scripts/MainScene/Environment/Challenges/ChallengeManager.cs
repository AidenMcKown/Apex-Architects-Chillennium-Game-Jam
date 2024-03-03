using UnityEngine;

public class ChallengeManager : MonoBehaviour
{

    public Challenge[] challenges;

    void Update()
    {
        if (EnvironmentEventManager.IsGameActive)
        {
            ManageChallenges();
        }
    }

    void ManageChallenges()
    {
        float randFloat;
        if (EnvironmentEventManager.CurrentState == EnvironmentEventManager.State.Morning)
        {
            foreach (Challenge challenge in challenges)
            {
                randFloat = Random.Range(0f, 1f);
                if (randFloat < challenge.weights[0])
                {
                    // print($"{randFloat} < {challenge.weights}");
                    challenge.Spawn();
                }
            }

        }
        else if (EnvironmentEventManager.CurrentState == EnvironmentEventManager.State.Afternoon)
        {
            foreach (Challenge challenge in challenges)
            {
                randFloat = Random.Range(0f, 1f);
                if (randFloat < challenge.weights[1])
                {
                    // print($"{randFloat} < {challenge.weights}");
                    challenge.Spawn();
                }
            }

        }
        else if (EnvironmentEventManager.CurrentState == EnvironmentEventManager.State.Night)
        {
            foreach (Challenge challenge in challenges)
            {
                randFloat = Random.Range(0f, 1f);
                if (randFloat < challenge.weights[2])
                {
                    // print($"{randFloat} < {challenge.weights}");
                    challenge.Spawn();
                }
            }
        }
    }
}
