using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage = 1;
    public float fireRate;
    private ParticleSystem particleSystem;
   
    private List<ParticleCollisionEvent> particleCollisionEvents;
    private bool fireCooldown = false;
    public string muroTag;

    public MuroController muroController;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleCollisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(particleSystem,other,particleCollisionEvents);

        for (int i = 0; i < particleCollisionEvents.Count; i++)
        {
            var collider = particleCollisionEvents[i].colliderComponent;
            if (collider.CompareTag(muroTag))
            {
                muroController.health -= damage;
                muroController.SetHealthText();
                //var Health = collider.GetComponent<HealthController>();
                //Health.ApplyDamage(damage);
            }
        }
    }
    public void Fire()
    {
        if (fireCooldown) return;
        particleSystem.Emit(1);
        fireCooldown = true;
        StartCoroutine(StopCooldownAfterTime());
    }

    private IEnumerator StopCooldownAfterTime()
    {
        yield return new WaitForSeconds(fireRate);
        fireCooldown = false;
    }
}
