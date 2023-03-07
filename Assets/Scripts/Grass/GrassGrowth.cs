using System.Collections;
using UnityEngine;

public class GrassGrowth : MonoBehaviour
{
    private bool _canBeCut;
    private ParticleSystem _particle;
    public ParticleSystem Particle { get => _particle; set => _particle = value; }
    public bool CanBeCut { get => _canBeCut; set => _canBeCut = value; }
    private int _timeHeight;
    private void Awake()
    {
        Particle = GetComponentInChildren<ParticleSystem>();
    }
    void Start()
    {
        _timeHeight = 10;
        StartGrassGrowth();
    }
    public void StartGrassGrowth()
    {
        if(CompletelyCutGrass())
        StartCoroutine(Height());
    }
    public IEnumerator Height()
    {
        CanBeCut = false;
        yield return new WaitForSeconds(_timeHeight);
        CanBeCut = true;
        transform.localScale = GrassScale(4);
    }
    public Vector3 GrassScale(int y) => new Vector3(transform.localScale.x, transform.localScale.y + y, transform.localScale.z);
    private bool CompletelyCutGrass() => transform.localScale.y <= 0.1f ? true : false;
}
