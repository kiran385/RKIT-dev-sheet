$(document).ready(async function () {
    // Class
    class Room {
        constructor(number) {
            this.number = number;
            this.students = [];
        }
    }

    // API endpoints
    const API_URL = 'https://687f84e0efe65e52008a1051.mockapi.io/dummy/students';

    // Local storage for rooms
    function saveRooms(data) {
        localStorage.setItem('rooms', JSON.stringify(data));
    }
    function loadRooms() {
        const d = localStorage.getItem('rooms');
        return d ? JSON.parse(d) : [];
    }
    let rooms = loadRooms();

    // Store students
    let students = [];

    // Fetch students and build initial rooms
    async function fetchStudents() {
        try {
            const resp = await fetch(API_URL);
            if (!resp.ok) throw new Error('Fetch failed');
            const data = await resp.json();
            students = data;
            rebuildRooms();
        } catch (err) {
            console.error(err);
            students = [];
            rooms = loadRooms();
        }
    }

    async function updateStudentAPI(studentId, updatedData) {
        const resp = await fetch(`${API_URL}/${studentId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updatedData)
        });
        return resp.ok ? resp.json() : null;
    }


    // Rebuild rooms based on current students
    function rebuildRooms() {
        rooms = [];
        for (const s of students) {
            let r = rooms.find(r => r.number === s.roomNumber);
            if (!r) {
                r = new Room(s.roomNumber);
                rooms.push(r);
            }
            r.students.push(s.name);
        }
        saveRooms(rooms);
    }

    // Load initial data
    await fetchStudents();


    // Student List Modal
//     $('#studentListModal').on('show.bs.modal', function () {
//         const modalBody = $(this).find('.modal-body');
//         modalBody.empty();

//         if (students.length === 0) {
//             modalBody.html('<p class="text-muted">No students found.</p>');
//             return;
//         }

//         // Create table wrapper
//         const tableWrapper = document.createElement('div');
//         tableWrapper.className = 'table-responsive';

//         // Create table element
//         const table = document.createElement('table');
//         table.className = 'table table-bordered table-striped';

//         // Create table content
//         table.innerHTML = `
//     <thead class="table-primary">
//         <tr>
//             <th>No.</th>
//             <th>Name</th>
//             <th>Mobile</th>
//             <th>Age</th>
//             <th>Address</th>
//             <th>Room</th>
//             <th>Fees Status</th>
//         </tr>
//     </thead>
//     <tbody>
//         ${students.map((student, index) => `
//             <tr>
//                 <td>${index + 1}</td>
//                 <td>${student.name}</td>
//                 <td>${student.number}</td>
//                 <td>${student.age}</td>
//                 <td>${student.address}</td>
//                 <td>${student.roomNumber}</td>
//                 <td>${student.feesPaid === "true" ? '<i class="fa-solid fa-circle-check" style="color: #3cb371;"></i> Paid' : '<i class="fa-solid fa-xmark" style="color: #dc143c;"></i> Pending'}</td>
//             </tr>
//         `).join('')}
//     </tbody>
// `;

//         tableWrapper.appendChild(table);
//         modalBody.html(tableWrapper);
//     });


    // Room List Modal
    $('#roomListModal').on('show.bs.modal', function () {
        const modalBody = $(this).find('.modal-body');
        modalBody.empty();

        if (rooms.length === 0) {
            modalBody.html('<p class="text-muted">No rooms found.</p>');
            return;
        }

        // Sort rooms by room number
        rooms.sort((a, b) => a.number - b.number);

        // Generate table rows
        const rows = rooms.map(room => `
        <tr>
            <td>${room.number}</td>
            <td>
                <ul>
                    ${room.students.map(student => `<li>${student}</li>`).join('')}
                </ul>
            </td>
        </tr>
    `).join('');

        // Generate full table HTML
        const table = `
        <table class="table table-bordered table-striped">
            <thead class="table-primary">
                <tr>
                    <th>Room No.</th>
                    <th>Students</th>
                </tr>
            </thead>
            <tbody>
                ${rows}
            </tbody>
        </table>
    `;

        modalBody.html(table);
    });


    // Fees Modal
    $('#feesModal').on('show.bs.modal', function () {
        const modalBody = document.querySelector('#feesModal .modal-body');
        modalBody.innerHTML = '';

        if (students.length === 0) {
            modalBody.innerHTML = `<p class="text-muted">No students found.</p>`;
            return;
        }

        // Sort students: unpaid first, paid last
        students.sort((a, b) => (a.feesPaid === "true") - (b.feesPaid === "true"));

        // Create table wrapper
        const tableWrapper = document.createElement('div');
        tableWrapper.className = 'table-responsive';

        // Create table element
        const table = document.createElement('table');
        table.className = 'table table-bordered table-striped';

        // Create table content
        table.innerHTML = `
        <thead class="table-primary">
            <tr>
                <th>No.</th>
                <th>Name</th>
                <th>Mobile</th>
                <th>Age</th>
                <th>Address</th>
                <th>Room</th>
                <th>Fees Status</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
            ${students.map((student, index) => `
                <tr 
                    data-student-id="${student.id}" 
                    class="${student.feesPaid === "true" ? 'table-success' : 'table-warning'}"
                >
                    <td>${index + 1}</td>
                    <td>${student.name}</td>
                    <td>${student.number}</td>
                    <td>${student.age}</td>
                    <td>${student.address}</td>
                    <td>${student.roomNumber}</td>
                    <td>${student.feesPaid === "true" ? '<i class="fa-solid fa-circle-check" style="color: #3cb371;"></i> Paid' : '<i class="fa-solid fa-xmark" style="color: #dc143c;"></i> Pending'}</td>
                    <td>
                        <button 
                            class="btn btn-sm ${student.feesPaid === "true" ? 'btn-warning' : 'btn-success'} toggle-fees-btn"
                        >
                            ${student.feesPaid === "true" ? 'Mark Pending' : 'Mark Paid'}
                        </button>
                    </td>
                </tr>
            `).join('')}
        </tbody>
    `;

        // Add table to modal
        tableWrapper.appendChild(table);
        modalBody.appendChild(tableWrapper);

        // Add event listeners to toggle buttons
        modalBody.querySelectorAll('.toggle-fees-btn').forEach(button => {
            button.addEventListener('click', function () {
                const tr = this.closest('tr');
                const studentId = parseInt(tr.getAttribute('data-student-id'));
                const student = students.find(s => parseInt(s.id) === studentId);

                if (student) {
                    // Toggle feesPaid value
                    student.feesPaid = student.feesPaid === "true" ? "false" : "true";

                    // Update in backend
                    updateStudentAPI(studentId, student);

                    // Hide modal
                    const modalEle = document.getElementById('feesModal');
                    const modalInstance = bootstrap.Modal.getInstance(modalEle);
                    modalInstance.hide();

                    // Reopen modal to refresh content
                    modalEle.addEventListener('hidden.bs.modal', () => {
                        modalInstance.show();
                    }, { once: true });
                }
            });
        });
    });


    // Add Student Shortcut
    $(window).on('keydown', function(event){
        if(event.key.toLowerCase() === 'a' ){
            window.location.href = "addStudent.html";
        }
    })

    $('#backward').on('click', function(){
        history.back();
    });

    $('#forward').on('click', function(){
        history.forward();
    });

    document.getElementById("addStudent").addEventListener("click", function() {
        window.location.href = "addStudent.html";
    });

    document.getElementById("studentList").addEventListener("click", function() {
        window.location.href = "studentList.html";
    })
});
