using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace DefaultNamespace
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial struct RotatorSystem: ISystem
    {
        public void OnCreate(ref SystemState state)
        {
        }

        public void OnDestroy(ref SystemState state)
        {
        }

        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            var job = new RotatorJob() { deltaTime = deltaTime };

            job.Schedule();
        }
        
        [BurstCompile]
        private partial struct RotatorJob: IJobEntity
        {
            public float deltaTime;
            public void Execute(ref TransformAspect transform, in Rotator rotator)
            {
                var rotationAmount = quaternion.RotateY(rotator.RotatioinSpeed * deltaTime);
                transform.RotateWorld(rotationAmount);
            }
        }
    }
}