using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};
    [System.Serializable]
    public class Wave {
        public string name;
        public GameObject[] enemy;
        public int count;
        public float rate;
    }

    public Transform[] spawnPoints;

    public Wave[] waves;
    private int nextWave = 0;
    private int inc_def = 0;

    public float timeBetweenWaves = 5f;
    private float maxtime = 20;
    public float waveCountdown;
    public int WAVECOUNT = 1;

    public SpawnState state = SpawnState.COUNTING;

    private float searchCountdown = 1f;
    private void Start() {
        waveCountdown = timeBetweenWaves;
    }

    private void Update() {
        if (state == SpawnState.WAITING) {
            if (!EnemyisAlive()) {
                Debug.Log("Wave Done");
                WaveCompleted();
            } 
            else {
                return;
            }
        }
        
        if (waveCountdown <= 0) {
            if (state != SpawnState.SPAWNING) {
                
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else {
            waveCountdown -= Time.deltaTime;
        }
    }

    bool EnemyisAlive() {
        searchCountdown -= Time.deltaTime;
        

        if (searchCountdown <= 0f) {
            maxtime--;
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 || maxtime < 0) {
                maxtime = 20;
                return false;
            }
        }

        return true;
    }

    void WaveCompleted() {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length -1) {
            WAVECOUNT++;
            if (inc_def < 5) {
                inc_def++;
            }
            
            nextWave = 0;
            Debug.Log("ALL WAVES COMPLETE");
        } else {
            WAVECOUNT++;
            nextWave++;
        }
    }

    IEnumerator SpawnWave(Wave _wave) {
        Debug.Log("Spawning Wave");
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count + inc_def; i++) {
            for (int j = 0; j < _wave.enemy.Length; j++) {
                SpawnEnemy (_wave.enemy[j]);
                yield return new WaitForSeconds( 1f/_wave.rate);
            }

            
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy (GameObject _enemy) {
        Transform _sp = spawnPoints[ Random.Range(0, spawnPoints.Length)];
        if (inc_def ==  4) {
            _enemy.GetComponent<death>().Health += 4;
        }
        Instantiate(_enemy, _sp.position, _sp.rotation);
        Debug.Log("Spawning Enemy: " + _enemy.name);
    }
}
