using UnityEngine;

public interface IPushable
{
    void Push(Transform pusher);
    void ApplyPushForce(Vector3 force);
    Vector3 PushVelocity();
}
