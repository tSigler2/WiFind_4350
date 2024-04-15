/* eslint-disable no-unused-vars */
import React, { useEffect, useState } from 'react';
import './AdminTicketAction.css';
import AdminUserDialog from './AdminUserDialog';

function AdminUserAction() {
    const [inactiveUsers, setInactiveUsers] = useState([]);

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
        setInactiveUsers(data);
    }

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
                    </tr>
                </thead>
                <tbody>
                    {inactiveUsers.map((row) => (
                        <tr key={row.user_id}>
                            <td>{row.user_id}</td>
                            <td>{row.username}</td>
                            <td>{row.email}</td>
                            <td>{row.last_login}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <AdminUserDialog></AdminUserDialog>
        </div>
    );
}

export default AdminUserAction;
