using UnityEngine;

[RequireComponent(typeof(Animator))]
public sealed class Student4RabbitWalk : MonoBehaviour
{
    public void PlayWalk()
    {
        GetComponent<Animator>().Play("Base Layer.Walk", 0, 0f);
    }
}
