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
            // Here you send the username and password to backend
            console.log(`Logging in with username: ${username} and password: ${password}`);
            setError(""); // Clear the error message
        }
    };

    return (
        <div style={{ background: "#f9f9f9", minHeight: "100vh", display: "flex", justifyContent: "center", alignItems: "center", paddingTop: "1px" }}>
            <div style={{ background: "#fff", borderRadius: "8px", boxShadow: "0 0 10px rgba(0, 0, 0, 0.1)", padding: "30px", maxWidth: "350px", width: "100%", boxSizing: "border-box" }}>
                <h2 style={{ textAlign: "center", marginBottom: "20px", color: "black", fontSize: "20px" }}>Login</h2>
                <div style={{ display: "flex", flexDirection: "column", alignItems: "center" }}>
                    <input 
                        type="text" 
                        placeholder="Username" 
                        value={username} 
                        onChange={e => setUsername(e.target.value)} 
                        style={{ width: "100%", height: "40px", marginBottom: "20px", border: "1px solid lightgrey", borderRadius: "4px", padding: "10px", boxSizing: "border-box", fontSize: "16px" }} 
                    />
                    <input 
                        type="password" 
                        placeholder="Password" 
                        value={password} 
                        onChange={e => setPassword(e.target.value)} 
                        style={{ width: "100%", height: "40px", marginBottom: "20px", border: "1px solid lightgrey", borderRadius: "4px", padding: "10px", boxSizing: "border-box", fontSize: "16px" }}
                    />
                    <button style={{ width: "100%", height: "40px", background: "#A74D4A", color: "#fff", border: "none", borderRadius: "4px", cursor: "pointer", fontSize: "16px" }} onClick={handleLogin}>Login</button>
                    {error && <p style={{ color: "red", marginTop: "10px", fontSize: "14px" }}>{error}</p>}
                    <p style={{ textAlign: "center", marginTop: "15px", color: "#333", fontSize: "14px" }}>Don't have an account? <Link to="/create-account" style={{ color: "#A74D4A", textDecoration: "none" }}>Register Here</Link></p>
                </div>
            </div>
        </div>
    );
}

export default Login;
