import React, { useState } from 'react';
import { CartContext } from './CartContext';

function PaymentForm() {
    const [formData, setFormData] = useState({
        username: localStorage.getItem("username"), // use local storage item "username"
        name: '',
        ccNumber: '',
        cvc: '',
        address: '',
        zipCode: '',
        expDate: ''
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData(prevState => ({
            ...prevState,
            [name]: value,
            Cart: CartContext.Cart
        }));
    };

    const handleSubmit = async (e) => { 
        e.preventDefault();

        try {
            // Send form data using Fetch API
            const response = await fetch('https://localhost:7042/api/Payment/purchase', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + localStorage.getItem("token"),
                },
                body: JSON.stringify(formData)
            });

            if (!response.ok) {
                throw new Error('Failed to submit payment form');
            }

            const data = await response.json();
            console.log('Payment submitted successfully:', data);
            // Handle successful payment submission
        } catch (error) {
            console.error('Error submitting payment form:', error.message);
            // Handle error
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            {/*<label>*/}
            {/*    Username:*/}
            {/*    <input*/}
            {/*        type="text"*/}
            {/*        name="username"*/}
            {/*        value={formData.username}*/}
            {/*        onChange={handleChange}*/}
            {/*    />*/}
            {/*</label>*/}
            <label>
                Name on Card:
                <input
                    type="text"
                    name="name"
                    value={formData.name}
                    onChange={handleChange}
                />
            </label>
            <label>
                Credit Card Number:
                <input
                    type="text"
                    name="ccNumber"
                    value={formData.ccNumber}
                    onChange={handleChange}
                />
            </label>
            <label>
                CVC:
                <input
                    type="text"
                    name="cvc"
                    value={formData.cvc}
                    onChange={handleChange}
                />
            </label>
            <label>
                Address:
                <input
                    type="text"
                    name="address"
                    value={formData.address}
                    onChange={handleChange}
                />
            </label>
            <label>
                Zip Code:
                <input
                    type="text"
                    name="zipCode"
                    value={formData.zipCode}
                    onChange={handleChange}
                />
            </label>
            <label>
                Expiry Date:
                <input
                    type="text"
                    name="expDate"
                    value={formData.expDate}
                    onChange={handleChange}
                />
            </label>
            <button type="submit">Submit Payment</button>
        </form>
    );
}

export default PaymentForm;
