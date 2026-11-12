using UnityEngine;

public class CarrotPickup : MonoBehaviour
{
    public CarrotCounter counter;
    private bool collected;

    void OnTriggerEnter(Collider other)
    {
        if (collected || other.GetComponent<CharacterController>() == null)
            return;

        collected = true;
        counter.CollectCarrot();
        gameObject.SetActive(false);
    }
}