$(() => {
    $("#numberBox").dxNumberBox({

        // Minimum value for the number input
        min: 0,

        // Maximum value for the number input
        max: 100,

        // Format the value as a fixedPoint
        format: {
            type: "fixedPoint", // fixedPoint format
        },

        // Placeholder text shown when the input is empty
        placeholder: "Number",

        // Set the initial value to 20
        value: 20,

        // Show the spin buttons (arrows) for incrementing or decrementing the value
        showSpinButtons: true,

        // Show a clear button to reset the input value
        showClearButton: true,

        // Set the step value for the spin buttons (step size is 2)
        step: 2,

        // Use large spin buttons for easier clicking
        useLargeSpinButtons: true
    });
});
