using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject metralhadoraAConstruir;
    [SerializeField] private GameObject metralhadoraPadraoPrefab;

    [SerializeField] public int cash = 300;
    [SerializeField] public int torretCost = 100;
    [SerializeField] public int torretReward = 30;

    public Text cashText;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Mais de uma instancia de BuildManager rodando!");
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        metralhadoraAConstruir = metralhadoraPadraoPrefab;
        CashText();
    }

    // Update is called once per frame
    public GameObject GetMetralhadoraAConstruir()
    {
        return metralhadoraAConstruir;
    }

    private void CashText()
    {
        if (cashText)
        {
            cashText.text = "R$ " + cash;
        }
    }

    public void MetralhadoraDecrementCost()
    {
        cash -= torretCost;
        CashText();
    }

    public void MetralhadoraIncrementReward()
    {
        cash += torretReward;
        CashText();
    }
}
