/* eslint-disable no-unused-vars */
import React, { useEffect, useState } from 'react';
import './AdminTicketAction.css';
import Button from '@mui/material/Button';

function AdminUserAction() {
    const [supportTickets, setSupportTickets] = useState([]);
    const [selectedName, setSelectedName] = useState(''); // State to store the selected name

    useEffect(() => {
        populateInactiveUsers();
    }, []);

    async function populateInactiveUsers() {
        const response = await fetch('https://localhost:7042/api/User/inactiveusers', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem("token"),
            },
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();
        setSupportTickets(data);
    }

    const handleButton2Click = async (e) => {
        //TODO: get good with html and get user to delete from dom to replace hardcode
        const response = await fetch('https://localhost:7042/api/User/removeusers', {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem("token"),
            },
            body: JSON.stringify({ username: "user7" })
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        alert("That User was removed. Now refreshing page.");
        location.reload();
    };

    //const tableData = [
    //    { id: 1, name: 'Row 1' },
    //    { id: 2, name: 'Row 2' },
    //    // Add more rows as needed
    //];

    return (
        <div style={{ paddingBottom: '20%' }}>
            <h3>User Management Actions</h3>
            <table className="your-table">
                <thead>
                    <tr>
                        <th>User ID</th>
                        <th>Username</th>
                        <th>User Email</th>
                        <th>Last Login</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {supportTickets.map((row) => (
                        <tr key={row.user_id}>
                            <td>{row.user_id}</td>
                            <td>{row.username}</td>
                            <td>{row.email}</td>
                            <td>{row.last_login}</td>
                            <td>
                                <Button variant="outlined" onClick={handleButton2Click }>Delete</Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default AdminUserAction;
