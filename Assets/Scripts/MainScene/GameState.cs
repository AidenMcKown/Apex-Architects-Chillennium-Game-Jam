using UnityEngine;

public class GameState : MonoBehaviour
{

    public static float timeSinceStartOfDay;
    public static float startTime;
    public static bool hasWon;

    public static void StartGame()
    {
        startTime = 0;
        hasWon = false;
    }

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
            hasWon = true;
        }
    }

}
