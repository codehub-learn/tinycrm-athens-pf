// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let successAlert = $('.js-success-alert');
successAlert.hide();

let failedAlert = $('.js-fail-alert');
failedAlert.hide();

let button = $('.js-button');

button.on('click', () => {
    let form = $('.js-customer-edit-form');

    if (!form.valid()) {
        return;
    }

    successAlert.hide();
    failedAlert.hide();

    let firstname = $('.js-firstname');
    let lastname = $('.js-lastname');
    let vatnumber = $('.js-vatnumber');

    let data = {
        firstName: firstname.val(),
        lastname: lastname.val(),
        vatnumber: vatnumber.val()
    };

    $.ajax({
        type: 'POST',
        url: '/customer',
        contentType: 'application/json',
        data: JSON.stringify(data)
    }).done(customer => {
        successAlert.html(`Customer ${customer.firstname} ${customer.lastname} with id ${customer.customerId} was created`);
        successAlert.show();
    }).fail(failureResponse => {
        failedAlert.show();
    });
});

