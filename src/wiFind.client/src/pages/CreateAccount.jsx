import React, { useState } from "react";
import { Link, Navigate, useNavigate } from "react-router-dom";
import './CreateAccount.css'; 


function CreateAccount() {
    
    const [username, setUsername] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [dob, setDob] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [error, setError] = useState("");
    const navigate = useNavigate();
    const handleCreateAccount = async () => {
        if (username === "" || email === "" || password === "" || firstName === "" || lastName === "" || dob === "" || phoneNumber === "") {
            setError("All fields must be filled out");
        } else {
            try {
                const response = await fetch('https://localhost:7042/api/User/register', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({
                        username,
                        email,
                        password,
                        first_name: firstName,
                        last_name: lastName,
                        dob,
                        phone_number: phoneNumber
                    })
                });

                if (!response.ok) {
                    throw new Error('Registration failed');
                }

                const data = await response.json();

                // Do something with the response data
                console.log(data);

                setError(""); // Clear the error message
                navigate("/login"); // Redirect to the login page
            } catch (error) {
                setError(error.message);
            }
        }
    };

    return (
        <div className="login-container">
            <h2 style={{ color: "black" }}>Create Account</h2>
            <form className="login-form">
                <input 
                    type="text" 
                    placeholder="Username" 
                    value={username} 
                    onChange={e => setUsername(e.target.value)} 
                />
                <input 
                    type="email" 
                    placeholder="Email" 
                    value={email} 
                    onChange={e => setEmail(e.target.value)} 
                />
                <input 
                    type="password" 
                    placeholder="Password" 
                    value={password} 
                    onChange={e => setPassword(e.target.value)} 
                />
                <button className="create-account-button" onClick={handleCreateAccount}>Sign Up</button>
                {error && <p className="error">{error}</p>}
            </form>
            <p style={{ color: "black" }}>Already have an account? 
                <Link to="/login" style={{ textDecoration: "none", color: "#A74D4A", marginLeft: "5px" }}>Login</Link>
            </p>
        </div>
    );
}

export default CreateAccount;
