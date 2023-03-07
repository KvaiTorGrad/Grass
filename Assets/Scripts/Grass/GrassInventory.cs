using UnityEngine;
public class GrassInventory : MonoBehaviour,IMoveGrass
{
    private Vector3 _position;
    private Transform _transform;
    public Vector3 Position { get => _position; set => _position = value; }
    public Transform Rotation { get => _transform; set => _transform = value; }
    public void MoveGrass()
    {
        var goToPos = new Vector3(Position.x, transform.position.y, Position.z);
        transform.position = Vector3.MoveTowards(transform.position, goToPos, 0.3f);
    }
    public void RotateGrass()
    {
        transform.localRotation = Rotation.rotation;
    }
    public void Destroy()
    {
        Money.createMoney.Invoke(transform);
        Destroy(gameObject);
    }
}
