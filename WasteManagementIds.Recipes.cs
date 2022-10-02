using Mafi.Base;
using RecipeID = Mafi.Core.Factory.Recipes.RecipeProto.ID;

namespace WasteManagement;

public partial class WasteManagementIds
{
    public partial class Recipes
    {
        public static readonly RecipeID LandfillIncineration = Ids.Recipes.CreateId("LandfillIncineration");
        public static readonly RecipeID LandfillDepletedIncineration = Ids.Recipes.CreateId("LandfillDepletedIncineration");
        public static readonly RecipeID BiomassIncineration = Ids.Recipes.CreateId("BiomassIncineration");
        public static readonly RecipeID AnimalFeedIncineration = Ids.Recipes.CreateId("AnimalFeedIncineration");
        public static readonly RecipeID MeatTrimmingsIncineration = Ids.Recipes.CreateId("MeatTrimmingsIncineration");
        public static readonly RecipeID SulfurIncineration = Ids.Recipes.CreateId("SulfurIncineration");
        public static readonly RecipeID SludgeIncineration = Ids.Recipes.CreateId("SludgeIncineration");
        public static readonly RecipeID WasteRecovery = Ids.Recipes.CreateId("WasteRecovery");
    }
}