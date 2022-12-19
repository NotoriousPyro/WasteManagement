using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Entities;
using Mafi.Core.Factory.Recipes;
using Mafi.Core.Products;
using Mafi.Core.Factory.Machines;
using Mafi.Core.Entities.Animations;
using Mafi.Core.Entities.Static.Layout;

namespace WasteManagement.Machines;

internal class WasteRecoveryPlantData : IModData
{
    private static void registerWasteRecoveryRecipe(
        ProtoRegistrator registrator,
        MachineProto.ID machineId,
        RecipeProto.ID recipeId,
        Duration duration
    ) => registrator.RecipeProtoBuilder
            .Start("Waste incineration", recipeId, machineId)
            .SetProductsDestroyReason(DestroyReason.DumpedOnTerrain)
            .AddInput(8, Ids.Products.Waste, "A")
            .SetDuration(duration)
            .AddOutput(7, WasteManagementIds.Products.WasteDepleted, "X")
            .AddOutput(1, Ids.Products.Recyclables, "Z")
            .AddOutput(1, Ids.Products.Exhaust, "Y")
        .BuildAndAdd();

    private static void registerWasteRecoveryPlant(
        ProtoRegistrator registrator,
        MachineProto.ID machineId
    ) => registrator.MachineProtoBuilder
            .Start("Waste recovery plant", machineId)
            .Description("People sometimes throw recyclables into general waste. This facility is designed to identify and recover these items using intelligent techniques.")
            .SetElectricityConsumption(Mafi.Electricity.FromKw(50))
            .SetCost(Costs.Build.CP3(30).Workers(4))
            .SetCategories(Ids.ToolbarCategories.Waste)
            .SetLayout(new EntityLayoutParams(null, useNewLayoutSyntax: true),
                "   [3][3][3][3][3][3][3][3]   ",
                "   [3][3][3][3][3][3][3][3]>~X",
                "A~>[3][3][3][3][3][3][3][3]>@Y",
                "C@>[3][3][3][3][3][3][3][3]>~Z",
                "   [3][3][3][3][3][3][3][3]   "
            )
            .AddParticleParams(ParticlesParams.Loop("Smoke", useUtilizationOnAlpha: true))
            .SetPrefabPath(Assets.Base.Machines.Food.Mill_prefab)
            .SetMachineSound(Assets.Base.Machines.Food.Mill.MillSound_prefab)
            .SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<MachineProto>(Ids.Machines.FoodMill).Graphics.IconPath)
            .SetAnimationParams(AnimationParams.Loop(60.Percent()))
            .BuildAndAdd();

    private static void registerWasteSortingRecipes(
        ProtoRegistrator registrator,
        MachineProto.ID machineId
    )
    {
        registerWasteRecoveryRecipe(
            registrator,
            machineId,
            WasteManagementIds.Recipes.WasteRecovery,
            20.Seconds()
        );
    }

    public void RegisterData(ProtoRegistrator registrator)
    {
        registerWasteRecoveryPlant(registrator, WasteManagementIds.Machines.WasteRecoveryPlant);
        registerWasteSortingRecipes(registrator, WasteManagementIds.Machines.WasteRecoveryPlant);
    }
}
