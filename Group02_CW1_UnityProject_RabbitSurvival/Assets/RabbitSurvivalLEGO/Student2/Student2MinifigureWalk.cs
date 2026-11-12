using UnityEngine;

public class Student2MinifigureWalk : MonoBehaviour
{
    public Transform leftHip;
    public Transform rightHip;
    public Transform leftShoulder;
    public Transform rightShoulder;

    public float duration = 2.4f;
    public float swingAngle = 30f;
    public float cyclesPerSecond = 2f;

    private Quaternion leftHipRest;
    private Quaternion rightHipRest;
    private Quaternion leftShoulderRest;
    private Quaternion rightShoulderRest;
    private float timeLeft;
    private bool poseCached;

    void Awake()
    {
        CacheRestPose();
    }

    public void PlayWalk()
    {
        if (!poseCached)
            CacheRestPose();

        timeLeft = duration;
    }

    void Update()
    {
        if (timeLeft <= 0f)
            return;

        timeLeft = Mathf.Max(0f, timeLeft - Time.deltaTime);

        float elapsed = duration - timeLeft;
        float swing = Mathf.Sin(elapsed * cyclesPerSecond * Mathf.PI * 2f) * swingAngle;

        if (leftHip) leftHip.localRotation = leftHipRest * Quaternion.Euler(swing, 0f, 0f);
        if (rightHip) rightHip.localRotation = rightHipRest * Quaternion.Euler(-swing, 0f, 0f);
        if (leftShoulder) leftShoulder.localRotation = leftShoulderRest * Quaternion.Euler(-swing, 0f, 0f);
        if (rightShoulder) rightShoulder.localRotation = rightShoulderRest * Quaternion.Euler(swing, 0f, 0f);

        if (timeLeft == 0f)
            ResetPose();
    }

    void CacheRestPose()
    {
        if (leftHip) leftHipRest = leftHip.localRotation;
        if (rightHip) rightHipRest = rightHip.localRotation;
        if (leftShoulder) leftShoulderRest = leftShoulder.localRotation;
        if (rightShoulder) rightShoulderRest = rightShoulder.localRotation;

        poseCached = true;
    }

    void ResetPose()
    {
        if (leftHip) leftHip.localRotation = leftHipRest;
        if (rightHip) rightHip.localRotation = rightHipRest;
        if (leftShoulder) leftShoulder.localRotation = leftShoulderRest;
        if (rightShoulder) rightShoulder.localRotation = rightShoulderRest;
    }

    void OnDisable()
    {
        if (poseCached)
            ResetPose();
    }
}