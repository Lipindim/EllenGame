using Gamekit2D;
using System;
using UnityEngine;


public class JerkUpgrade : MonoBehaviour
{
    [SerializeField] private JerkSettings _jerkSettings;
    [SerializeField] private string _upgradeKey;
    [SerializeField] private InventoryController _inventoryController;

    private void Start()
    {
        _inventoryController.GetInventoryEvent(_upgradeKey).OnAdd.AddListener(OnUpgradeGot);
    }

    private void OnUpgradeGot()
    {
        _jerkSettings.Upgrade();
    }
}

