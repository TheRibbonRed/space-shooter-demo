using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> AvailableEnemies;
    [SerializeField] private List<GameObject> Spawns;
    private List<int> SpawnedPos = new();
    private bool _stopSpawn, _isCoroutine;

    private void Awake()
    {
        for (int n = 0; n < Spawns.Count; n++) 
        {
            SpawnedPos.Add(n);
        }
    }


    private void Update()
    {
        if (_stopSpawn)
        {
            if (_isCoroutine)
            {
                StopAllCoroutines();
                _isCoroutine = false;
            }
            return;
        }
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        foreach (var enemy in AvailableEnemies.Where(enemy => !enemy.gameObject.activeSelf))
        {
            Transform spawn = SetSpawn();
            enemy.transform.position = spawn.position;
            enemy.gameObject.SetActive(true);
        }
    }

    private Transform SetSpawn()
    {
        try
        {
            SpawnedPos.Sort();
            int random = Random.Range(SpawnedPos[0], SpawnedPos[^1]);
            StartCoroutine(SpawnCooldown(random));
            return Spawns[random].transform;
        }
        catch (System.Exception ex)
        {
            return Spawns[0].transform;
        }
    }

    private IEnumerator SpawnCooldown(int index)
    {
        _isCoroutine = true;
        SpawnedPos.Remove(index);
        yield return new WaitForSeconds(0.5f);
        SpawnedPos.Add(index);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
