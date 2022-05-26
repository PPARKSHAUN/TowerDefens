using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnFire(float Damage, Transform target)
    {
        this.Damage = Damage;
        StartCoroutine(Moving(this.transform.position, target.position));
    }

    IEnumerator Moving(Vector3 src, Vector3 dest)
    {
        float dist = Vector3.Distance(src, dest);
        float s = 1.0f/(dist / Speed);
        float t = 0.0f;
        while(t < 1.0f)
        {            
            Vector3 pos = Vector3.Lerp(src, dest, t);
            pos.y += Mathf.Sin(t * Mathf.PI) * dist;
            this.transform.position = pos;
            t += Time.deltaTime * s;
            yield return null;
        }
        this.transform.position = dest;
        //ÆøÆÄ!
        Instantiate(effectSource, dest, Quaternion.identity);

        Collider[] monsters = Physics.OverlapSphere(dest, 1.0f, 1 << LayerMask.NameToLayer("Monster"));
        foreach(Collider mon in monsters)
        {
            mon.GetComponent<Monster>()?.OnDamage(Damage);
        }

        Destroy(this.gameObject);
    }
}
