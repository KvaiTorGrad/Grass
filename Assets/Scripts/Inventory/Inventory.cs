using UnityEngine;
using TMPro;
using System;

public class Inventory : MonoBehaviour
{
   [SerializeField] private int _grassCount;
    private int _maxInventorySlots;
    private int _minInventorySlots;
    [SerializeField] private TMP_Text _inventoryText;
    public static bool inventoryIsFull;
    public static bool inventoryIsEmpty;
    public static Action<object> InfoText;
    void Start()
    {
        inventoryIsEmpty = true;
        _maxInventorySlots = 40;
        _minInventorySlots = 0;
        CutWiithSickle.GrassCollected += AddGrassInInventory;
        VisualisationInventory.TransferGrassBar += RemoveGrassInventory;
        InfoText += UpdateTextInventory;
        InfoText.Invoke(this);
    }
    private void AddGrassInInventory()
    {
        _grassCount++;
        inventoryIsEmpty = false;
        if (IsFull())
            inventoryIsFull = true;
    }
    private void RemoveGrassInventory()
    {
        _grassCount--;
        if (IsEmpty())
            inventoryIsEmpty = true;
        inventoryIsFull = false;
    }
    private void UpdateTextInventory(object obj)
    {
        _inventoryText.text = $"{_grassCount}/{_maxInventorySlots}";
    }
    private bool IsFull() => _grassCount == _maxInventorySlots? true : false;
    private bool IsEmpty() => _grassCount == _minInventorySlots ? true : false;
    private void OnDestroy()
    {
        CutWiithSickle.GrassCollected -= AddGrassInInventory;
        VisualisationInventory.TransferGrassBar -= RemoveGrassInventory;
        InfoText -= UpdateTextInventory;
    }
    
}
