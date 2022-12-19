using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Entities;
using Mafi.Core.Factory.Recipes;
using Mafi.Core.Products;
using Mafi.Core.Factory.Machines;

namespace WasteManagement.Machines;

internal class IncinerationPlantData : IModData
{
    private static void registerIncinerationRecipe(
        ProtoRegistrator registrator,
        MachineProto.ID machineId,
        RecipeProto.ID recipeId,
        ProductProto.ID productToBurn,
        ProductProto.ID steamOut,
        int quantity,
        Duration duration,
        int pollution
    ) => registrator.RecipeProtoBuilder
            .Start("Waste incineration", recipeId, machineId)
            .SetProductsDestroyReason(DestroyReason.UsedAsFuel)
            .AddInput(quantity, productToBurn, "Z")
            .AddInput(8, Ids.Products.Water)
            .SetDuration(duration)
            .AddOutput(8, steamOut, "CD")
            .AddOutput(4 * pollution, Ids.Products.Exhaust, "X")
        .BuildAndAdd();

    private static void registerIncinerationPlant(
        ProtoRegistrator registrator,
        MachineProto.ID machineId
    )
    {
        registrator.MachineProtoBuilder
            .Start("Incineration plant", machineId)
            .Description("An inefficient process to destroy waste under high temperatures and capture the exhaust gasses.")
            .SetCost(Costs.Build.CP3(45).Workers(8))
            .SetElectricityConsumption(Mafi.Electricity.FromKw(250))
            .SetCategories(Ids.ToolbarCategories.Waste)
            .SetLayout(
                "      [2][3][3][3][3][9][3]      ",
                " @ >2A[3][3][3][3][3][9][3]      ",
                " @ >2B[3][3][3][3][5][5][5]      ",
                " @ <2C[3][3][3][3][5][5][5]Y1> @ ",
                " @ <2D[3][3][3][3][5][5][5]      ",
                "      [2][3][3]^3Z[3]v3X         ",
                "                ~     @          "
            )
            .AddParticleParams(ParticlesParams.Loop("Smoke", useUtilizationOnAlpha: true))
            .SetPrefabPath(Assets.Base.Machines.MetalWorks.FiltrationStation_prefab)
            .SetMachineSound(Assets.Base.Machines.MetalWorks.FiltrationStation.FiltrationStationSound_prefab)
            .SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<MachineProto>(Ids.Machines.ExhaustScrubber).Graphics.IconPath)
            .BuildAndAdd();
    }

    private static void registerIncinerationRecipes(
        ProtoRegistrator registrator,
        MachineProto.ID machineId
    )
    {
        registerIncinerationRecipe(
            registrator,
            machineId,
            WasteManagementIds.Recipes.LandfillIncineration,
            Ids.Products.Waste,
            Ids.Products.SteamHi,
            12,
            10.Seconds(),
            2
        );
        registerIncinerationRecipe(
            registrator,
            machineId,
            WasteManagementIds.Recipes.LandfillDepletedIncineration,
            WasteManagementIds.Products.WasteDepleted,
            Ids.Products.SteamHi,
            12,
            10.Seconds(),
            2
        );
        registerIncinerationRecipe(
            registrator,
            machineId,
            WasteManagementIds.Recipes.BiomassIncineration,
            Ids.Products.Biomass,
            Ids.Products.SteamHi,
            12,
            10.Seconds(),
            1
        );
        registerIncinerationRecipe(
            registrator,
            machineId,
            WasteManagementIds.Recipes.AnimalFeedIncineration,
            Ids.Products.AnimalFeed,
            Ids.Products.SteamHi,
            12,
            10.Seconds(),
            1
        );
        registerIncinerationRecipe(
            registrator,
            machineId,
            WasteManagementIds.Recipes.MeatTrimmingsIncineration,
            Ids.Products.MeatTrimmings,
            Ids.Products.SteamLo,
            8,
            20.Seconds(),
            2
        );
        registerIncinerationRecipe(
            registrator,
            machineId,
            WasteManagementIds.Recipes.SulfurIncineration,
            Ids.Products.Sulfur,
            Ids.Products.SteamLo,
            4,
            20.Seconds(),
            4
        );
        registerIncinerationRecipe(
            registrator,
            machineId,
            WasteManagementIds.Recipes.SludgeIncineration,
            Ids.Products.Sludge,
            Ids.Products.SteamLo,
            12,
            20.Seconds(),
            3
        );
    }

    public void RegisterData(ProtoRegistrator registrator)
    {
        registerIncinerationPlant(registrator, WasteManagementIds.Machines.IncinerationPlant);
        registerIncinerationRecipes(registrator, WasteManagementIds.Machines.IncinerationPlant);
    }
}
