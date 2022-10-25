using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f;

    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.TakeDamage(damage);
        Debug.Log("bang bang");
    }
}
