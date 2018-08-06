using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Jobs;

//JobComponentSystem vs ComponentSystem
//Read the input 
public class PlayerInputSystem : JobComponentSystem {

    public struct PlayerInputJob : IJobProcessComponentData<PlayerInput>
    {
        public float Horizontal;
        public float Vertical;

        //loop through all the entities that have the PlayerInput Component
        public void Execute(ref PlayerInput input)
        {
            input.Horizontal = Horizontal;
            input.Vertical = Vertical;
        }
    }

    //prepare the data for the Job
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var jobs = new PlayerInputJob
        {
            Horizontal = Input.GetAxis("Horizontal"),
            Vertical = Input.GetAxis("Vertical")
        };

        //the 1 is the job size, bigger for little jobs
        return jobs.Schedule(this, 1, inputDeps);
    }

}
