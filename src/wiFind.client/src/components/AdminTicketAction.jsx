/* eslint-disable no-unused-vars */
import React, { useEffect, useState } from 'react';
import './AdminTicketAction.css';
import * as Placeholders from '../placeholders/placeholders';
import AdminDropdown from './AdminDropdown.jsx';
import AdminChoose from './AdminChoose.jsx';
import Button from '@mui/material/Button';

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

    const handleButton2Click = async () => {
        // Logic for button 2
        const newadminassignment = document.getElementById("demo-simple-select").firstChild.data;
        const statusVal = document.getElementById("admin-chooser").firstChild.data;
        var statusconversion = statusVal && statusVal == "Open" ? 0 : statusVal == "In Progress" ? 1 : 2;

        const response = await fetch('https://localhost:7042/api/SupportTicket/updateticket', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem("token"),
            },
            body: JSON.stringify({ ticket_id: "0fc8975c-c0c4-4236-a4fe-3c6e6265867f", ticketStatus: statusconversion, assigned_to: newadminassignment })
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        alert("That Ticket has been saved. Now refreshing page.");
        location.reload();
    };

    //const tableData = [
    //    { id: 1, name: 'Row 1' },
    //    { id: 2, name: 'Row 2' },
    //    // Add more rows as needed
    //];

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
                        <th>Actions</th>
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
                            <td>
                            <AdminDropdown></AdminDropdown>
                                <AdminChoose></AdminChoose>
                                <Button variant="outlined" onClick={handleButton2Click}>Save</Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default AdminTicketAction;
