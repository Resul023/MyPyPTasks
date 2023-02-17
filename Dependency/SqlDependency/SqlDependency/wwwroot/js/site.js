var connection = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();

$(function () {
    connection.start().then(function () {
        alert('Connect');
        InvokeProducts();
    }).catch(function (err) {
        return console.error(err.toString());
    })
})

function InvokeProducts()
    {
    connection.invoke("ReceivedProducts").catch(function (err) {
        return console.log(err.toString());
    })
}
connection.on("ReceivedProducts", function(productViewModel) {
    BindProductToHtml(productViewModel.products);
    BindTime(productViewModel.dateTime);
})

function BindProductToHtml(products) {
    $('#table-id').empty();
    var tr;
    $.each(products, function (index, product) {
        tr = $('<tr/>');
        tr.append(`<td>${index}</td>`);
        tr.append(`<td>${product.name}</td>`);
        tr.append(`<td>${product.price}</td>`);
        tr.append(`<td>${product.category}</td>`);
        $('#table-id').append(tr);
    })
}
function BindTime(time) {
    $('#date-id').html(time)
}