using UnityEngine;

public class PutGrass : MonoBehaviour
{
    public delegate void GrassIsPut();
    public static event GrassIsPut GrassPut;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Barn") && !Inventory.inventoryIsEmpty)
        {
            GrassPut.Invoke();
            Inventory.InfoText.Invoke(this);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Barn"))
            VisualisationInventory.isTransfer = false;
    }
}
