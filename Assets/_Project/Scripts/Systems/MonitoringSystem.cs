using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine.UI;

namespace _Project.Scripts {
    public class MonitoringSystem : JobComponentSystem {
        private ComponentGroup uiGroup;

        [BurstCompile]
        private struct MonitoringJob : IJobProcessComponentData<SimulationData, MonitoringData> {
            public void Execute(ref SimulationData simulation, ref MonitoringData monitoringData) {
                monitoringData.fps = (int) (1f / simulation.deltaTime);
            }
        }

        protected override void OnCreateManager() {
            EntityManager em = World.Active.GetOrCreateManager<EntityManager>();
            uiGroup = GetComponentGroup(
                typeof(Text),
                typeof(MonitoringData)
            );
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps) {
            var textComponents = uiGroup.GetComponentArray<Text>();
            var textData = uiGroup.GetComponentDataArray<MonitoringData>();
            for (var i = 0; i < textComponents.Length; i++) {
                textComponents[i].text = textData[i].fps.ToString();
            }

            return new MonitoringJob().Schedule(this, inputDeps);
        }
    }
}