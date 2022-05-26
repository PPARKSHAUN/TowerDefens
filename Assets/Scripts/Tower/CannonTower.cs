using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : Tower
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
        playTime += Time.deltaTime;
        if (playTime >= attackDelay)
        {
            playTime = 0.0f;
            OnFire(_target.transform);
        }
    }
}
