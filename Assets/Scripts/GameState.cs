using UnityEngine;

public class GameState : MonoBehaviour
{

    static float timeSinceStartOfDay;
    public static float startTime;

    public static float GetTimeSinceStartOfDay()
    {
        if (startTime == 0)
        {
            return -1;
        }
        else
        {
            timeSinceStartOfDay = Time.time - startTime;
            return timeSinceStartOfDay;
        }
    }

    void Update()
    {
        if (timeSinceStartOfDay > EnvironmentEventManager.dayDuration)
        {
            EnvironmentEventManager.IsGameActive = false;
            print("You Won!");
        }
    }

}
