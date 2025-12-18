$(() => {
    const scrollViewContent = `
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
        <p>Vestibulum et lacus nec justo dignissim hendrerit.</p>
        <p>Curabitur aliquam metus nec magna commodo, eu pharetra risus rhoncus.</p>
        <p>Fusce tincidunt nisl id augue congue, eget tincidunt sapien consequat.</p>
        <p>Proin ut ex nec sapien cursus facilisis.</p>
        <p>Donec vulputate risus ut felis dictum, sed fermentum nisi aliquet.</p>
        <p>Suspendisse potenti. Integer vehicula massa a est ultricies accumsan.</p>
        <p>Aliquam auctor metus ut sem tempus, id ultrices turpis placerat.</p>
    `;

    $('#btnContainer').dxButton({
        text: 'Show Popup',
        onClick: function () {
            popup.show();
        }
    });

    const popup = $('#container').dxPopup({
        //visible: true,
        //showTitle: false,
        height: 300,
        width: 400,
        showCloseButton: false,
        title: 'This is popup',
        shading: true,                      //Default value is true
        shadingColor: 'rgba(0, 0, 0, 0.3)',
        //position: 'left',
        position: {
            at: 'bottom',                   //point of the target element is used for alignment
            my: 'left',                     //point of the popup itself should be aligned to the target
            collision: 'fit',               //handle overlaps with viewport boundaries
        },
        hideOnOutsideClick: true,
        resizeEnabled: true,
        //fullScreen: true,
        dragEnabled: true,
        toolbarItems: [
            {
                toolbar: 'bottom',
                location: 'after',
                widget: 'dxButton',
                options: {
                    text: 'Close',
                    onClick: function () {
                        popup.hide();       // Hide the popup when clicking the close button
                    }
                }
            }
        ],
        contentTemplate: function () {
            let scrollView = $('<div/>');
            scrollView.append($('<div/>').html(scrollViewContent));
            scrollView.dxScrollView({
                width: '100%',
                height: '100%'
            });
            return scrollView;
        }
    }).dxPopup('instance');
});