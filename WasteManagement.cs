using Mafi;
using Mafi.Base;
using Mafi.Core;
using Mafi.Core.Mods;

namespace WasteManagement;

public sealed class WasteManagement : DataOnlyMod
{
    // Name of this mod. It will be eventually shown to the player.
    public override string Name => "WasteManagement mod";

    // Version, currently unused.
    public override int Version => 1;


    // Mod constructor that lists mod dependencies as parameters.
    // This guarantee that all listed mods will be loaded before this mod.
    // It is a good idea to depend on both `Mafi.Core.CoreMod` and `Mafi.Base.BaseMod`.
    public WasteManagement(CoreMod coreMod, BaseMod baseMod) {
        // You can use Log class for logging. These will be written to the log file
        // and can be also displayed in the in-game console with command `also_log_to_console`.
        Log.Info("WasteManagement: constructed");
    }


    public override void RegisterPrototypes(ProtoRegistrator registrator) {
        Log.Info("WasteManagement: registering prototypes");
        registrator.RegisterData<WasteManagementData>();
        registrator.RegisterDataWithInterface<IResearchNodesData>();
    }

}