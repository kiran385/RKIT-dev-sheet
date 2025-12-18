$(() => {
    // static string data
    const longText = 'Prepare 2013 Marketing Plan: We need to double revenues in 2013 and our marketing strategy is going to be key here. R&D is improving existing products and creating new products so we can deliver great AV equipment to our customers.Robert, please make certain to create a PowerPoint presentation for the members of the executive team.';

    // New text area component
    const exampleTextArea = $('#example-textarea').dxTextArea({
        value: longText,
        height: 90,
        inputAttr: { 'aria-label': 'Notes' },
    }).dxTextArea('instance');

    // New check box component from text length limit
    $('#set-max-length').dxCheckBox({
        value: false,
        onValueChanged(data) {
            const str = data.value ? exampleTextArea.option('value').substring(0, 100) : longText;
            exampleTextArea.option('value', str);
            exampleTextArea.option('maxLength', data.value ? 100 : null);
        },
        text: 'Limit text length',
    });

    // New check box component for auto resize
    $('#set-resize').dxCheckBox({
        value: false,
        onValueChanged(e) {
            exampleTextArea.option('autoResizeEnabled', e.value);
            exampleTextArea.option('height', e.value ? undefined : 90);
        },
        text: 'Enable auto resize',
    });

    const valueChangeEvents = [{
        title: 'On Change',
        name: 'change',
    }, {
        title: 'On Key Up',
        name: 'keyup',
    }];

    // New select box component
    $('#change-event').dxSelectBox({
        items: valueChangeEvents,
        inputAttr: { 'aria-label': 'Event' },
        value: valueChangeEvents[0].name,
        valueExpr: 'name',
        displayExpr: 'title',
        onValueChanged(data) {
            editingTextArea.option('valueChangeEvent', data.value);
        },
    });

    // New text area component for editing text
    const editingTextArea = $('#editing-textarea').dxTextArea({
        value: longText,
        height: 90,
        valueChangeEvent: 'change',
        inputAttr: { 'aria-label': 'Notes' },
        onValueChanged(data) {
            disabledTextArea.option('value', data.value);
        },
    }).dxTextArea('instance');

    // New text area component for readonly text
    const disabledTextArea = $('#disabled-textarea').dxTextArea({
        value: longText,
        height: 90,
        readOnly: true,
        inputAttr: { 'aria-label': 'Notes' },
    }).dxTextArea('instance');
});
