using Mafi.Base;
using MachineID = Mafi.Core.Factory.Machines.MachineProto.ID;

namespace WasteManagement;

public partial class WasteManagementIds
{
    public partial class Machines
    {
        public static readonly MachineID IncinerationPlant = Ids.Machines.CreateId("IncinerationPlant");
        public static readonly MachineID WasteRecoveryPlant = Ids.Machines.CreateId("WasteRecoveryPlant");
    }
}