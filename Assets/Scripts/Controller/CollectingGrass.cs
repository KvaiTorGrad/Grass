using UnityEngine;

public class CollectingGrass : Character
{
    [SerializeField] private GameObject Sickle;

    private void Start()
    {
        Sickle.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Grass"))
            SliceGrass();
    }
    private void SliceGrass()
    {
        Sickle.SetActive(true);
        Animator.SetTrigger("isMowing");
    }

    public void Collecting()
    {
        Sickle.SetActive(false);
    }
}
