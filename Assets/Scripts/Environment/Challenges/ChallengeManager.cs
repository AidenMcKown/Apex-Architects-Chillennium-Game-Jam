using UnityEngine;

public class ChallengeManager : MonoBehaviour
{

    float[] challengeWeightMultipliers = new float[3] { 1, 2, 3 };
    // Update is called once per frame
    public Challenge[] challenges;
    void Update()
    {
        ManageChallenges();
    }

    void ManageChallenges()
    {
        float randFloat = Random.Range(0f, 1f);

        if (EnvironmentEventManager.CurrentState == EnvironmentEventManager.State.Morning)
        {
            foreach (Challenge challenge in challenges)
            {
                if (randFloat < challenge.weight * challengeWeightMultipliers[0])
                {
                    print($"{randFloat} < {challenge.weight * challengeWeightMultipliers[0]}");
                    challenge.Spawn();
                }
            }

        }
        else if (EnvironmentEventManager.CurrentState == EnvironmentEventManager.State.Afternoon)
        {
            foreach (Challenge challenge in challenges)
            {
                if (randFloat < challenge.weight * challengeWeightMultipliers[1])
                {
                    print($"{randFloat} < {challenge.weight * challengeWeightMultipliers[0]}");
                    challenge.Spawn();
                }
            }

        }
        else if (EnvironmentEventManager.CurrentState == EnvironmentEventManager.State.Night)
        {
            foreach (Challenge challenge in challenges)
            {
                if (randFloat < challenge.weight * challengeWeightMultipliers[2])
                {
                    print($"{randFloat} < {challenge.weight * challengeWeightMultipliers[0]}");
                    challenge.Spawn();
                }
            }

        }
    }
}
