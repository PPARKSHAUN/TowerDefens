using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject effectSource;
    bool Move = false;
    float Speed = 10.0f;
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
                OnAttack(hit.point);
            }

            this.transform.Translate(this.transform.forward * Speed * Time.deltaTime, Space.World);
        }
    }

    public void OnFire()
    {
        Move = true;
    }
    void OnAttack(Vector3 hitpos)
    {
        Instantiate(effectSource, hitpos, Quaternion.identity);
        Destroy(this.gameObject);
    }
    
}
