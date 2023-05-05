function sayHello() {
    alert("hello");
}

window.jsUtils = {
    sayHello: function () {
        alert("jsUtils: Hello");
    }
}

function sayHelloWithArg(person) {
    alert("Hello: " + person.name);
}

//function confirmWithArg(message) {
//    confirm("confirm" + message);
//}

function getToDoItem() {
    return {
        title: "Test Return",
        isDone: false
    };
}

//Not work 
function getCSharpName(){
    var name = DotNet.invokeMethod("BlazorApp1", "getName2");
    alert(name);
}

function getCSharpNameAsync() {
    DotNet.invokeMethodAsync("BlazorApp1", "getName2Async")
        .then(name => {
            alert(name)
        });
}