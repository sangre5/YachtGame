using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Jobs;

//Systems inherit from ComponentSystem in ECS instead of MonoBehaviour
public class PlayerMovementSystem : JobComponentSystem {
    
    //we need Position and PlayerInput to move the player
    public struct PlayerInputJob : IJobProcessComponentData<Position, PlayerInput>
    {
        public float dt;

        public void Execute(ref Position position, ref PlayerInput playerInput)
        {
            position.Value.x += playerInput.Horizontal * 5 * dt;
            position.Value.y += playerInput.Vertical * 5 * dt;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new PlayerInputJob
        {
            dt = Time.deltaTime,
        };

        return job.Schedule(this, 1, inputDeps);
    }
}
