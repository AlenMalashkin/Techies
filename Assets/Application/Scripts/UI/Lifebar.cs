using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour
{
    [SerializeField] private Image healthPrefab;
    [SerializeField] private int healthByDefault;
   
    private int _health;

    private void Awake()
    {
        _health = healthByDefault;

        FillHealthbar();
    }

    private void FillHealthbar()
    {
        var childCount = transform.childCount;

        if (childCount > 0)
        {
            for (int i = 0; i < childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        
        for (var i = 0; i < _health; i++)
        {
            Instantiate(healthPrefab, transform);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        
        if (_health <= 0)
            Die();
        
        FillHealthbar();
    }

    private void Die()
    {
        Debug.Log("You are died");
        SceneLoader.Instance.ReloadCurrentScene();
    }
}
