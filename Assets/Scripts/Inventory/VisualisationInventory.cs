using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VisualisationInventory : MonoBehaviour
{
    private float _changingNumberSlots;
    [SerializeField] private GameObject _grass;
    private List<IMoveGrass> _grassListInInventory = new List<IMoveGrass>();
    private List<IMoveGrass> _grassListToBarn = new List<IMoveGrass>();
    public static bool isTransfer;

    public delegate void TransferGrassInBarn();
    public static event TransferGrassInBarn TransferGrassBar;
    void Start()
    {
        _changingNumberSlots = 1;
        CutWiithSickle.GrassCollected += CreateGrassForInventory;
        PutGrass.GrassPut += TransferGrassInBar;
    }

    private Vector3 SpinePlayer()
    {
        _changingNumberSlots += 0.1f;
        return new Vector3(PointSpine("Spine").position.x, _changingNumberSlots, PointSpine("Spine").position.z);
    }
    private Transform PointSpine(string objTag) => GameObject.FindGameObjectWithTag(objTag).GetComponent<Transform>();
    private void Update()
    {
        MoveAndRotationGrass();
    }
    private void MoveAndRotationGrass()
    {
        foreach (var item in _grassListInInventory)
        {
            item.Position = PointSpine("Spine").position;
            item.MoveGrass();
            item.RotateGrass();
            
        }
        if (_grassListToBarn != null)
        {
            foreach (var item in _grassListToBarn)
            {
                item.MoveGrass();
                item.RotateGrass();
            }
        }
    }
    private void CreateGrassForInventory()
    {
        var grass = Instantiate(_grass, SpinePlayer(), _grass.transform.rotation);
        var igrass = grass.GetComponent<IMoveGrass>();
        igrass.Rotation = PointSpine("Spine");
        _grassListInInventory.Add(igrass);
    }
    private void TransferGrassInBar()
    {
        isTransfer = true;
        StartCoroutine(TransferGrass());
    }
    private IEnumerator TransferGrass()
    {
        while (isTransfer && !Inventory.inventoryIsEmpty)
        {
            _grassListToBarn.Add(_grassListInInventory[_grassListInInventory.Count - 1]);
            _grassListInInventory.RemoveAt(_grassListInInventory.Count - 1);
            var countGrassIsList = _grassListToBarn[_grassListToBarn.Count - 1];
            countGrassIsList.Position = PointSpine("Barn").position;
            countGrassIsList.Rotation = PointSpine("Barn");
            _changingNumberSlots -= 0.1f;
            TransferGrassBar.Invoke();
            Inventory.InfoText.Invoke(this);
            yield return new WaitForSeconds(0.1f);
            countGrassIsList.Destroy();
            _grassListToBarn.RemoveAt(_grassListToBarn.Count - 1);
        }
    }
    private void OnDestroy()
    {
        CutWiithSickle.GrassCollected -= CreateGrassForInventory;
        PutGrass.GrassPut -= TransferGrassInBar;
    }
}
