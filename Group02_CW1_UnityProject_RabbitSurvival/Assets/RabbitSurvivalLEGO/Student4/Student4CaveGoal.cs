using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public sealed class Student4CaveGoal : MonoBehaviour
{
    public CharacterController rabbit;
    public Student4ExplodeKey caveWall;
    public UnityEngine.UI.Text status;
    public bool Won { get; private set; }

    private float caughtUntil;

    private void Update()
    {
        if (Won || Time.time < caughtUntil)
            return;

        bool byWall = (rabbit.transform.position - caveWall.transform.position).sqrMagnitude
            <= caveWall.activationDistance * caveWall.activationDistance;
        string message = "Avoid the hunters and cross the bridge.";
        if (caveWall.IsOpen)
            message = "Meet the second rabbit inside the cave.";
        else if (byWall)
            message = "Press 1 to open the cave.";

        if (status.text != message)
            status.text = message;
    }

    public void ShowCaught()
    {
        caughtUntil = Time.time + 3f;
        status.text = "A hunter caught you. Use the bushes for cover.";
    }

    private void OnTriggerEnter(Collider other) => TryWin(other);

    private void OnTriggerStay(Collider other) => TryWin(other);

    private void TryWin(Collider other)
    {
        if (Won || other != rabbit || !caveWall.IsOpen)
            return;

        Won = true;
        status.text = "You found the second rabbit!";
    }
}
