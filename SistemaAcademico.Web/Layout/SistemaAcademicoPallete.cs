using MudBlazor;
using MudBlazor.Utilities;

namespace SistemaAcademico.Web.Layout
{
    public class SistemaAcademicoPallete : PaletteDark
    {
        private SistemaAcademicoPallete()
        {
            Primary = new MudColor("#f7f8");
            Secondary = new MudColor("#F6AD31");
            Tertiary = new MudColor("#8AE491");
            
            
        }

        public static SistemaAcademicoPallete CreatePallete => new();
    }
}
