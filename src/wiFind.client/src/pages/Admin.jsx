/* eslint-disable no-unused-vars */
import React from 'react';
import AdminTicketAction from '../components/AdminTicketAction'
import AdminUserAction from '../components/AdminUserAction'
import Footer from '../components/Footer';

const Admin = () => {
    const adminrole = localStorage.getItem("user_role");
    const ticketaction = adminrole.includes("Ticket");
    const useraction = adminrole.includes("User");

    return (
        <div>
            <h1>Admin Portal</h1>
            <div>
                {ticketaction ? <AdminTicketAction></AdminTicketAction> : null}
            </div>
            <div>
                {useraction ? <AdminUserAction></AdminUserAction> : null}
            </div>
            <Footer /> {/* Include the Footer component */}
        </div>

    );
}

export default Admin;