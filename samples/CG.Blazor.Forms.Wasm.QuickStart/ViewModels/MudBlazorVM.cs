using CG.Blazor.Forms.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CG.Blazor.Forms.Wasm.QuickStart.ViewModels
{
    /// <summary>
    /// This class is a view-model for rendering MudBlazor elements.
    /// </summary>
    [RenderValidationSummary()]
    [RenderDataAnnotationsValidator]
    public class MudBlazorVM
    {
        [RenderMudDatePicker]
        public DateTime? DateOfBirth { get; set; }

        [RenderMudTimePicker]
        public TimeSpan? TimeOfBirth { get; set; }

        [RenderMudTextField]
        [Required]
        public string A1 { get; set; } = "A1 value";

        [RenderMudAutocomplete(SearchFunc = "Search1")]
        public string A2 { get; set; } = "C";

        [RenderMudRadioGroup(Options = "A,B,C,D")]
        public string A3 { get; set; } = "A";

        [RenderMudSelect(Options = "A,B,C,D")]
        public string A4 { get; set; } = "B";


        public string[] _blah = new string[] { "A", "B", "C", "D" };
        public async Task<IEnumerable<string>> Search1(string value)
        {
            // In real life use an asynchronous function for fetching data from an api.
            await Task.Delay(5);

            if (string.IsNullOrEmpty(value))
                return _blah;
            return _blah.Where(x => x.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
