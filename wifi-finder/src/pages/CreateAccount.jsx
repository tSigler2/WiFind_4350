import React, { useState } from "react";

function CreateAccount() {
    const [username, setUsername] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");

    const handleCreateAccount = () => {
        if (username === "" || email === "" || password === "") {
            setError("All fields must be filled out");
        } else {
            // Here you would typically send the username, email, and password to your backend
            console.log(`Creating account with username: ${username}, email: ${email}, and password: ${password}`);
            setError(""); // Clear the error message

            /* Uncomment the following code when you're ready to connect to your backend
            fetch('http://localhost:5000/api/accounts', { // Replace with your .NET backend URL
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
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
                setError(""); // Clear the error message
            })
            .catch((error) => {
                console.error('Error:', error);
            });
            */
        }
    };

    return (
        <div>
            <h2>Create Account</h2>
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
            <button onClick={handleCreateAccount}>Create Account</button>
            {error && <p>{error}</p>}
            <p>Already have an account? <a href="/login">Login</a></p>
        </div>
    );
}

export default CreateAccount;