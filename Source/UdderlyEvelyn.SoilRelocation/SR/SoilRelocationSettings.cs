using Verse;

namespace SR;

public class SoilRelocationSettings : ModSettings
{
    public static bool SandbagsUseSandEnabled = true;

    public static bool FungalGravelUsesRawFungusEnabled = true;

    public static bool DubsSkylightsGlassUsesSandEnabled = true;

    public static bool JustGlassGlassUsesSandEnabled = true;

    public static bool GlassPlusLightsGlassUsesSandEnabled = true;

    public static bool VFEArchitectPackedDirtCostsDirtEnabled = true;

    public static bool ReBuildDoorsAndCornersGlassUsesSandEnabled = true;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref SandbagsUseSandEnabled, "SandbagsUseSandEnabled");
        Scribe_Values.Look(ref FungalGravelUsesRawFungusEnabled, "FungalGravelUsesRawFungusEnabled");
        Scribe_Values.Look(ref DubsSkylightsGlassUsesSandEnabled, "DubsSkylightsGlassUsesSandEnabled");
        Scribe_Values.Look(ref JustGlassGlassUsesSandEnabled, "JustGlassGlassUsesSandEnabled");
        Scribe_Values.Look(ref GlassPlusLightsGlassUsesSandEnabled, "GlassPlusLightsGlassUsesSandEnabled");
        Scribe_Values.Look(ref VFEArchitectPackedDirtCostsDirtEnabled, "VFEArchitectPackedDirtCostsDirtEnabled");
        Scribe_Values.Look(ref ReBuildDoorsAndCornersGlassUsesSandEnabled, "ReBuildDoorsAndCornersGlassUsesSandEnabled");
        base.ExposeData();
    }
}