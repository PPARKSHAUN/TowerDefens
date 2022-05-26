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

            this.transform.Translate(this.transform.forward * delta, Space.World);
        }
    }

    public override void OnFire(float damage, Transform target)
    {
        Move = true;
        Damage = damage;
    }

    void OnAttack(Monster mon,Vector3 hitPos)
    {        
        mon?.OnDamage(Damage);
        Instantiate(effectSource, hitPos, Quaternion.identity);
        Destroy(this.gameObject);
    }    
}
