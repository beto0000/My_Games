using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelManager : MonoBehaviour
{

    [SerializeField] public GameObject[] enemies;
    [SerializeField] public GameObject EnemiesGameObject;
    [SerializeField] public int enemiescount = 0, instantiatecount = 1,spawnposition=0,wavecount=1,direciton=1;
   


    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }


    void Update()
    {

    }

    void Spawn(int direction)
    {
        enemiescount++;

        if (enemiescount % 10 == 0)
        {
            instantiatecount++;
            wavecount++;

        }
        for (int i = 0; i < instantiatecount; i++)
        {
            int randomenemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomenemy], new Vector2(direction*29 + spawnposition, 0), Quaternion.identity, EnemiesGameObject.transform);
            spawnposition += 3;
        }
        spawnposition = 0;
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            
            if (direciton==1)
            {
                Spawn(direciton);
                direciton = -1;
               
            }
            else
            {
                Spawn(direciton);
                direciton = 1;
            }
            yield return new WaitForSeconds(5f);
        }


    }
}
