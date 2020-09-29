using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 interface IShieldObject 
{
    Sprite down{ get;}
    Sprite down_left{ get;}
    Sprite left{ get;}
    Sprite up_left{ get;}
    Sprite up{ get;}
    Sprite up_right{ get;}
    Sprite right{ get;}
    Sprite down_right{ get;}

    Sprite defend_down{ get;}
    Sprite defend_down_left{ get;}
    Sprite defend_left{ get;}
    Sprite defend_up_left{ get;}
    Sprite defend_up{ get;}
    Sprite defend_up_right{ get;}
    Sprite defend_right{ get;}
    Sprite defend_down_right{ get;}
    void Ability();
}
