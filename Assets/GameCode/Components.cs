using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct PlayerInput : IComponentData
{
    public float Horizontal;
    public float Vertical;
}

//If we want something to jump we add the Jump component to the entity.
public struct Jump : IComponentData { }

public struct Fire : IComponentData { }