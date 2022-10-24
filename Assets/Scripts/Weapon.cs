using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        ProcessRaycast();
        PlayMuzzleFlash();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.position, FPCamera.forward, out hit, range))
        {
            CreateHitEffect(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
                target.TakeDamage(damage);
        }
        else
            return;

    }


    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void CreateHitEffect(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }

}
