/* eslint-disable no-unused-vars */
import * as React from 'react';
import AdminTicketAction from '../components/AdminTicketAction'
import AdminUserAction from '../components/AdminUserAction'
import Footer from '../components/Footer';
import Button from '@mui/material/Button';

const Admin = () => {
    const adminrole = localStorage.getItem("user_role");
    const ticketaction = adminrole.includes("Ticket");
    const useraction = adminrole.includes("User");
    const [openTicket, setOpenTicket] = React.useState(false);
    const [openUser, setOpenUser] = React.useState(false);

    const handleClickOpenTicket = () => {
        setOpenTicket(!openTicket);
    };

    const handleClickOpenUser = () => {
        setOpenUser(!openUser);
    };


    return (
        <div>
            <h1>Admin Portal</h1>
            <div>
                {ticketaction ? <div><Button variant="outlined" onClick={handleClickOpenTicket}>
                    Manage Tickets </Button>
                    {openTicket && <AdminTicketAction></AdminTicketAction>}
                     </div>
                    : null}
            </div>
            <div style={{padding: '10px'} }>
                {useraction ? <div><Button variant="outlined" onClick={handleClickOpenUser}>
                    Manage Users </Button>
                    {openUser && <AdminUserAction></AdminUserAction>}
                     </div> : null}
            </div>
            <Footer /> {/* Include the Footer component */}
        </div>

    );
}

export default Admin;