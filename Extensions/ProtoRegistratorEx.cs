using Mafi.Core.Mods;

public static class ProtoRegistratorEx
{
    public static LooseProductProtoBuilder LooseProductProtoBuilder(this ProtoRegistrator registrator) => new LooseProductProtoBuilder(registrator);
}
