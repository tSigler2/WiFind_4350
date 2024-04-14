import React, { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faMoneyCheckDollar } from '@fortawesome/free-solid-svg-icons';
import '../pages/Profile.css';

const NewPaymentInfo = () => {
    const [payment_type, setPaymentType] = useState('Card Type');
    const [name_on_card, setNameOnCard] = useState('First Last');
    const [card_number, setCardNumber] = useState('XXXX-XXXX-XXXX-XXXX');
    const [exp_date, setExpDate] = useState('MM/YYYY');

    const handleSubmit = async (e) => {
        e.preventDefault();

        const response = await fetch('https://localhost:7042/api/User/addpaymentinfo', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem("token")
            },
            body: JSON.stringify({
                payment_type: payment_type,
                name_on_card: name_on_card,
                card_number: card_number,
                exp_date: exp_date,
            }),
        });

        if (response.ok) {
            alert('Payment Information saved.');
        } else {
            alert('Error occured while saving payment information');
        }
    };

    return (
        <div className="profile-container" >
            <div className="avatar">
                <FontAwesomeIcon icon={faMoneyCheckDollar} size="5x" />
            </div>
            <h2>Save a Payment Method</h2>
            <form onSubmit={handleSubmit} className="form">
                <div className="form-group">
                    <label htmlFor="payment_type">Payment Type:</label>
                    <input type="text" id="payment_type" value={payment_type} onChange={(e) => setPaymentType(e.target.value)} required />
                </div>
                <div className="form-group">
                    <label htmlFor="card_number">Card Number:</label>
                    <input type="text" id="card_number" value={card_number} onChange={(e) => setCardNumber(e.target.value)} required />
                </div>
                <div className="form-group">
                    <label htmlFor="name_on_card">Name on Card:</label>
                    <input type="text" id="name_on_card" value={name_on_card} onChange={(e) => setNameOnCard(e.target.value)} required />
                </div>
                <div className="form-group">
                    <label htmlFor="exp_date">Expiry Date:</label>
                    <input type="text" id="exp_date" value={exp_date} onChange={(e) => setExpDate(e.target.value)} required />
                </div>
                <button type="submit">Submit</button>
            </form>
        </div>
    );
};
export default NewPaymentInfo;