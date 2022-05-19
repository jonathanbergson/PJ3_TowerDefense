using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public GameObject enemie;
    [SerializeField] public Transform target;

    [Header("Wave Settings")]
    [SerializeField] private float countDownWaves;
    [Range(10f, 1f)] [SerializeField] private float timeBetweenWaves = 5f;

    private int[] enemiesWaveRange = { 2, 4, 5, 8 };

    private void Start()
    {
        countDownWaves = timeBetweenWaves;
    }

    void Update()
    {
        if (countDownWaves <= 0f)
        {
            SpwanEnemies();
            countDownWaves = timeBetweenWaves;
        }
        countDownWaves -= Time.deltaTime;
    }

    private void SpwanEnemies()
    {
        int index = Random.Range(0, enemiesWaveRange.Length);
        InstantiateEnemies(enemiesWaveRange[index]);
    }

    private void InstantiateEnemies(int count)
    {
        if (enemie)
        {
            for (int i = 0; i < count; i++)
            {
                Enemie enemieInstance = Instantiate(enemie, transform.position, Quaternion.identity).GetComponent<Enemie>();
                enemieInstance.target = target;
            }
        }
    }
}
