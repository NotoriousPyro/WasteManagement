using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;

namespace WasteManagement.Products;

internal class WasteDepletedData : IModData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        registrator.LooseProductProtoBuilder()
            .Start("Waste (depleted)", WasteManagementIds.Products.WasteDepleted)
                .SetSourceProduct(Ids.Products.Waste, 1)
                .SetIsStorable(true)
                .SetCanBeDiscarded(false)
                .DumpByDefault()
                .SetIsWaste(false)
                .SetColor(ColorRgba.Brown)
                .SetPrefabPath(Assets.Base.Transports.ConveyorLoose.PileRough_prefab)
                .SetPileTextures(Assets.Base.Products.Loose.Landfill_mat, useRoughPileMeshes: true)
                .SetCustomIconPath(Assets.Base.Products.Icons.Waste_svg)
            .BuildAndAdd();
    }
}
