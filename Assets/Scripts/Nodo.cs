using UnityEngine;

public class Nodo : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    private Color defaultColor;
    private Renderer rend;

    [SerializeField] private GameObject metralhadora;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = defaultColor;
    }

    void OnMouseDown()
    {
        if(metralhadora != null || BuildManager.instance.cash < BuildManager.instance.torretCost)
        {
            Debug.Log("Impossivel criar metralhadora, pois o Nodo já está ocupado");
            return;
        }

        GameObject metralhadoraAConstruir = BuildManager.instance.GetMetralhadoraAConstruir();
        metralhadora = Instantiate(metralhadoraAConstruir, transform.position, transform.rotation);
        BuildManager.instance.MetralhadoraDecrementCost();
    }
}
