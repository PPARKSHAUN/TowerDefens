using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICE : Projectile
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
        StartCoroutine(Attacking(target));
        
    }
    IEnumerator Attacking(Transform target)
    {
        while(target != null)
        {
            float delta = Time.deltaTime * Speed; //이동거리
            Vector3 dir = target.position - this.transform.position; // 방향
            if(delta >= dir.magnitude )
            {
                //대상에 도달
                break;

            }
            dir.Normalize();// 방향을 수치화 
            this.transform.Translate(dir * delta , Space.World);//대상도달이아닌경우 이동
            yield return null;
        }
        Instantiate(effectSource, target.position, Quaternion.identity);// 도달후 이펙트 발생 
        if(target != null)
        {
            Collider[] monsters = Physics.OverlapSphere(target.position, 1.0f, 1 << LayerMask.NameToLayer("Monster")); //몬스터 잡아주기
            foreach (Collider mon in monsters)
            {
                mon.GetComponent<Monster>()?.AddDebuff(DeBuffType.SLOW, 1.0f, (float)Damage / 100.0f); // 몬스터에 닿으면 디버프추가 
            }

        }
        
        Destroy(this.gameObject); // 도달후 삭제 
      

    }
}
