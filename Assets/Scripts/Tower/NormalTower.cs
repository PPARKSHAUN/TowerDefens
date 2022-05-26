using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTower : Tower
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StateProcess();
    }
    
    protected override void OnAttack()
    {
        LookAtTarget();
        playTime += Time.deltaTime;
        if (playTime >= attackDelay)
        {
            playTime = 0.0f;
            OnFire();
        }
    }    
}
