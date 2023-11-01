using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType_01 : BaseClass
{
    public override void Init()
    {
        base.Init();
    }

    //optional
    public override void Update()
    {
        base.Update();  //runs the method from the base class
        //custom code may be added HERE
    }


    public override void Damage()
    {
        //Notice that we have the option to create custom code HERE...
        //within the deriving class's abstract override method.
        //What should damage be like here?
    }
    
}
