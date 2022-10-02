using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Research;

namespace WasteManagement.Research;

internal class ExhaustFiltrationResearchData : IResearchNodesData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        var exhaustParent = registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.ExhaustFiltration);
        registrator.ResearchNodeProtoBuilder
            .Start("Incineration", WasteManagementIds.Research.UnlockIncinerationPlant)
                .Description("Research a more efficient, yet still polluting way of destroying waste.")
                .AddMachineToUnlock(WasteManagementIds.Machines.IncinerationPlant)
                .AddAllRecipesOfMachineToUnlock(WasteManagementIds.Machines.IncinerationPlant)
                .SetCosts(ResearchCostsTpl.Build.SetDifficulty(20))
                .SetGridPosition(exhaustParent.GridPosition + new Vector2i(4, 0))
                .AddParents(exhaustParent)
            .BuildAndAdd();
    }
}
