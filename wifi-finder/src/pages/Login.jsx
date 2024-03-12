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
        <div style={{ background: "#f9f9f9", minHeight: "100vh", display: "flex", justifyContent: "center", alignItems: "center" }}>
            <div style={{ background: "#fff", borderRadius: "8px", boxShadow: "0 0 10px rgba(0, 0, 0, 0.1)", padding: "40px", maxWidth: "400px", width: "100%", boxSizing: "border-box" }}>
                <h2 style={{ textAlign: "center", marginBottom: "30px", color: "black" }}>Login</h2>
                <div style={{ display: "flex", flexDirection: "column", alignItems: "center" }}>
                    <input 
                        type="text" 
                        placeholder="Username" 
                        value={username} 
                        onChange={e => setUsername(e.target.value)} 
                        style={{ width: "100%", height: "40px", marginBottom: "20px", border: "1px solid lightgrey", borderRadius: "4px", padding: "10px", boxSizing: "border-box" }} 
                    />
                    <input 
                        type="password" 
                        placeholder="Password" 
                        value={password} 
                        onChange={e => setPassword(e.target.value)} 
                        style={{ width: "100%", height: "40px", marginBottom: "20px", border: "1px solid lightgrey", borderRadius: "4px", padding: "10px", boxSizing: "border-box" }}
                    />
                    <button style={{ width: "100%", height: "40px", background: "lightseagreen", color: "#fff", border: "none", borderRadius: "4px", cursor: "pointer" }} onClick={handleLogin}>Login</button>
                    {error && <p style={{ color: "red", marginTop: "10px" }}>{error}</p>}
                    <p style={{ textAlign: "center", marginTop: "20px", color: "#333" }}>Don't have an account? <Link to="/create-account" style={{ color: "lightseagreen", textDecoration: "none" }}>Register Here</Link></p>
                </div>
            </div>
        </div>
    );
}

export default Login;
