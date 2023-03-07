using UnityEngine;

public interface IMoveGrass 
{
    public Vector3 Position { get; set; }
    public Transform Rotation { get; set; }
    public void Destroy();
    public void MoveGrass();
    public void RotateGrass();
}
