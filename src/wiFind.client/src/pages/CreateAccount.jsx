import React, { useState } from "react";
import { Link } from "react-router-dom";
import './CreateAccount.css'; 
import { useNavigate } from "react-router-dom";

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

    const handleCreateAccount = async (e) => {
        e.preventDefault();
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

                localStorage.setItem("token", data.token);

                // Do something with the response data
                console.log(data);

                setError(""); // Clear the error message
                navigate("/"); // Redirect to the home page
            } catch (error) {
                setError(error.message);
            }
        }
    };

    return (
        <div className="login-container">
            <h2 style={{ color: "black" }}>Create Account</h2>
            <form className="login-form" onSubmit={e => handleCreateAccount(e)}>
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
                <input 
                    type="text" 
                    placeholder="First Name" 
                    value={firstName} 
                    onChange={e => setFirstName(e.target.value)} 
                />
                <input 
                    type="text" 
                    placeholder="Last Name" 
                    value={lastName} 
                    onChange={e => setLastName(e.target.value)} 
                />
                <input 
                    type="date" 
                    placeholder="Date of Birth" 
                    value={dob} 
                    onChange={e => setDob(e.target.value)} 
                />
                <input 
                    type="text" 
                    placeholder="Phone Number" 
                    value={phoneNumber} 
                    onChange={e => setPhoneNumber(e.target.value)} 
                />
                <button className="create-account-button">Sign Up</button>
                {error && <p className="error">{error}</p>}
            </form>
            <p style={{ color: "black" }}>Already have an account? 
                <Link to="/login" style={{ textDecoration: "none", color: "#A74D4A", marginLeft: "5px" }}>Login</Link>
            </p>
        </div>
    );
}

export default CreateAccount;