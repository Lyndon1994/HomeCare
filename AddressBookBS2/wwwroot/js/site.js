// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

setInterval(() => {
    console.log("request check");
    const Http = new XMLHttpRequest();
    const url = '/api/check';
    Http.open("GET", url);
    Http.send();

    Http.onreadystatechange = (e) => {
        if (Http.readyState != 4) {
            return;
        }
        console.log(Http.responseText);
        if (Http.responseText != "") {
            var result = Http.responseText;
            var ids = result.match(/编号：(\d+)/);
            result = result + "\n是否确认（点击确认则fall字段变成0）？";
            if (window.confirm(result)) {
                const xhr = new XMLHttpRequest();
                const url = '/api/check/' + ids[1];
                xhr.open("PUT", url);
                xhr.send();
                xhr.onreadystatechange = (e) => {
                    console.log(xhr.responseText);
                }
            }
        }
    }
}, 30000);
