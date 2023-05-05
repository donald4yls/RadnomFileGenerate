using BlazorApp1.Data;
using Microsoft.JSInterop;

namespace BlazorApp1.Pages
{
    public partial class Todo
    {
        private List<TodoItem> todos = new();

        private string? newTodo;

        private void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(newTodo))
            {
                todos.Add(new TodoItem { Title = newTodo });
                newTodo = string.Empty;
            }
        }

        private void SayHello()
        {
            this.JSRuntime.InvokeVoidAsync("sayHello");
        }

        private void JsUtilSayHello()
        {
            this.JSRuntime.InvokeVoidAsync("jsUtils.sayHello");
        }

        private void SayHelloWithArg()
        {
            this.JSRuntime.InvokeVoidAsync("sayHelloWithArg", new {Name="Donald Yu"});
        }

        private async void GetToDoItem()
        {
            var item = await this.JSRuntime.InvokeAsync<TodoItem>("getToDoItem");
            Console.WriteLine(item.Title);
        }

        private async void TestConfirm()
        {
            var result = await this.JSRuntime.InvokeAsync<bool>("confirm", "Test confirm");
            string prompted = await JSRuntime.InvokeAsync<string>("prompt", "Take some input:"); // Prompt
            Console.WriteLine("result>>>" + result);
            Console.WriteLine("prompted>>>" + prompted);
        }


        [JSInvokable]
        private static string GetName()
        {
            return "Donald Yu";
        }

        [JSInvokable("getName2")]
        public static string GetName2()
        {
            return "Donald Yu 222";
        }

        [JSInvokable("getName2Async")]
        public static Task<string> GetNameAsync()
        {
            return Task.FromResult<string>("Donald Yu Async");
        }
    }
}