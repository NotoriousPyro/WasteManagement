using Mafi.Core.Prototypes;
using Mafi.Core.Products;

namespace Mafi.Core.Mods
{
    public class LooseProductProtoBuilder : IProtoBuilder
    {
        public sealed class State : ProductBuilderState<State>
        {
            private readonly ProductProto.ID m_protoId;

            private string m_pileMaterialAssetPath;

            private bool m_dumpByDefault;

            private ColorRgba m_resourcesVizColor;

            private bool m_isFarmable;

            private bool m_useRoughPileMeshes;

            public State(LooseProductProtoBuilder builder, ProductProto.ID id, string name, string translationComment = null)
                : base(builder, id, name, translationComment)
            {
                m_resourcesVizColor = ColorRgba.Empty;
                m_protoId = id;
            }

            [MustUseReturnValue]
            public State SetPileTextures(string pileMaterialAssetPath, bool useRoughPileMeshes)
            {
                m_pileMaterialAssetPath = pileMaterialAssetPath;
                m_useRoughPileMeshes = useRoughPileMeshes;
                return this;
            }

            [MustUseReturnValue]
            public State SetResourceColor(ColorRgba resourcesVizColor)
            {
                m_resourcesVizColor = resourcesVizColor;
                return this;
            }

            [MustUseReturnValue]
            public State DumpByDefault()
            {
                m_dumpByDefault = true;
                return this;
            }

            [MustUseReturnValue]
            public State SetIsFarmable(bool isFarmable = true)
            {
                m_isFarmable = isFarmable;
                return this;
            }

            public LooseProductProto BuildAndAdd()
            {
                LooseProductProto.Gfx gfx = (base.PrefabPath == null) ? LooseProductProto.Gfx.Empty : new LooseProductProto.Gfx(base.PrefabPath, ValueOrThrow(m_pileMaterialAssetPath, "PileMaterialAssetPath"), m_useRoughPileMeshes, m_resourcesVizColor, base.CustomIconPath);
                ProductProto.ID protoId = m_protoId;
                Proto.Str strings = base.Strings;
                LooseProductProto.Gfx gfx2 = gfx;
                return AddToDb(new LooseProductProto(isDumpedOnTerrainByDefault: m_dumpByDefault, isStorable: base.IsStorable, isFarmable: m_isFarmable, graphics: gfx2, isRecyclable: base.IsRecyclable, id: protoId, strings: strings, pinToHomeScreenByDefault: base.PinToHomeScreenByDefault, sourceProduct: base.SourceProduct, sourceProductQuantity: base.SourceProductQuantity));
            }
        }

        public ProtosDb ProtosDb => Registrator.PrototypesDb;

        public ProtoRegistrator Registrator
        {
            get;
        }

        public LooseProductProtoBuilder(ProtoRegistrator registrator)
        {
            Registrator = registrator;
        }

        [MustUseReturnValue]
        public State Start(string name, ProductProto.ID id, string translationComment = null)
        {
            return new State(this, id, name, translationComment);
        }
    }
}
