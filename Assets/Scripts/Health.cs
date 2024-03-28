using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private MedKit _medKitPrefab;

    private float _hpCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MedKit>(out MedKit medKit))
            TakedMedKit();
    }

    private void OnEnable()
    {
        _medKitPrefab.Taked += TakedMedKit;
    }

    private void OnDisable()
    {
        _medKitPrefab.Taked -= TakedMedKit;
    }

    private void TakedMedKit()
    {
        _hpCount++;
        Debug.Log(_hpCount);
    }
}
