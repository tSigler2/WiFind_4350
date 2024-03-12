import React, { useState } from "react";
import './CreateAccount.css'; // Import the CSS file

function CreateAccount() {
    const [username, setUsername] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");

    const handleCreateAccount = () => {
        if (username === "" || email === "" || password === "") {
            setError("All fields must be filled out");
        } else {
            /* Uncomment the following code when you're ready to connect to your backend
            fetch('http://localhost:5000/api/accounts', { // Replace with your backend URL
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    username: username,
                    email: email,
                    password: password,
                }),
            })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                console.log('Success:', data);
                setError(""); // Clear the error message
                // Redirect or perform any other action upon successful account creation
            })
            .catch((error) => {
                console.error('Error:', error);
                setError("An error occurred. Please try again later."); // Display error message
            });
            */
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
            <p>Already have an account? <a href="/login">Login</a></p>
        </div>
    );
}

export default CreateAccount;
