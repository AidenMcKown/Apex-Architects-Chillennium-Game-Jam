using UnityEngine;

public class EnvironmentEventManager : MonoBehaviour
{

    public static bool IsGameActive = false;
    public static float dayDuration = 120f;

    public enum State
    {
        NotStarted,
        Morning,
        Afternoon,
        Night
    }

    public static State CurrentState = State.NotStarted;

    State GetState()
    {
        if (GameState.GetTimeSinceStartOfDay() < dayDuration / 3 && GameState.GetTimeSinceStartOfDay() >= 0)
        {
            return State.Morning;
        }
        else if (GameState.GetTimeSinceStartOfDay() < dayDuration * 2 / 3 && GameState.GetTimeSinceStartOfDay() >= 0)
        {
            return State.Afternoon;
        }
        else if (GameState.GetTimeSinceStartOfDay() < dayDuration && GameState.GetTimeSinceStartOfDay() >= 0)
        {
            return State.Night;
        }
        else
        {
            return State.NotStarted;
        }
    }

    void Update()
    {
        CurrentState = GetState();
        // print(CurrentState);
    }




}
