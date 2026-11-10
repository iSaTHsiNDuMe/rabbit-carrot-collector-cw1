using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public sealed class Student3RabbitController : MonoBehaviour
{
    public Camera followCamera;
    public BoxCollider[] hideZones;
    public GameObject hiddenBadge;
    public bool IsHidden { get; private set; }

    CharacterController controller;
    float verticalSpeed;
    float cameraYaw;
    float cameraPitch = 35.8f;
    bool mouseLook;
    readonly RaycastHit[] cameraHits = new RaycastHit[12];

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        UpdateCover();
        Follow(true);
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        UpdateMouseLook(keyboard);
        Vector3 direction = Vector3.zero;
        if (keyboard != null)
        {
            direction = Vector3.ClampMagnitude(new Vector3(
                (keyboard.dKey.isPressed ? 1 : 0) - (keyboard.aKey.isPressed ? 1 : 0), 0,
                (keyboard.wKey.isPressed ? 1 : 0) - (keyboard.sKey.isPressed ? 1 : 0)), 1);
        }
        direction = Quaternion.Euler(0, cameraYaw, 0) * direction;
        if (direction.sqrMagnitude > .01f)
        {
            // The existing rabbit mesh faces local negative Z.
            var target = Quaternion.LookRotation(-direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, 720 * Time.deltaTime);
        }
        if (controller.isGrounded)
            verticalSpeed = keyboard != null && keyboard.spaceKey.wasPressedThisFrame ? 5.25f : -2f;
        verticalSpeed = Mathf.Max(verticalSpeed - 17f * Time.deltaTime, -15f);
        controller.Move((direction * 4.35f + Vector3.up * verticalSpeed) * Time.deltaTime);
        UpdateCover();
    }

    void LateUpdate() => Follow(false);

    void UpdateMouseLook(Keyboard keyboard)
    {
        if (keyboard != null && keyboard.escapeKey.wasPressedThisFrame)
        {
            ReleaseMouse();
            return;
        }
        if (keyboard != null && keyboard.cKey.wasPressedThisFrame)
        {
            if (mouseLook && Cursor.lockState == CursorLockMode.Locked) ReleaseMouse();
            else
            {
                mouseLook = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            return;
        }
        if (!mouseLook) return;
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            ReleaseMouse();
            return;
        }
        var mouse = Mouse.current;
        if (mouse == null) return;
        var delta = mouse.delta.ReadValue();
        cameraYaw = Mathf.Repeat(cameraYaw + delta.x * .16f, 360f);
        cameraPitch = Mathf.Clamp(cameraPitch - delta.y * .14f, 10f, 65f);
    }

    void ReleaseMouse()
    {
        if (!mouseLook) return;
        mouseLook = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnApplicationFocus(bool focused)
    {
        if (!focused) ReleaseMouse();
    }

    void OnDisable() => ReleaseMouse();

    void UpdateCover()
    {
        var center = transform.TransformPoint(controller.center);
        bool inside = false;
        foreach (var zone in hideZones)
        {
            if (!zone || !zone.enabled || !zone.gameObject.activeInHierarchy) continue;
            var offset = zone.transform.InverseTransformPoint(center) - zone.center;
            var half = zone.size * .5f;
            if (Mathf.Abs(offset.x) <= half.x && Mathf.Abs(offset.y) <= half.y && Mathf.Abs(offset.z) <= half.z)
            {
                inside = true;
                break;
            }
        }
        IsHidden = inside;
        if (hiddenBadge && hiddenBadge.activeSelf != IsHidden) hiddenBadge.SetActive(IsHidden);
    }

    void Follow(bool snap)
    {
        if (!followCamera) return;
        var focus = transform.position + Vector3.up * .70f;
        var orbit = Quaternion.Euler(cameraPitch, cameraYaw, 0);
        var offset = orbit * (Vector3.back * 4.87f);
        var direction = offset.normalized;
        float distance = offset.magnitude;
        int hits = Physics.SphereCastNonAlloc(focus, .16f, direction, cameraHits, distance,
            ~0, QueryTriggerInteraction.Ignore);
        for (int i = 0; i < hits; i++)
        {
            var hit = cameraHits[i];
            if (hit.collider != controller)
                distance = Mathf.Min(distance, Mathf.Max(.45f, hit.distance - .15f));
        }
        var target = focus + direction * distance;
        var cameraTransform = followCamera.transform;
        cameraTransform.position = snap ? target :
            Vector3.Lerp(cameraTransform.position, target, 1 - Mathf.Exp(-13 * Time.deltaTime));
        var forward = Quaternion.Euler(0, cameraYaw, 0) * Vector3.forward;
        cameraTransform.LookAt(focus + forward * .32f);
    }
}
