using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade2 : Upgrade
{

    public override void Click()
    {
        if (!(clickScript.score >= price)) return;

    }

}
