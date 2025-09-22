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


    // Student List 
    const studentListBody = $(this).find('.studentListBody');
    studentListBody.empty();

    if (students.length === 0) {
        studentListBody.html('<p class="text-muted">No students found.</p>');
        return;
    }

    // Create table wrapper
    const tableWrapper = document.createElement('div');
    tableWrapper.className = 'table-responsive';

    // Create table element
    const table = document.createElement('table');
    table.className = 'table table-bordered';

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
    </tr>
</thead>
<tbody>
    ${students.map((student, index) => `
        <tr>
            <td>${index + 1}</td>
            <td>${student.name}</td>
            <td>${student.number}</td>
            <td>${student.age}</td>
            <td>${student.address}</td>
            <td>${student.roomNumber}</td>
            <td>${student.feesPaid === "true" ? '<i class="fa-solid fa-circle-check" style="color: #3cb371;"></i> Paid' : '<i class="fa-solid fa-xmark" style="color: #dc143c;"></i> Pending'}</td>
        </tr>
    `).join('')}
</tbody>
`;

    tableWrapper.appendChild(table);
    studentListBody.html(tableWrapper);


    $('#backward').on('click', function(){
        history.back();
    });

    $('#forward').on('click', function(){
        history.forward();
    });
});