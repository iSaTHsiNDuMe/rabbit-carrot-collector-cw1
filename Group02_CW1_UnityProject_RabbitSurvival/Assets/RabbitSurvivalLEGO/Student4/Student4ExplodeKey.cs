using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public sealed class Student4ExplodeKey : MonoBehaviour
{
    public Transform rabbit;
    public BoxCollider doorway;
    public float activationDistance = 3f;
    public bool IsOpen { get; private set; }

    private Animator brickAnimator;
    private InputAction openCave;
    private bool opening;

    private void Awake()
    {
        brickAnimator = GetComponent<Animator>();
        openCave = new InputAction("Open Cave", InputActionType.Button, "<Keyboard>/1");
        openCave.performed += TryOpen;
    }

    private void OnEnable() => openCave.Enable();

    private void OnDisable() => openCave.Disable();

    private void OnDestroy() => openCave.Dispose();

    private void Update()
    {
        if (!opening || !brickAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Explode Rest"))
            return;

        doorway.enabled = false;
        IsOpen = true;
        opening = false;
    }

    private void TryOpen(InputAction.CallbackContext context)
    {
        if (IsOpen || opening ||
            (rabbit.position - transform.position).sqrMagnitude > activationDistance * activationDistance)
            return;

        opening = true;
        brickAnimator.Play("Base Layer.Explode", 0, 0f);
    }
}
