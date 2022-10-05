using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;


public class RotatorAuthoring : MonoBehaviour
{
    public float RotationSpeed = 1.0f;

    internal class RotatorBaker : Baker<RotatorAuthoring>
    {
        public override void Bake(RotatorAuthoring authoring)
        {
            AddComponent(new Rotator()
            {
                RotatioinSpeed = authoring.RotationSpeed
            });
        }
    }
}

public struct Rotator : IComponentData
{
    public float RotatioinSpeed;
}