$(() => {
    $('#accessKey').dxTextBox({
        accessKey: 'A',
        placeholder: 'Press ALT + A to focus here'
    });

    $('#activeStateEnabled').dxTextBox({
        activeStateEnabled: true,
        placeholder: 'Click and HOLD to see active highlight'
    });

    $('#buttons').dxTextBox({
        buttons: [{
            name: 'button1',
            location: 'before',
            options: {
                icon: 'eyeopen'
            },
        },
            {
                name: 'button2',
                location: 'before',
                options: {
                    icon: 'eyeclose'
                },
            },
            {
                name: 'button3',
                location: 'after',
                options: {
                    icon: 'clear',
                    hint: 'clear',
                    onClick: function () {
                        $('#buttons').dxTextBox('instance').option('buttons', []);
                    }
                }
            }
        ],
        placeholder: 'Buttons in TextBox'
    });

    $('#disabled').dxTextBox({
        disabled: true,
        placeholder: 'This is disabled TextBox'
    });

    $('#elementAttr').dxTextBox({
        elementAttr: {
            class: 'customCss'
        },
        placeholder: 'This custom CSS given through elementAttr'
    });

    $('#focusStateEnabled').dxTextBox({
        focusStateEnabled: false,
        placeholder: 'This TextBox is not foucused through keyboard navigation'
    });

    $('#height').dxTextBox({
        height: '80px',
        placeholder: 'Custom height given'
    });

    $('#hint').dxTextBox({
        hint: 'This is TextBox',
        placeholder: 'Hover to get hint'
    });

    //If hoverStateEnabled is false then we can explicitly add mouseenter event so it act like hover
    var hover = $('#hoverStateEnabled').dxTextBox({
        hoverStateEnabled: false,
        placeholder: 'Hover state is not working on this TextBox'
    });

    hover.on("mouseenter", function () {
        $(this).addClass("customCss");
    });

    $('#inputAttr').dxTextBox({
        inputAttr: {
            id: 'customId'
        },
        placeholder: 'This custom CSS given through inputAttr'
    });

    $('#isValid').dxTextBox({
        isValid: false,
        placeholder: 'isValid is set to false'
    });

    $('#label').dxTextBox({
        label: 'Enter your name',
        placeholder: 'label is given on this TextBox'
    });

    $('#labelMode').dxTextBox({
        label: 'Enter your name',
        labelMode: 'floating',
        placeholder: 'labelMode floating is given on this TextBox'
    });

    $('#mask').dxTextBox({
        mask: '(000) 000-0000',
    });

    $('#maskChar').dxTextBox({
        mask: '(000) 000-0000',
        maskChar: '*'
    });

    $('#maskInvalidMessage').dxTextBox({
        mask: '(000) 000-0000',
        maskInvalidMessage: 'Enter in correct format'
    });

    $('#maskRules').dxTextBox({
        mask: 'AA',
        maskRules: {
            'A': /[abc]/
        }
    });

    $('#maxLength').dxTextBox({
        maxLength: 10,
        placeholder: 'Maximum 10 character is allowed in this TextBox'
    });

    $('#mode').dxTextBox({
        mode: 'password',
        placeholder: 'Enter password'
    });

    $('#name').dxTextBox({
        name: 'customeName',
        placeholder: 'name property is assigned to this UI component'
    });

    $('#onChange').dxTextBox({
        placeholder: 'This TextBox will disabled when value is changed here',
        onChange: function () {
            $('#onChange').dxTextBox('instance').option('disabled', true)
        }
    });

    $('#onContentReady').dxTextBox({
        placeholder: 'This TextBox will disabled when content is ready',
        onContentReady: function (e) {
            e.component.option('disabled', true)
        }
    });

    $('#onCopy').dxTextBox({
        placeholder: 'This TextBox will disabled if you copy input from here',
        onCopy: function (e) {
            e.component.option('disabled', true)
        }
    });

    $('#onCut').dxTextBox({
        placeholder: 'This TextBox will disabled if you cut input from here',
        onCut: function (e) {
            e.component.option('disabled', true)
        }
    });

    $('#onDisposing').dxTextBox({
        placeholder: 'Notification is showed before the TextBox is disposed',
        onDisposing: function () {
            DevExpress.ui.notify('TextBox is disposing'),
                $('#removeBtn').remove();
        }
    });
    $('#removeBtn').dxButton({
        text: 'Click to dispose TextBox',
        onClick: function () {
            $('#onDisposing').dxTextBox('dispose');
        }
    })

    $('#onEnterKey').dxTextBox({
        placeholder: 'This TextBox will disabled if you press enter key while TextBox is focused',
        onEnterKey: function (e) {
            e.component.option('disabled', true)
        }
    });

    $('#onFocusIn').dxTextBox({
        placeholder: 'This TextBox will change visual when you focused In',
        onFocusIn: function (e) {
            console.log(e);
            e.component.option('inputAttr', {
                id: 'customId'
            })
        }
    });

    $('#onFocusOut').dxTextBox({
        placeholder: 'This TextBox will change visual when you looses focus',
        onFocusOut: function (e) {
            e.component.option('elementAttr', {
                class: 'customCss'
            })
        }
    });

    $('#onInitialized').dxTextBox({
        placeholder: 'Notification is showed when the TextBox is initialized',
        onInitialized: function (e) {
            DevExpress.ui.notify('TextBox is initialized','success',1000);
        }
    });

    $('#onInput').dxTextBox({
        placeholder: 'Notification is showed when the TextBox input is changed in this TextBox',
        onInput: function (e) {
            DevExpress.ui.notify('TextBox input is changed','warning',1000);
        }
    });

    $('#onKeyDown').dxTextBox({
        placeholder: 'Notification is showed when KeyDown event occurs in this input',
        onKeyDown: function (e) {
            DevExpress.ui.notify('KeyDown event occured','info',1000);
        }
    });

    $('#onKeyUp').dxTextBox({
        placeholder: 'Notification is showed when onKeyUp event occurs in this input',
        onKeyUp: function (e) {
            DevExpress.ui.notify('onKeyUp event occured','info',1000);
        }
    });

    $('#onOptionChanged').dxTextBox({
        placeholder: 'Notification is showed when input is changed in the TextBox',
        onOptionChanged: function (e) {
            if (e.name == 'value') {
                DevExpress.ui.notify('New value: ' + e.value, 'info', 1000);
            }
        }
    });

    $('#onPaste').dxTextBox({
        placeholder: 'This TextBox will disabled if you paste something here',
        onPaste: function (e) {
            e.component.option('disabled', true)
        }
    });

    $('#onValueChanged').dxTextBox({
        placeholder: 'Notification is showed when input value is changed in the TextBox',
        onValueChanged: function (e) {
            DevExpress.ui.notify('New value: ' + e.value, 'info', 1000);
            console.log('onValueChanged called');
        },
        onFocusOut: function (e) {
            console.log('onFocusOut called');
        }
    });

    $('#placeholder').dxTextBox({
        placeholder: 'Placeholder is shown when TextBox is empty'
    });

    $('#readOnly').dxTextBox({
        text: 'This is readOnly TextBox',
        readOnly: true
    });

    $('#rtlEnabled').dxTextBox({
        placeholder: 'This is rtlEnabled TextBox',
        rtlEnabled: true
    });

    $('#showClearButton').dxTextBox({
        placeholder: 'Type something...',
        showClearButton: true
    });

    $('#showMaskMode').dxTextBox({
        placeholder: 'Enter mobile number',
        mask: "(000) 000-0000",
        useMaskedValue: true,
        showMaskMode: "onFocus"
    });

    $('#spellcheck').dxTextBox({
        placeholder: 'Type something...',
        spellcheck: true
    });

    $('#stylingMode').dxTextBox({
        placeholder: 'This is filled TextBox',
        stylingMode: 'filled'
    });

    $('#tabIndex').dxTextBox({
        placeholder: 'tabIndex of this TextBox is 1',
        tabIndex: 1
    });

    $('#text').dxTextBox({
        text: 'This is text given to TextBox'
    });

    $('#useMaskedValue').dxTextBox({
        text: 'Enter mobile number',
        mask: "(000) 000-0000",
        useMaskedValue: true,
        onValueChanged: function (e) {
            DevExpress.ui.notify('Value: ' + e.value, 'info', 1000);
        }
    });

    $('#validationError').dxTextBox({
        placeholder: 'Enter your name..',
        onValueChanged: function (e) {
            //if (e.validationError) {
            //    console.log(e.validationError.message);
            //}
        }
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Name is required"
        }]
    });

    $('#validationErrors').dxTextBox({
        placeholder: 'Enter your name..',
        onValueChanged: function (e) {
            //if (e.validationError) {
            //    console.log("Validation error:", e.validationError.message);
            //}
        }
    }).dxValidator({
        validationRules: [
            {
                type: "required",
                message: "Name is required"
            },
            {
                type: "stringLength",
                min: 2,
                message: "Name must be at least 2 characters"
            }
        ]
    });

    $('#validationMessageMode').dxTextBox({
        placeholder: 'Enter your hobby',
        validationMessageMode: 'always',
        onValueChanged: function (e) {
            //if (e.validationError) {
            //    console.log('Error: ' + e.validationError.message);
            //}
        }
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "This is required"
        }]
    });

    $('#validationMessagePosition').dxTextBox({
        placeholder: 'Enter your address',
        validationMessagePosition: 'left',
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "This is required"
        }]
    });

    $('#validationStatus').dxTextBox({
        placeholder: 'Validation status is pending',
        validationStatus: 'pending'
    });

    $('#value').dxTextBox({
        value: 'This is initial value'
    });

    $('#valueChangeEvent').dxTextBox({
        placeholder: 'Notification is showed when input value is changed(keyup) in the TextBox',
        valueChangeEvent: 'keyup',
        onValueChanged: function (e) {
            DevExpress.ui.notify('Value: ' + e.value, 'info', 1000);
        }
    });

    $('#visible').dxTextBox({
        placeholder: 'This TextBox is not visible in UI',
        visible: false
    });

    $('#width').dxTextBox({
        placeholder: 'Custom width given',
        width: '300px'
    });
});