using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShieldObject : ScriptableObject, IShieldObject
{
    [SerializeField] private Sprite Down = null;
    public Sprite down => Down;

    [SerializeField] private Sprite Down_Left = null;
    public Sprite down_left => Down_Left;

    [SerializeField] private Sprite Left = null;
    public Sprite left => Left;

    [SerializeField] private Sprite Up_Left = null;
    public Sprite up_left => Up_Left;

    [SerializeField] private Sprite Up = null;
    public Sprite up=> Up;

    [SerializeField] private Sprite Up_Right = null;
    public Sprite up_right => Up_Right;

    [SerializeField] private Sprite Right = null;
    public Sprite right => Right;

    [SerializeField] private Sprite Down_Right = null;
    public Sprite down_right => Down_Right;


   
    [SerializeField] private Sprite Defend_Down = null;
    public Sprite defend_down => Defend_Down;

    [SerializeField] private Sprite Defend_Down_Left = null;
    public Sprite defend_down_left => Defend_Down_Left;

    [SerializeField] private Sprite Defend_Left = null;
    public Sprite defend_left => Defend_Left;

    [SerializeField] private Sprite Defend_Up_Left = null;
    public Sprite defend_up_left => Defend_Up_Left;

    [SerializeField] private Sprite Defend_Up = null;
    public Sprite defend_up => Defend_Up;

    [SerializeField] private Sprite Defend_Up_Right = null;
    public Sprite defend_up_right => Defend_Up_Right;

    [SerializeField] private Sprite Defend_Right = null;
    public Sprite defend_right => Defend_Right;

    [SerializeField] private Sprite Defend_Down_Right = null;
    public Sprite defend_down_right => Defend_Down_Right;
    public abstract void Ability();
}

