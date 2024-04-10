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

    const handleSubmit = async (e) => { 
        e.preventDefault();

        try {
            // Send form data using Fetch API
            const response = await fetch('https://localhost:7042/api/Payment/purchase', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
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
           
        </form>
    );
}

export default PaymentForm;
