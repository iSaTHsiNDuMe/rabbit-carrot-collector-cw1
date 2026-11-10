using UnityEngine;

public sealed class Student3WalkPreview : MonoBehaviour
{
    public Transform rabbit;
    public Transform[] limbs;
    public GameObject walkPanel;

    Quaternion[] rest;
    float timeLeft;

    void Awake()
    {
        rest = new Quaternion[limbs.Length];
        for (int i = 0; i < limbs.Length; i++) rest[i] = limbs[i].localRotation;
    }

    public void PlayWalk()
    {
        if (IsNearby()) timeLeft = 2.4f;
    }

    bool IsNearby() => (rabbit.position - transform.position).sqrMagnitude <= 25f;

    void Update()
    {
        bool nearby = IsNearby();
        if (walkPanel.activeSelf != nearby) walkPanel.SetActive(nearby);
        if (timeLeft <= 0) return;
        timeLeft = Mathf.Max(0, timeLeft - Time.deltaTime);
        float swing = Mathf.Sin((2.4f - timeLeft) * 11f) * 29f * Mathf.Min(1, timeLeft * 5);
        for (int i = 0; i < limbs.Length; i++)
            limbs[i].localRotation = rest[i] * Quaternion.Euler((i % 2 == 0 ? 1 : -1) * swing, 0, 0);
    }
}
