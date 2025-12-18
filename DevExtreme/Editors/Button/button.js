$(() => {
    // Initialize button of type normal
    $("#buttonContainer-1").dxButton({
        // Type of the button
        type: "normal",

        // Display text on button
        text: "Normal",

        // set icon on button
        icon: "home",

        // onClick event
        onClick() {
            DevExpress.ui.notify('The normal button is clicked','warning',2000);
        }
    });

    // Initialize button of type default
    $("#buttonContainer-2").dxButton({
        // Type of the button
        type: "default",

        // Display text on button
        text: "Default",

        // Specify number of element during tab
        tabIndex: 1,

        // set icon on button
        icon: "info",

        // onClick event
        onClick() {
            DevExpress.ui.notify('The default button is clicked');
        }
    });

    // Initialize button of type success
    $("#buttonContainer-3").dxButton({
        // Type of the button
        type: "success",

        // Display text on button
        text: "Success",

        // set icon on button
        icon: "check",

        // onClick event
        onClick() {
            DevExpress.ui.notify('The success button is clicked','success',2000);
        }
    });

    // Initialize button of type danger and outlined mode
    $("#buttonContainer-4").dxButton({
        // Type of the button
        type: "danger",

        // Display text on button
        text: "Danger and Outlined",

        // Styling mode of the button
        stylingMode: "outlined",

        // set icon on button
        icon: "back",

        // onClick event
        onClick() {
            DevExpress.ui.notify('The normal danger button with outline is clicked','error',2000);
        }
    });
});