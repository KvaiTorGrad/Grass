using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JoystickPlayer : Character
{
    public void FixedUpdate()
    {
        MovePlayer();
        MoveAnimation();
    }
    private void Update()
    {
        RotationPlayer();
    }
    private void MoveAnimation()
    {
        var speedPlayer = Mathf.InverseLerp(0f, Rb.velocity.magnitude, Time.deltaTime);
        Animator.SetFloat("isRuning", speedPlayer);
    }
    private void RotationPlayer()
    {
        transform.LookAt(Direction() + transform.position);
    }
    private void MovePlayer()
    {
        Rb.velocity = Direction() * Speed;
    }
    private Vector3 Direction() => Vector3.forward * FloatingJoystick.Vertical + Vector3.right * FloatingJoystick.Horizontal;
}