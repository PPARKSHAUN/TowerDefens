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
    public override void OnFire(float damage,Transform target)

    {
        StartCoroutine(Moving(this.transform.position, target.position));
    }

    IEnumerator Moving(Vector3 src, Vector3 dest)
    {
        float dist = Vector3.Distance(src, dest);
        float t = dist / Speed;
        float x = 0.0f;
        while(x<1.0f)
        {

            this.transform.position = Vector3.Lerp(src, dest, x / t);
            x += Time.deltaTime* t;
        }
        this.transform.position = dest;
        yield return null;  
    }
}
