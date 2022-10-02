using Mafi.Base;
using Mafi.Core.Research;
using ResNodeID = Mafi.Core.Research.ResearchNodeProto.ID;

namespace WasteManagement;


public partial class WasteManagementIds
{
    public partial class Research
    {
        public static readonly ResNodeID UnlockIncinerationPlant = Ids.Research.CreateId("UnlockIncinerationPlant");
        public static readonly ResNodeID UnlockWasteRecoveryPlant = Ids.Research.CreateId("UnlockWasteRecoveryPlant");
    }
}