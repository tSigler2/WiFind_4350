import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import Footer from "../components/Footer";
import "./TicketSupport.css"; 

function TicketSupport() {
    const [username, setUsername] = useState("");
    const [subject, setSubject] = useState("");
    const [description, setDescription] = useState("");
    const [error, setError] = useState("");
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        
        if (!username || !subject || !description) {
            setError("Please fill out all fields");
            return;
        }
        try {
            await submitTicket({ username, subject, description });
            setError(""); 
        } catch (error) {
            setError("Failed to submit ticket. Please try again later.");
        }
    };

    return (
        <div className="ticket-support-container">
            <h1 className="ticket-support-title">Contact Support</h1>
            <form onSubmit={handleSubmit} className="ticket-support-form">
                <div className="form-group">
                    <label htmlFor="username">Username:</label>
                    <input type="text" id="username" value={username} onChange={(e) => setUsername(e.target.value)} />
                </div>
                <div className="form-group">
                    <label htmlFor="subject">Subject:</label>
                    <input type="text" id="subject" value={subject} onChange={(e) => setSubject(e.target.value)} />
                </div>
                <div className="form-group">
                    <label htmlFor="description">Description:</label>
                    <textarea id="description" value={description} onChange={(e) => setDescription(e.target.value)} />
                </div>
                {error && <p className="error-message">{error}</p>}
                <button type="submit" className="submit-button">Submit</button>
            </form>
            <Footer />
        </div>
    );
}

export default TicketSupport;
