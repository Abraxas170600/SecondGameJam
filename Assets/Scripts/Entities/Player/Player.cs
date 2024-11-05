using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CapsuleCollider))]
public class Player : Entity, IPushable
{
    [Header("Movement")]
    private Vector3 moveInput;

    [Header("Dependences")]
    private Camera mainCamera;
    private CharacterController characterController;

    [Header("Damage Push")]
    [SerializeField] protected float pushDecayRate;
    private bool isBeingPushed;
    private Vector3 pushVelocity;


    protected override void Start()
    {
        base.Start();
        mainCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
    }
    protected override void Movement()
    {
        characterController.Move(GetInputs());
        PlayerRotation();
    }
    private Vector3 GetInputs()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        return (moveInput * speed) + PushVelocity() * Time.deltaTime;
    }
    private void PlayerRotation()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(cameraRay, out float rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
    public void Push(Transform pusher)
    {
        float pushForce = 10f;

        Vector3 pushDirection = transform.position - pusher.transform.position;
        pushDirection.y = 0;

        ApplyPushForce(pushDirection * pushForce);
    }
    public void ApplyPushForce(Vector3 force)
    {
        pushVelocity = force;
        isBeingPushed = true;
    }
    public Vector3 PushVelocity()
    {
        if (isBeingPushed)
        {
            if (pushVelocity.magnitude < 0.1f)
            {
                isBeingPushed = false;
            }
            return pushVelocity = Vector3.Lerp(pushVelocity, Vector3.zero, pushDecayRate * Time.deltaTime);
        }
        return pushVelocity = Vector3.zero;
    }

    protected override void Defeat()
    {
        Debug.Log("Muelto");
    }
}
