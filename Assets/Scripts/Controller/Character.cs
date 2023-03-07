using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float Speed { get => _speed; set => _speed = value; }
    private FloatingJoystick _floatingJoystick;
    public FloatingJoystick FloatingJoystick { get => _floatingJoystick; set => _floatingJoystick = value; }
    private Rigidbody _rb;
    public Rigidbody Rb { get => _rb; set => _rb = value; }
    private Animator _animator;
    public Animator Animator { get => _animator; set => _animator = value; }
    protected virtual void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
        FloatingJoystick = FindObjectOfType<FloatingJoystick>();
        Speed = 5f;
    }
}
