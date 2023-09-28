var accId;
function edit(id) {
    accId = id;
    var valid = false;
    //console.log(accId);
    // for range in partial view
    $('#sal-range_' + accId).change(function () {
        let sal_value = parseInt($('#sal-range_' + accId).val()) / 1000;
        sal_value = sal_value + "K";
        $('#sal-value_' + accId).text(sal_value);
    });
    //for disabling submit button
    $("#submit_" + accId).prop("disabled", true);

    $("#Bio_" + accId).keyup(function () {
        validateBio();
        buttonEnable();
    });
    function validateBio() {
        let bio = $("#Bio_" + accId).val();
        if (bio.length > 200) {
            $("#errBio_" + accId).text("Maximum 200 characters.");
            valid = false;
        }
        else {
            $("#errBio_" + accId).text("");
            valid = true;
        }
    }
    $("#Age_" + accId).keyup(function () {
        validateAge();
        buttonEnable();
    });
    function validateAge() {
        let Age = $("#Age_" + accId).val();
        if (Age > 100) {
            $("#errAge_" + accId).text("Maximum 100 years");
            valid = false;
        }
        else if (Age < 18) {
            $("#errAge_" + accId).text("Minimum 18 years");
            $("#Age_" + accId).val(18);
            valid = false;
        }
        else {
            $("#errAge_" + accId).text("");
            valid = true;
        }
    }
    $("#Email_" + accId).keyup(function () {
        validateEmail();
        buttonEnable();
    });
    function validateEmail() {
        let email = $("#Email_" + accId).val();
        let pattern = /^[\w\.-]+@[\da-zA-Z\.-]+\.[a-zA-Z]{2,}([a-zA-Z]{2,})?$/;
        if (email.length == 0) {
            $("#errEmail_" + accId).text("Required");
            valid = false;
        }
        else if (!pattern.test(email)) {
            $("#errEmail_" + accId).text("Invalid Email. Please use a valid one.");
            valid = false;
        }
        else {
            $("#errEmail_" + accId).text("");
            valid = true;
        }
    }
    $("#FirstName_" + accId).keyup(function () {
        validateFirstName();
        buttonEnable();
    });
    function validateFirstName() {
        let name = $("#FirstName_" + accId).val();
        let pattern = /^[a-zA-Z]+$/;
        if (name.length == 0) {
            $("#errFirstName_" + accId).text("Required");
            valid = false;
        }
        else if (!pattern.test(name)) {
            $("#errFirstName_" + accId).text("Use Alphabets only");
            valid = false;
        }
        else if (name.length > 20) {
            $("#errFirstName_" + accId).text("Max 20 characters");
            valid = false;
        }
        else {
            $("#errFirstName_" + accId).text("");
            valid = true;
        }
    }
    $("#LastName_" + accId).keyup(function () {
        validateLastName();
        buttonEnable();
    });
    function validateLastName() {
        let name = $("#LastName_" + accId).val();
        let pattern = /^[a-zA-Z]+$/;
        if (name=='') {
            $("#errLastName_" + accId).text("");
            valid = true;
        }
        else if (!pattern.test(name)) {
            $("#errLastName_" + accId).text("Use Alphabets only");
            valid = false;
        }
        else if (name.length > 20) {
            $("#errLastName_" + accId).text("Max 20 characters");
            valid = false;
        }
        else {
            $("#errLastName_" + accId).text("");
            valid = true;
        }
    }
    function buttonEnable() {
        if (valid) {
            $("#submit_" + accId).prop("disabled", false);
        }
        else {
            $("#submit_" + accId).prop("disabled", true);
        }
    }
}