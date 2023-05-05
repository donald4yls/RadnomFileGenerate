using Microsoft.AspNetCore.Components;
namespace BlazorApp1.Components;

public partial class Demo1
{
    private string? ClassString
    {
        get
        {
            return $"btn {Color} ";
        }
    }

    [Parameter]
    public string? Color { get; set; }

    [Parameter]
    public string? Icon { get; set; }

    [Parameter]
    public string? Text { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object>? AdditionalAttributes { get; set; } 

    private void OnClick()
    {
        System.Console.WriteLine("Hello world.");
    }
}