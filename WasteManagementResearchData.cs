using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Research;

namespace WasteManagement;

internal class WasteManagementResearchData : IResearchNodesData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        ResearchNodeProto nodeProto = registrator.ResearchNodeProtoBuilder
            .Start("Incineration Plant", WasteManagementIds.Research.UnlockIncinerationPlant)
            .Description("Research a more efficient, yet still polluting way of destroying waste.")
            .AddMachineToUnlock(WasteManagementIds.Machines.IncinerationPlant)
            .AddAllRecipesOfMachineToUnlock(WasteManagementIds.Machines.IncinerationPlant)
            .SetCosts(ResearchCostsTpl.Build.SetDifficulty(20))
            .SetGridPosition(new Vector2i(76, 31))
            .AddParents(registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.ExhaustFiltration))
            .BuildAndAdd();
    }
}
