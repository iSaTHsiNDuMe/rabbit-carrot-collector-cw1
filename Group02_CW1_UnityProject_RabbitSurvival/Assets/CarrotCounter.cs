using TMPro;
using UnityEngine;

public class CarrotCounter : MonoBehaviour
{
    public TMP_Text counterText;
    public int totalCarrots = 5;

    private int collected;

    void Start()
    {
        UpdateCounter();
    }

    public void CollectCarrot()
    {
        collected = Mathf.Min(collected + 1, totalCarrots);
        UpdateCounter();
    }

    void UpdateCounter()
    {
        counterText.text = $"Carrots: {collected} / {totalCarrots}";
    }
}