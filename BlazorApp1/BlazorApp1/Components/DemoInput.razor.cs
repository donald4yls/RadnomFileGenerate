using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Components
{
    public partial class DemoInput
    {
        [Parameter]
        public string? Value { get; set; }

        [Parameter]
        public EventCallback<string?> ValueChanged { get; set; }

        private string? ValueString
        {
            get { return Value; }
            set
            {
                Value = value;
                if (ValueChanged.HasDelegate)
                {
                    ValueChanged.InvokeAsync(value);
                }
            }
        }

    }
}