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
            float delta = Time.deltaTime * Speed; //�̵��Ÿ�
            Vector3 dir = target.position - this.transform.position; // ����
            if(delta >= dir.magnitude )
            {
                //��� ����
                break;

            }
            dir.Normalize();// ������ ��ġȭ 
            this.transform.Translate(dir * delta , Space.World);//��󵵴��̾ƴѰ�� �̵�
            yield return null;
        }
        Instantiate(effectSource, target.position, Quaternion.identity);// ������ ����Ʈ �߻� 
        if(target != null)
        {
            Collider[] monsters = Physics.OverlapSphere(target.position, 1.0f, 1 << LayerMask.NameToLayer("Monster")); //���� ����ֱ�
            foreach (Collider mon in monsters)
            {
                mon.GetComponent<Monster>()?.AddDebuff(DeBuffType.SLOW, 1.0f, (float)Damage / 100.0f); // ���Ϳ� ������ ������߰� 
            }

        }
        
        Destroy(this.gameObject); // ������ ���� 
      

    }
}
