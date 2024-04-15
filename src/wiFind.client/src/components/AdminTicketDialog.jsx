import * as React from 'react';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';

function AdminTicketDialog() {
    const [open, setOpen] = React.useState(false);

    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };
    async function updateTicket(ticket_id, status, assigned_to){
        var numStatus = parseInt(status);
        const response = await fetch('https://localhost:7042/api/SupportTicket/updateticket', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem("token"),
            },
            body: JSON.stringify({ ticket_id: ticket_id, ticketStatus: numStatus, assigned_to: assigned_to })
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        setOpen(false);
    }

    return (
        <React.Fragment>
            <Button variant="outlined" onClick={handleClickOpen}>
                Update a Ticket
            </Button>
            <Dialog
                open={open}
                onClose={handleClose}
                PaperProps={{
                    component: 'form',
                    onSubmit: (event) => {
                        event.preventDefault();
                        const formData = new FormData(event.currentTarget);
                        const formJson = Object.fromEntries(formData.entries());
                        const ticket_id = formJson.ticket_id;
                        const status = formJson.status;
                        const assigned_to = formJson.assigned_to;

                        updateTicket(ticket_id, status, assigned_to);
                        
                        handleClose();
                    },
                }}
            >
                <DialogTitle>Update a Ticket</DialogTitle>
                <DialogContent>
                    <TextField
                        autoFocus
                        required
                        margin="dense"
                        id="ticket_id"
                        name="ticket_id"
                        label="Ticket ID"
                        type="text"
                        fullWidth
                        variant="standard"
                    />
                    <DialogContentText>
                        Status (1:Open, 2:In Progress, 3:Closed)
                    </DialogContentText>
                    <TextField
                        autoFocus
                        required
                        margin="dense"
                        id="status"
                        name="status"
                        label="Status"
                        type="number"
                        fullWidth
                        variant="standard"
                        InputProps={{ inputProps: { min: 0, max: 2 } }}
                    />
                    <TextField
                        autoFocus
                        required
                        margin="dense"
                        id="assigned_to"
                        name="assigned_to"
                        label="Admin Username"
                        type="text"
                        fullWidth
                        variant="standard"
                    />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose}>Cancel</Button>
                    <Button type="submit">Submit</Button>
                </DialogActions>
            </Dialog>
        </React.Fragment>
    );
}

export default AdminTicketDialog;
