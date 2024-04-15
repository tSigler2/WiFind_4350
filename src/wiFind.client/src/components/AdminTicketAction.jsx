/* eslint-disable no-unused-vars */
import React, { useEffect, useState } from 'react';
import './AdminTicketAction.css';
import * as Placeholders from '../placeholders/placeholders';
import AdminTicketDialog from './AdminTicketDialog';

function AdminTicketAction() {
    const [supportTickets, setSupportTickets] = useState([]);
    const [selectedName, setSelectedName] = useState(''); // State to store the selected name
    const [alladmins, setalladmins] = useState([]);

    useEffect(() => {
        populateSupportTickets();
        populateAdmins();
    }, []);

    async function populateSupportTickets() {
        const response = await fetch('https://localhost:7042/api/SupportTicket/alltickets', {
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

    async function populateAdmins() {
        //const response = await fetch('https://localhost:7042/api/User/alladmins', {
        //    method: 'GET',
        //    headers: {
        //        'Content-Type': 'application/json',
        //        'Authorization': 'Bearer ' + localStorage.getItem("token"),
        //    },
        //});

        //if (!response.ok) {
        //    throw new Error(`HTTP error! status: ${response.status}`);
        //}
        //const data = await response.json();
        const data = Placeholders.allticketadmins;
        setalladmins(data);
    }

    return (
        <div style={{ paddingBottom: '20%' }}>
            <h3>Support Ticket Actions</h3>
            <table className="your-table">
                <thead>
                    <tr>
                        <th>Ticket ID</th>
                        <th>User Email</th>
                        <th>Time Submitted</th>
                        <th>Subject</th>
                        <th>Description</th>
                        <th>Status</th>
                        <th>Assigned To</th>
                    </tr>
                </thead>
                <tbody>
                    {supportTickets.map((row) => (
                        <tr key={row.ticket_id}>
                            <td>{row.ticket_id}</td>
                            <td>{row.email}</td>
                            <td>{row.time_stamp}</td>
                            <td>{row.subject}</td>
                            <td>{row.description}</td>
                            <td>{row.status == 0? "Open" : row.status == 1 ? "In Progress" : "Closed"}</td>
                            <td>{row.assigned_to}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <h3>Available Admins Usernames</h3>
            <table className="your-table">
                <thead>
                    <tr>
                        <th>Username</th>
                    </tr>
                </thead>
                <tbody>
                    {alladmins.map((a) => (
                        <tr key={a.username}>
                            <td>{a.username}</td>
                        </tr>

                    ))}
                </tbody>
            </table>
            <AdminTicketDialog></AdminTicketDialog>
        </div>
    );
}

export default AdminTicketAction;
