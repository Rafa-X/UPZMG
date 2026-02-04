using Microsoft.AspNetCore.Mvc.Rendering;
using UPZMG.Shared.Enums;
using UPZMG.Shared.Helpers;

namespace UPZMG.Web.Helpers;

/// <summary>
/// Helper class to generate SelectListItems from enums.
/// </summary>

public static class EnumSelectListHelper
{
    public static List<SelectListItem> HighestEducationLevelOptions()
    {
        return Enum.GetValues<HighestEducationLevel>()
            .Where(x => x != HighestEducationLevel.NoEspecificado)
            .Select(x => new SelectListItem
            {
                Value = ((int)x).ToString(),
                Text = x.ToSpanish()
            })
            .ToList();
    }

    public static List<SelectListItem> TitleStatusOptions()
    {
        return Enum.GetValues<TitleStatus>()
            .Where(x => x != TitleStatus.NoEspecificado)
            .Select(x => new SelectListItem
            {
                Value = ((int)x).ToString(),
                Text = x.ToSpanish()
            })
            .ToList();
    }
}



/* how to use in a Razor view:

@using UPZMG.Web.Helpers

<select asp-items="EnumSelectListHelper.StudyGradeLevelOptions()"></select>

*/