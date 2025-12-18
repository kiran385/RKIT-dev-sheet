$(() => {
    // Function to calculate age based on birth date
    function calculateAge(birthDate) {
        var today = new Date();
        var age = today.getFullYear() - birthDate.getFullYear();
        var m = today.getMonth() - birthDate.getMonth();
        if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
            age--;
        }
        return age;
    };

    // Toggle password visibility
    var changePasswordMode = function (name, iconElement) {
        var editor = $(name).dxTextBox('instance');
        editor.option('mode', editor.option('mode') === 'text' ? 'password' : 'text');

        var newIcon = editor.option('mode') === 'text' ? 'eyeclose' : 'eyeopen';
        $(iconElement).dxButton('instance').option('icon', newIcon);
    };

    // Text box for name
    $('#name').dxTextBox({
        placeholder: 'Enter your full name',
        mode: 'text',
        showClearButton: true,
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'Name is required',
        }],
        validationGroup: "my-form",
    });

    // Text box for email
    $('#email').dxTextBox({
        placeholder: 'Enter your email',
        mode: 'email',
        showClearButton: true
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'Email is required',
        }, {
            type: 'email',
            message: 'Email is invalid',
        }],
        validationGroup: "my-form"
    });

    // Date box for DOB
    $('#dob').dxDateBox({
        placeholder: 'Select DOB',
        type: 'date',
        pickerType: 'calender',
        applyValueMode: 'useButtons',
        applyButtonText: 'Apply',
        cancelButtonText: 'Cancel',
        max: new Date(),
        format: 'dd/MM/yyyy',
        hint: 'Select DOB',
        onValueChanged: function (e) {
            var dob = e.value;
            if (dob) {
                var age = calculateAge(new Date(dob));
                $("#age").dxNumberBox("instance").option("value", age);
            }
        }
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'DOB is required',
        }],
        validationGroup: "my-form"
    });

    // Number box for Age
    $('#age').dxNumberBox({
        //min: 1,
        //max: 50,
        //step: 1,
        //showSpinButtons: true,
        //useLargeSpinButtons: true,
        value: "",
        readOnly: true,
    }).dxValidator({
        validationRules: [{
            type: "custom",
            validationCallback: function (e) {
                return e.value >= 5;
            },
            message: "Student must be at least 5 years old"
        }],
        validationGroup: "my-form"
    });

    // Radio group for gender
    $('#gender').dxRadioGroup({
        items: ['Male', 'Female', 'Other'],
        layout: 'horizontal',
        hint: 'Select gender',
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'Gender is required',
        }],
        validationGroup: "my-form"
    });

    // Select box for city
    $('#city').dxSelectBox({
        items: [{ id: '1', name: 'Ahmedabad' }, { id: '3', name: 'Rajkot' }, { id: '5', name: 'Surat' }, { id: '18', name: 'Gandhinage' }],
        displayExpr: 'name',
        valueExpr: 'id',
        searchEnabled: true
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'City is required',
        }],
        validationGroup: "my-form"
    });

    // Text area for about information
    $('#about').dxTextArea({
        placeholder: 'Write about you',
        autoResizeEnabled: true,
        minHeight: 70
    });

    // File Uploader for profile picture
    $('#profile').dxFileUploader({
        accept: '*',
        uploadMode: 'useButtons',
        showFileList: true,
        uploadUrl: 'https://js.devexpress.com/Demos/NetCore/FileUploader/Upload',
        maxFileSize: 1000000, // 1 MB
        selectButtonText: 'Select profile picture'
    });

    // Text box for password
    $('#password').dxTextBox({
        placeholder: 'Enter password',
        mode: 'text',
        buttons: [{
            name: 'password',
            location: 'after',
            options: {
                icon: 'eyeclose',
                stylingMode: 'text',
                onClick: (e) => changePasswordMode('#password', e.element),
            },
        }],
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'Password is required',
        }],
        validationGroup: "my-form"
    });

    // Text box for confirm password
    $('#confirmPassword').dxTextBox({
        placeholder: 'Confirm password',
        mode: 'password',
        buttons: [{
            name: 'password',
            location: 'after',
            options: {
                icon: 'eyeopen',
                stylingMode: 'text',
                onClick: (e) => changePasswordMode('#confirmPassword', e.element),
            },
        }],
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Confirm Password is required"
        }, {
            type: "compare",
            comparisonTarget: function () {
                return $("#password").dxTextBox("instance").option("value");
            },
            message: "Passwords do not match"
        }],
        validationGroup: "my-form"
    });

    // Check box
    $('#check').dxCheckBox({
        text: 'Accept Terms & Conditions',
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'Accept Terms & Conditions is required',
        }],
        validationGroup: "my-form"
    });

    // Submit Button
    $("#button").dxButton({
        text: 'Register',
        type: 'default',
        onClick: function () {
            // Validate the form
            var result = DevExpress.validationEngine.validateGroup("my-form");
            if (result.isValid) {
                // Collect form data
                var formData = {
                    name: $("#name").dxTextBox("instance").option("value"),
                    email: $("#email").dxTextBox("instance").option("value"),
                    dob: $("#dob").dxDateBox("instance").option("value"),
                    age: $("#age").dxNumberBox("instance").option("value"),
                    gender: $("#gender").dxRadioGroup("instance").option("value"),
                    city: $("#city").dxSelectBox("instance").option("value"),
                    about: $("#about").dxTextArea("instance").option("value"),
                    profile: $("#profile").dxFileUploader("instance").option("value"),
                    password: $("#password").dxTextBox("instance").option("value"),
                    confirmPassword: $("#confirmPassword").dxTextBox("instance").option("value"),
                    check: $("#check").dxCheckBox("instance").option("value"),
                };

                // Log form data to console (for debugging or further processing)
                console.log(formData);

                // Notify the user of successful form submission
                DevExpress.ui.notify("Form Submitted Successfully!", "success", 3000);

                // Get existing data
                let existing = sessionStorage.getItem("studentData");

                // Convert to array or create new empty array
                existing = existing ? JSON.parse(existing) : [];

                // Add new form data
                existing.push(formData);

                // Save back to sessionStorage
                sessionStorage.setItem("studentData", JSON.stringify(existing));
            }
            else {
                debugger;
                result.brokenRules[0].validator.foucs();
            }
        }
    });
});