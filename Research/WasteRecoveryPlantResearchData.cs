using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Research;

namespace WasteManagement.Research;

internal class WasteRecoveryPlantResearchData : IResearchNodesData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        var incinerationParent = registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(WasteManagementIds.Research.UnlockIncinerationPlant);
        registrator.ResearchNodeProtoBuilder
            .Start("Waste recovery", WasteManagementIds.Research.UnlockWasteRecoveryPlant)
                .Description("People sometimes throw recyclables into general waste. This facility is designed to identify and recover these items using powerful magnets and other techniques.")
                .AddMachineToUnlock(WasteManagementIds.Machines.WasteRecoveryPlant)
                .AddAllRecipesOfMachineToUnlock(WasteManagementIds.Machines.WasteRecoveryPlant)
                .SetCosts(ResearchCostsTpl.Build.SetDifficulty(20))
                .SetGridPosition(incinerationParent.GridPosition + new Vector2i(4, 1))
                .AddParents(incinerationParent)
            .BuildAndAdd();
    }
}
