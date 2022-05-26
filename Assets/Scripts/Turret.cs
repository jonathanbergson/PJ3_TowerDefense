using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float range = 15f;

    [SerializeField] private string enemyTag = "inimigo";
    [SerializeField] private Transform engrenagem;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Constants.ENEMY_TAG);
        GameObject enemiyClose = null;
        float distanceToEnemyClose = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < distanceToEnemyClose)
            {
                distanceToEnemyClose = distanceToEnemy;
                enemiyClose = enemy;
            }
        }

        if (enemiyClose != null && distanceToEnemyClose < range)
        {
            target = enemiyClose.transform;
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direcaoParaMirar = target.position - transform.position;
            Quaternion rotacaoNecessariaParaVirar = Quaternion.LookRotation(direcaoParaMirar);
            Vector3 rotacaoParaMirar = Quaternion.Lerp(engrenagem.rotation, rotacaoNecessariaParaVirar, Time.deltaTime * 4).eulerAngles;
            engrenagem.rotation = Quaternion.Euler(0f, rotacaoParaMirar.y, 0f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
