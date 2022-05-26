using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Move)
        {
            Ray ray = new Ray(this.transform.position, this.transform.forward);
            float delta = Speed * Time.fixedDeltaTime;
            if (Physics.Raycast(ray, out RaycastHit hit, delta, 1 << LayerMask.NameToLayer("Monster")))
            {
                OnAttack(hit.transform.GetComponent<Monster>(),hit.point);
            }

            this.transform.Translate(this.transform.forward * Speed * Time.deltaTime, Space.World);
        }
    }

    public override void OnFire(float damge,Transform target)
    {
        Move = true;
        Damage = damge;
    }
    void OnAttack(Monster mon,Vector3 hitpos)
    {
        if (!mon.IsLive()) return;
        mon?.OnDamage(Damage);
        Instantiate(effectSource, hitpos, Quaternion.identity);
        Destroy(this.gameObject);
    }
    
}
