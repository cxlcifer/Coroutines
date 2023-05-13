using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _time;
    public List<GameObject> _cubes = new List<GameObject>();

    
    void Start()
    {
        StartCoroutine(SpawnCubes());
    }
    
    void Update()
    {
    }

    private IEnumerator SpawnCubes()
    {
        var position = _startPosition.position;
        for (int i = 1; i <= 20; i++)
        {
            for (int j = 1; j <= 20; j++)
            {
                _cubes.Add(Instantiate(_prefab, _startPosition.position, Quaternion.identity));
                yield return new WaitForSeconds(_time);
                _startPosition.position += new Vector3(1,0,0);
            }

            _startPosition.position = position;
            _startPosition.position += new Vector3(0, -i, 0);
        }
    }
}