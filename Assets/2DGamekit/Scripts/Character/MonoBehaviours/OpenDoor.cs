using Gamekit2D;
using System;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class OpenDoor : MonoBehaviour
{
    [SerializeField] private InventoryController _inventoryController;
    [SerializeField] private string _key;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _inventoryController.GetInventoryEvent(_key).OnAdd.AddListener(OnKeyGot);
    }

    private void OnKeyGot()
    {
        _animator.SetTrigger("Open");
    }
}

