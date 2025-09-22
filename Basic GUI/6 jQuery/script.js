$(document).ready(function () {
    console.log($);
    $('p').click(function () {
        console.log('Clicked', this);
        // $(this).hide();
    });


    // Different types of Selectors 

    // 1. Element Selector
    // $('p').click();
    $('h1').click();      //For other element we need to create new click function

    // 2. Id Selector 
    // $('#first').click();

    // 3. Class Selector 
    // $('.even').click();


    // Events in jQuery

    $('#outer').on({
        click: function () {
            console.log('Clicked event');
        },
        dblclick: function () {
            console.log('Double click event');
        },
        mousedown: function () {
            console.log('Mouse down event');
        },
        mouseup: function () {
            console.log('Mouse up event');
        },
        mouseenter: function () {
            console.log('Mouse enter event');
        },
        mouseover: function () {
            console.log('Mouse over event');
        },
        mouseout: function () {
            console.log('Mouse out event');
        },
        mouseleave: function () {
            console.log('Mouse leave event');
        },
    });   

    $('input').on({
        keypress: function () {
            console.log('Key press event');
        },
        keydown: function () {
            console.log('Key down event');
        },
        keyup: function () {
            console.log('Key up event');
        }
    });

    $('form input').on({
        focus: function () {
            console.log('Focus event');
        },
        blur: function () {
            console.log('Blur event');
        },
        change: function () {
            console.log('Change event');
        },
    });
    $('form input').on({
        focus: function () {
            console.log('Focus 2 event');
        },
    });
    $('form input').off('focus change');

    $(window).resize(function () {
        console.log('Resize event');
    })

    $('#outer').hover(function () {
        $('#outer p').fadeOut(2000).fadeIn(2000);
    })


    // Effects in jQuery

    $('#hide').click(function () {
        $('div').hide(2000, function () {          // We can use fadeOut for smooth transition
            console.log('Hide effect completed');
        });
    });

    $('#show').click(function () {
        $('div').show("slow", function () {        // We can use fadeIn for smooth transition
            console.log('Show effect completed');
        });
    });


    //Methods in jQuery

    $('#getBtn').click(function () {
        console.log("Output of text() : " + $('#para').text());
        console.log("Output of html() : " + $('#para').html());
        console.log("Output of val() : " + $('#name').val());
    });

    $('#setBtn').click(function () {
        $('#para').text('Hello World');
        $('#name').val('Kiran Baraiya');
    });

    $('#setBtn').dblclick(function () {
        $('#para').html('<b>Hello World</b>');
    });

    $('#add').click(function () {
        $('#para').addClass("c1 font");
        console.log('Font color of paragraph text is ' + $('#para').css('color'));
    })

    $('#remove').click(function () {
        $('#para').removeClass("c1");
    })


    // jQuery Traversal

    $('div p').parent().css({
        "background-color": "yellow",
        "color": "red"
    });

    $('div div').children().css({
        "background-color": "lightblue"
    });

    // $('#outer').siblings().css({
    //     "background-color" : "lime"
    // });


    // jQuery Filter 

    $('#search').on('keyup', function () {
        var value = $(this).val().toLowerCase();
        $('p').filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
        });
    });

    $('p').click(function () {
        $('p').clone().appendTo('body');
    });

    // alert($().jquery);

    // jQuery validation
    $('#form').validate({
        rules: {
            name: {
                required: true,
                minlength: 10
            },
            age: {
                required: true,
            }
        },
        messages: {
            name: {
                required: "Name is requird",
                minlength: "Name must be 10 character long"
            },
            age: "Age is required"
        },
    });


    // AJAX
    $("#ajaxBtn").click(function () {
        $.post("https://687f84e0efe65e52008a1051.mockapi.io/dummy/students",
            {
                name: "Rohit Sharma",
            }, function () {
                $.ajax({                                //Instead of ajax you can use get
                    url: "https://687f84e0efe65e52008a1051.mockapi.io/dummy/students",
                    success: function (result) {
                        for (x in result) {
                            $('#div1').append(`<div>${result[x].name}</div>`);
                        }
                    },
                    
                });
            });
    });


    // Functions of jQuery
    
    const numbers = [1, 2, 3, 4];
    const doubled = $.map(numbers, function (value, index) {
        return value * 2;
    });
    //console.log(numbers);       // [1, 2, 3, 4]
    //console.log(doubled);       // [2, 4, 6, 8]

    const ages = [12, 18, 25, 30, 15];
    const above18 = $.grep(ages, function (value, index) {
        return value >= 18;
    });
    // console.log(ages);            // [12, 18, 25, 30, 15] 
    // console.log(above18);         // Output: [18, 25, 30]

    const fruits = ["apple", "banana", "cherry"];
    $.each(fruits, function (index, value) {
        //console.log(index + ": " + value);
    });

    const a = [1, 2, 3, 4];
    const b = [4, 5, 6];
    const combined = $.merge(a, b);
    // console.log(a);            // [1, 2, 3, 4, 4, 5, 6]
    // console.log(combined);     // [1, 2, 3, 4, 4, 5, 6]

    const defaultSettings = { theme: "light", layout: "grid", preference: { a: 10 } };
    const userSettings = { theme: "dark", preference: { b: 20 } };
    const shallowCopy = $.extend(false, {}, defaultSettings, userSettings);
    const deepCopy = $.extend(true, {}, defaultSettings, userSettings);
    // console.log(defaultSettings);     // {theme: 'light', layout: 'grid', preference: {a: 10}}
    // console.log(shallowCopy);         // {theme: 'dark', layout: 'grid', preference: {b: 20}}
    // console.log(deepCopy);            // {theme: 'dark', layout: 'grid', preference: {a: 10, b:20}}
});