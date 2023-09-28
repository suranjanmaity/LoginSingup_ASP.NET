var accId;
function edit(id) {
    accId = id;
    let err = [false, false, false, false, false];
    //console.log(accId);
    // for range in partial view
    $('#sal-range_' + accId).change(function () {
        let sal_value = parseInt($('#sal-range_' + accId).val()) / 1000;
        sal_value = sal_value + "K";
        $('#sal-value_' + accId).text(sal_value);
        buttonEnable();
    });
    $('#Male_'+accId+
        ',#Female_'+accId+
        ',#Music_'+accId+
        ',#Sports_'+accId+
        ',#Travel_'+accId+
        ',#Movies_' + accId+
        ',#SourceOfIncome_' + accId).change(function () {
            buttonEnable();
        })
    //for disabling submit button
    $("#submit_" + accId).prop("disabled", true);

    $("#Bio_" + accId).keyup(function () {
        validateBio();
        buttonEnable();
    });
    $("#Age_" + accId).keyup(function () {
        validateAge();
        buttonEnable();
    });
    $("#Email_" + accId).keyup(function () {
        validateEmail();
        buttonEnable();
    });
    $("#FirstName_" + accId).keyup(function () {
        validateFirstName();
        buttonEnable();
    });
    $("#LastName_" + accId).keyup(function () {
        validateLastName();
        buttonEnable();
    });
    function validateBio() {
        let bio = $("#Bio_" + accId).val();
        if (bio.length > 200) {
            err[4] = true;
            $("#errBio_" + accId).text("Maximum 200 characters.");
        }
        else {
            err[4] = false;
            $("#errBio_" + accId).text("");
        }
    }
    function validateAge() {
        let Age = $("#Age_" + accId).val();
        if (Age > 100) {
            err[3] = true;
            $("#errAge_" + accId).text("Maximum 100 years");
        }
        else if (Age < 18) {
            err[3] = true;
            $("#errAge_" + accId).text("Minimum 18 years");
            $("#Age_" + accId).val(18);
        }
        else {
            err[3] = false;
            $("#errAge_" + accId).text("");
        }
    }
    function validateEmail() {
        let email = $("#Email_" + accId).val();
        let pattern = /^[\w\.-]+@[\da-zA-Z\.-]+\.[a-zA-Z]{2,}([a-zA-Z]{2,})?$/;
        if (email.length == 0) {
            err[2] = true;
            $("#errEmail_" + accId).text("Required");
        }
        else if (!pattern.test(email)) {
            err[2] = true;
            $("#errEmail_" + accId).text("Invalid Email. Please use a valid one.");
        }
        else {
            err[2] = false;
            $("#errEmail_" + accId).text("");
        }
    }
    function validateFirstName() {
        let name = $("#FirstName_" + accId).val();
        let pattern = /^[a-zA-Z]+$/;
        if (name.length == 0) {
            err[0] = true;
            $("#errFirstName_" + accId).text("Required");
        }
        else if (!pattern.test(name)) {
            err[0] = true;
            $("#errFirstName_" + accId).text("Use Alphabets only");
        }
        else if (name.length > 20) {
            err[0] = true;
            $("#errFirstName_" + accId).text("Max 20 characters");
        }
        else {
            err[0] = false;
            $("#errFirstName_" + accId).text("");
        }
    }
    
    function validateLastName() {
        let name = $("#LastName_" + accId).val();
        let pattern = /^[a-zA-Z]+$/;
        if (name == '') {
            err[1] = true;
            $("#errLastName_" + accId).text("");
        }
        else if (!pattern.test(name)) {
            err[1] = true;
            $("#errLastName_" + accId).text("Use Alphabets only");
        }
        else if (name.length > 20) {
            err[1] = true;
            $("#errLastName_" + accId).text("Max 20 characters");
        }
        else {
            err[1] = false;
            $("#errLastName_" + accId).text("");
        }
    }
    function buttonEnable() {
        
        let valid = 0;
        jQuery.each(err,function(i, e) {
            //console.log(e); for debugging
            if (e) {
                valid = 1;
                
            };
        });
        if (valid!=1) {
            $("#submit_" + accId).prop("disabled", false);
        }
        else {
            $("#submit_" + accId).prop("disabled", true);
        }
    }
}