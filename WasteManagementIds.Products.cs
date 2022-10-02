using Mafi.Base;
using ProductID = Mafi.Core.Products.ProductProto.ID;

namespace WasteManagement;

public partial class WasteManagementIds
{
    public static class Products
    {
        //[LooseProduct("Assets/Base/Products/Loose/Landfill.mat", false, "Assets/Base/Products/Icons/Waste.svg", true, false, false, -1, false, false, null, null, 1)]
        public static readonly ProductID WasteDepleted = Ids.Products.CreateId("WasteDepleted");
    }
}