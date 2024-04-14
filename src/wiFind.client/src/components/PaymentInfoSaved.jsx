/* eslint-disable no-unused-vars */
import React, { useEffect, useState } from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

function PaymentInfoSaved() {
    const [savedPaymentMethods, setSavedPaymentMethods] = useState([]);

    useEffect(() => {
        populateSavedPaymentMethods();
    }, []);

    async function populateSavedPaymentMethods() {
        const response = await fetch('https://localhost:7042/api/User/savedpaymentinfos', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem("token"),
            },
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();
        setSavedPaymentMethods(data);
    }

    return (
        savedPaymentMethods != null?
            <div className="profile-container" style={{ maxWidth: '900px' }}>
            <h2>My Saved Payment Methods</h2>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }} aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            <TableCell>Card Number</TableCell>
                            <TableCell align="right">Payment Type</TableCell>
                            <TableCell align="right">Name_on_card</TableCell>
                            <TableCell align="right">Expiry Date</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {savedPaymentMethods.map((paymentmethod) => (
                            <TableRow
                                key={paymentmethod.card_number}
                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            >
                                <TableCell component="th" scope="row">
                                    {paymentmethod.card_number}
                                </TableCell>
                                <TableCell align="right">{paymentmethod.payment_type}</TableCell>
                                <TableCell align="right">{paymentmethod.name_on_card}</TableCell>
                                <TableCell align="right">{paymentmethod.exp_date}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
            </div> : 
            <div className="profile-container">
                <TableContainer component={Paper}>
                    <Table sx={{ minWidth: 650 }} aria-label="simple table">
                        <TableHead>
                            <TableRow>
                                <TableCell>Card Number</TableCell>
                                <TableCell align="right">Payment Type</TableCell>
                                <TableCell align="right">Name_on_card</TableCell>
                                <TableCell align="right">Expiry Date</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            <TableRow
                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            >
                                <TableCell component="th" scope="row">
                                    XXXX-XXXX-XXXX
                                </TableCell>
                                <TableCell align="right">N/A</TableCell>
                                <TableCell align="right">N/A</TableCell>
                                <TableCell align="right">XX/XXXX</TableCell>
                            </TableRow>
                        </TableBody>
                    </Table>
                </TableContainer>
            </div>
    );
}

export default PaymentInfoSaved;
