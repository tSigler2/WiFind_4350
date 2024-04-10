import React, { useState } from 'react';

function PaymentForm() {
    const [formData, setFormData] = useState({
        username: '',
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
            [name]: value
        }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        // Send form data using Fetch API
        fetch('/api/payment', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        })
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to submit payment form');
            }
            return response.json();
        })
        .then(data => {
            console.log('Payment submitted successfully:', data);
            // Handle successful payment submission
        })
        .catch(error => {
            console.error('Error submitting payment form:', error.message);
            // Handle error
        });
    };

    return (
        <form onSubmit={handleSubmit}>
       
        </form>
    );
}

export default PaymentForm;
