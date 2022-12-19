using Mafi.Base;
using ProductID = Mafi.Core.Products.ProductProto.ID;

namespace WasteManagement;

public partial class WasteManagementIds
{
    public static class Products
    {
        public static readonly ProductID WasteDepleted = Ids.Products.CreateId("WasteDepleted");
    }
}
