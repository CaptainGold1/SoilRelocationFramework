using RimWorld;
using Verse;

namespace SR.ToggleablePatches;

internal class ReBuildDoorsAndCorners
{
    [ToggleablePatch]
    internal static readonly ToggleablePatchGroup GlassUsesSandPatch = new()
    {
        Name = "ReBuild: Doors and Corners Glass Uses Sand",
        Enabled = SoilRelocationSettings.ReBuildDoorsAndCornersGlassUsesSandEnabled,
        Patches =
        [
            new ToggleablePatch<RecipeDef>
            {
                Name = "ReBuild: Doors and Corners Glass Uses Sand",
                TargetDefName = "RB_Make_GlassFromChunks",
                TargetModID = "ReBuild.COTR.DoorsAndCorners",
                Patch = delegate(ToggleablePatch<RecipeDef> patch, RecipeDef def)
                {
                    patch.State = def.fixedIngredientFilter;
                    def.label = "make glass from sand";
                    def.description = "Refine sand into basic glass.";
                    def.fixedIngredientFilter = new ThingFilter();
                    def.fixedIngredientFilter.SetAllow(SoilDefs.SR_Sand, true);
                    def.ingredients.Clear();
                    var ingredientCount2 = new IngredientCount
                    {
                        filter = def.fixedIngredientFilter
                    };
                    ingredientCount2.SetBaseCount(20f);
                    def.ingredients.Add(ingredientCount2);
                },
                Unpatch = delegate(ToggleablePatch<RecipeDef> patch, RecipeDef def)
                {
                    def.fixedIngredientFilter = (ThingFilter)patch.State;
                }
            },
            new ToggleablePatch<RecipeDef>
            {
                Name = "ReBuild: Doors and Corners Ballistic Glass Uses Sand",
                TargetDefName = "RB_Make_BallisticGlassFromChunks",
                TargetModID = "ReBuild.COTR.DoorsAndCorners",
                Patch = delegate(ToggleablePatch<RecipeDef> patch, RecipeDef def)
                {
                    patch.State = def.fixedIngredientFilter;
                    def.description = "Refine sand and plasteel into ballistic glass.";
                    def.fixedIngredientFilter = new ThingFilter();
                    def.fixedIngredientFilter.SetAllow(SoilDefs.SR_Sand, true);
                    def.fixedIngredientFilter.SetAllow(ThingDefOf.Plasteel, true);
                    def.ingredients.Clear();
                    var ingredientCountSand = new IngredientCount();
                    ingredientCountSand.filter.SetAllow(SoilDefs.SR_Sand, true);
                    ingredientCountSand.SetBaseCount(20f);

                    var ingredientCountPlasteel = new IngredientCount();
                    ingredientCountPlasteel.filter.SetAllow(ThingDefOf.Plasteel, true);
                    ingredientCountPlasteel.SetBaseCount(5f);

                    def.ingredients.Add(ingredientCountSand);
                    def.ingredients.Add(ingredientCountPlasteel);
                },
                Unpatch = delegate(ToggleablePatch<RecipeDef> patch, RecipeDef def)
                {
                    def.fixedIngredientFilter = (ThingFilter)patch.State;
                }
            }
        ]
    };
}