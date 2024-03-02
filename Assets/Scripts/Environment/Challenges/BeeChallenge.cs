using System.Collections;

public class BeeChallenge : Challenge
{

    void Start()
    {
        weight = 0.1f;
    }


    public override void Spawn()
    {
        SpawnBee();
        StartCoroutine(BeeAI());
    }

    void SpawnBee()
    {
        // Spawn a bee
    }

    IEnumerator BeeAI()
    {
        // Bee AI
        yield return null;
    }

}
