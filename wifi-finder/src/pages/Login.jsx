import React, { useState } from "react";
import { Link } from "react-router-dom";

function Login() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");

    const handleLogin = () => {
        if (username === "" || password === "") {
            setError("Username and password cannot be empty");
        } else {
            // Here you would typically send the username and password to your backend
            console.log(`Logging in with username: ${username} and password: ${password}`);
            setError(""); // Clear the error message
        }
    };

    return (
        <div>
            <h2>Login</h2>
            <input 
                type="text" 
                placeholder="Username" 
                value={username} 
                onChange={e => setUsername(e.target.value)} 
            />
            <input 
                type="password" 
                placeholder="Password" 
                value={password} 
                onChange={e => setPassword(e.target.value)} 
            />
            <button onClick={handleLogin}>Login</button>
            {error && <p>{error}</p>}
            <p>Don't have an account? <Link to="/create-account">Create an account</Link></p>
        </div>
    );
}

export default Login;