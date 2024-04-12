/* eslint-disable no-unused-vars */
import React, { useState, useContext } from 'react';
import { CartContext } from './CartContext';
import { useNavigate } from "react-router-dom";

function PaymentForm() {
    const navigate = useNavigate();
    const [formData, setFormData] = useState({
        name: '',
        ccNumber: '',
        cvc: '',
        address: '',
        zipCode: '',
        expDate: '',
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData(prevState => ({
            ...prevState,
            [name]: value,
            checkoutCart: CartContext.Cart
        }));
    };
    const cart = useContext(CartContext);

    const handleSubmit = async (e) => { 
        e.preventDefault();
        try {
            // Send form data using Fetch API
            // 2 separate fetches will occur for purchase.
            // 1 fetch that validates card info. This will be replaced by third party like Stripe
            // 2. successful response from 1st api will lead to rent entry creation which hopefully will be a list of wifi_ids
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
            let wifi_ids = [];
            cart.cart.forEach((item) => {
                wifi_ids.push(item.wifi_id);
            });
            const res2 = await fetch('https://localhost:7042/api/Payment/saveRentedWifis', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + localStorage.getItem("token"),
                },
                body: JSON.stringify({ wifis_id_in_cart: wifi_ids })
            })
            if (!res2.ok) {
                throw new Error('Issue with update not payment');
            }
            else {
                alert('Payment Successful!');
                navigate("/rent");
            }
            //localStorage.setItem("submitPayment", formData);
        } catch (error) {
            console.error('Error submitting payment form:', error.message);
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
