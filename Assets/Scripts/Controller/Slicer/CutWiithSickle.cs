using UnityEngine;

public class CutWiithSickle : MonoBehaviour
{
    public delegate void GrassIsCollected();
    public static event GrassIsCollected GrassCollected;
    private void OnTriggerEnter(Collider other)
    {
            var grass = other.GetComponent<GrassGrowth>();
        if (grass.CanBeCut && !Inventory.inventoryIsFull)
        {
            var SliceSize = grass.GrassScale(-2);
            var newScaleGrass = grass.GetComponent<Transform>().localScale = SliceSize;
            grass.StartGrassGrowth();
            grass.Particle.Play();
            GrassCollected.Invoke();
            Inventory.InfoText.Invoke(this);

        }
    }

}
