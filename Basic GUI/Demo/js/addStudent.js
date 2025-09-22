// API endpoints
const API_URL = 'https://687f84e0efe65e52008a1051.mockapi.io/dummy/students';

function loadRooms() {
    const d = localStorage.getItem('rooms');
    return d ? JSON.parse(d) : [];
}
let rooms = loadRooms();

// Send a new student to the API
async function addStudentAPI(student) {
    const resp = await fetch(API_URL, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(student)
    });
    return resp.ok ? await resp.json() : null;
}

// Form validation
$('#addStudentForm').validate({
    rules: {
        studentName: {
            required: true,
            minlength: 2
        },
        studentNumber: {
            required: true,
            digits: true,
            minlength: 10,
            maxlength: 10
        },
        studentAge: {
            required: true,
            number: true,
            min: 5,
            max: 100
        },
        studentAddress: {
            required: true
        },
        studentRoom: {
            required: true,
            number: true
        }
    },
    messages: {
        studentName: "Please enter at least 2 characters",
        studentNumber: "Enter a valid 10-digit number",
        studentAge: "Enter a valid age between 5 and 100",
        studentAddress: "Address is required",
        studentRoom: "Enter a valid room number"
    },
    onfocusout: function (element) {
        // Validate the field
        if (!$(element).valid()) {
            element.focus();
        }
    },
    submitHandler: async function (form, event) {
        event.preventDefault();
        const name = $('#studentName').val();
        const number = $('#studentNumber').val();
        const age = parseInt($('#studentAge').val());
        const address = $('#studentAddress').val();
        const roomNumber = parseInt($('#studentRoom').val());
        const feesPaid = $('#studentFees').val();

        let room = rooms.find(r => r.number === roomNumber);
        if (room && room.students.length >= 4) {
            Swal.fire({
                icon: 'warning',
                title: 'Room Full',
                text: `Room number ${roomNumber} is full`,
                timer: 5000,
                showConfirmButton: true,
            });
            return;
        }

        const toSend = { name, number, age, address, roomNumber, feesPaid };

        const created = await addStudentAPI(toSend);
        if (!created) return alert('Error while adding student.');

        Swal.fire({
            icon: 'success',
            title: 'Student Added',
            text: `Student ${name} added to Room ${roomNumber}`,
            timer: 5000,
            showConfirmButton: true,
        }).then(() => {
            // location.reload();
            window.location.href = "index.html";
        });

        // form.reset();
        // bootstrap.Modal.getInstance(document.getElementById('addStudentModal')).hide();
    }
});

$('#backward').on('click', function(){
    history.back();
});

$('#forward').on('click', function(){
    history.forward();
});