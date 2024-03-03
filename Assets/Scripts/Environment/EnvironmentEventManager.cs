using UnityEngine;

public class EnvironmentEventManager : MonoBehaviour
{
    public static bool IsGameActive = false;
    public static float dayDuration = 30f;

    public enum State
    {
        NotStarted,
        Morning,
        Afternoon,
        Night
    }

    public static State CurrentState = State.NotStarted;
    public static bool HasStartedStorming = false;

    [Header("References")]
    [SerializeField] Transform player;

    [Header("Audio Settings")]
    [SerializeField] AudioSource ambientAudioSource;
    [SerializeField] AudioClip clearAudio;
    [SerializeField] AudioClip stormAudio;

    [Header("Storm Settings")]
    [SerializeField] ParticleSystem rainParticleSystem;
    [SerializeField] float afternoonRainEmissionRate = 300f;
    [SerializeField] float nightRainEmissionRate = 500f;
    [SerializeField] float changeInRainEmissionRateSmoothTime = 3f;

    float currentRainEmissionRate, targetRainEmissionRate, emissionRateVelocity;

    void Start()
    {
        ambientAudioSource.clip = clearAudio;
        ambientAudioSource.Play();

        rainParticleSystem.Stop();
        currentRainEmissionRate = targetRainEmissionRate = 0f;
    }

    State GetState()
    {
        if (GameState.GetTimeSinceStartOfDay() % dayDuration < dayDuration / 3 && GameState.GetTimeSinceStartOfDay() >= 0)
        {
            return State.Morning;
        }
        else if (GameState.GetTimeSinceStartOfDay() % dayDuration < dayDuration * 2 / 3 && GameState.GetTimeSinceStartOfDay() >= 0)
        {
            if (!HasStartedStorming)
            {
                HasStartedStorming = true;
                // Change the audio to storm
                ambientAudioSource.clip = stormAudio;
                ambientAudioSource.Play();
            }

            targetRainEmissionRate = afternoonRainEmissionRate;
            return State.Afternoon;
        }
        else if (GameState.GetTimeSinceStartOfDay() % dayDuration < dayDuration && GameState.GetTimeSinceStartOfDay() >= 0)
        {
            targetRainEmissionRate = nightRainEmissionRate;
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

        StormEffects();
    }

    private void StormEffects()
    {
        if (!HasStartedStorming) return;

        if (rainParticleSystem.isStopped) rainParticleSystem.Play();

        // Set the rain particle system position to above the player's position
        rainParticleSystem.transform.position = player.position + new Vector3(0, 20, 0);

        // Smooth damp the rain emission rate for smooth transitions
        currentRainEmissionRate = Mathf.SmoothDamp(currentRainEmissionRate, targetRainEmissionRate, ref emissionRateVelocity, changeInRainEmissionRateSmoothTime);
        ParticleSystem.EmissionModule emissionModule = rainParticleSystem.emission;
        emissionModule.rateOverTime = currentRainEmissionRate;
    }
}