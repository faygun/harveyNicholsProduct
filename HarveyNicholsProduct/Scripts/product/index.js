(function () {
    $('#productForm').submit(function (e) {
        e.preventDefault();

        $('#error').val('');

        var data = {
            style: $('#drpStyle').val(),
            colour: $('#drpColour').val(),
            title: $('#txtTitle').val(),
            price: $('#txtPrice').val(),
            stock: $('#txtStock').val(),
            sku: $('#txtSku').val(),
            __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
        }

        let err = validate(data);
        if (err !== '') {
            $('#error').html(err);
            return;
        }

        addProduct(data);

    });

    function addProduct(data) {
        $.post("/product/create", data, (res) => {
            alert("The product created.")
            clearForm();
        }).fail((err) => {
            $('#error').html(err);
        });
    }

    function validate(data) {
        var message = '';
        if (data.style === '0')
            message = 'Please select Style';
        else if (data.colour === '0')
            message = 'Please select Colour';
        else if (data.sku === '')
            message = 'Please enter Sku';
        else if (data.title === '')
            message = 'Please enter Title';
        else if (isNaN(data.price))
            message = 'Please enter Price';
        else if (isNaN(data.stock) || data.stock < 0)
            message = 'Please enter Stock';

        console.log(isNaN(data.price))

        return message;
    }

    function clearForm() {
        $('#drpStyle').val('0');
        $('#drpColour').val('0');
        $('#txtTitle').val('');
        $('#txtPrice').val('');
        $('#txtStock').val('');
        $('#txtSku').val('');
    }

})()