using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages;

public partial class C1
{
    [Parameter]
    public string? P1 { get; set; }

    [Parameter]
    public string? Value {get;set; }

    protected override void OnInitialized()
    {
        P1 = "test5";
    }
}