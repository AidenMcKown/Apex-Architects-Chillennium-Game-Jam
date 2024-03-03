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
    [SerializeField] AudioSource clearAudioSource;
    [SerializeField] AudioSource stormAudioSource;
    [SerializeField] AudioClip clearAudio;
    [SerializeField] AudioClip stormAudio;
    [SerializeField] float audioTransitionTime = 3f;
    float targetAudioVolume, clearAudioTransitionVelocity, stormAudioTransitionVelocity;

    [Header("Storm Settings")]
    [SerializeField] ParticleSystem rainParticleSystem;
    [SerializeField] float afternoonRainEmissionRate = 300f;
    [SerializeField] float nightRainEmissionRate = 500f;
    [SerializeField] float emissionRateSmoothTime = 3f;

    float currentRainEmissionRate, targetRainEmissionRate, emissionRateVelocity;
    [SerializeField] float afternoonRainSpeed = 1f;
    [SerializeField] float nightRainSpeed = 1.5f;
    [SerializeField] float rainSpeedSmoothTime = 3f;
    float currentRainSpeed, targetRainSpeed, rainSpeedVelocity;

    void Start()
    {
        clearAudioSource.clip = clearAudio;
        clearAudioSource.Play();

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
                stormAudioSource.clip = stormAudio;
                targetAudioVolume = 0.8f;
                stormAudioSource.Play();
            }

            targetRainEmissionRate = afternoonRainEmissionRate;
            targetRainSpeed = afternoonRainSpeed;
            return State.Afternoon;
        }
        else if (GameState.GetTimeSinceStartOfDay() % dayDuration < dayDuration && GameState.GetTimeSinceStartOfDay() >= 0)
        {
            targetRainEmissionRate = nightRainEmissionRate;
            targetRainSpeed = nightRainSpeed;
            targetAudioVolume = 1f;
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
        currentRainEmissionRate = Mathf.SmoothDamp(currentRainEmissionRate, targetRainEmissionRate, ref emissionRateVelocity, emissionRateSmoothTime);
        ParticleSystem.EmissionModule emissionModule = rainParticleSystem.emission;
        emissionModule.rateOverTime = currentRainEmissionRate;

        // Do the same with the rain speed
        currentRainSpeed = Mathf.SmoothDamp(currentRainSpeed, targetRainSpeed, ref rainSpeedVelocity, emissionRateSmoothTime);
        var mainModule = rainParticleSystem.main;
        mainModule.simulationSpeed = currentRainSpeed;

        // Smooth damp the audio volumes
        clearAudioSource.volume = Mathf.SmoothDamp(clearAudioSource.volume, 0f, ref clearAudioTransitionVelocity, audioTransitionTime);
        stormAudioSource.volume = Mathf.SmoothDamp(stormAudioSource.volume, targetAudioVolume, ref stormAudioTransitionVelocity, audioTransitionTime);
    }
}