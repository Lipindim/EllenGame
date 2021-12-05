using UnityEngine;


public class Drop : MonoBehaviour
{
    [SerializeField] private GameObject _drop;

    private void OnDisable()
    {
        if (_drop != null)
            _drop.SetActive(true);
    }

    private void Update()
    {
        _drop.transform.localPosition = transform.localPosition;
    }
}

