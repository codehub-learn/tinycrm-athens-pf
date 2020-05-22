// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function addToBasket(productId, basketId) {
    actionMethod = "POST"
    actionUrl = "/api/addOrderProduct"
    sendData = {
        "productId": productId,
        "orderId": basketId
    }

     alert(JSON.stringify(sendData))

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {

            productName = data["product"]["name"]
            $('#MyBasket').append('<li><a href="#">' + productName + '</a></li>');
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });


}


function addProductToServer() {

    

 actionMethod = "POST"
    actionUrl = "/api/createProduct"
    sendData = {
        "ProductId": $('#ProductId').val(),
        "Description": $('#Description').val(),
        "Name": $('#Name').val(),
        "Price": $('#Price').val()
    }

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            $('#responseDiv').html(JSON.stringify(data));
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });

}

 

function addCustomer() {
    actionMethod = "POST"
    actionUrl = "/api/createCustomer"
    sendData = {
        "FirstName": $('#FirstName').val(),
        "LastName": $('#LastName').val(),
        "Vatnumber": $('#Vatnumber').val() 
    }

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            $('#responseDiv').html(JSON.stringify(data));
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });

}


 