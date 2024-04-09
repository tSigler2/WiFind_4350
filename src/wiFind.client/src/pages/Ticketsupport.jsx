import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import Footer from "../components/Footer";

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
            // Assuming 'submitTicket' is a function to submit ticket to the API
            await submitTicket({ username, subject, description });
            setError(""); // Clear any previous errors
            // Optionally, you can redirect the user to a confirmation page or back to the homepage
            // navigate("/confirmation");
        } catch (error) {
            setError("Failed to submit ticket. Please try again later.");
        }
    };

    return (
        <div>
            <h1>Contact</h1>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Username:</label>
                    <input type="text" value={username} onChange={(e) => setUsername(e.target.value)} />
                </div>
                <div>
                    <label>Subject:</label>
                    <input type="text" value={subject} onChange={(e) => setSubject(e.target.value)} />
                </div>
                <div>
                    <label>Description:</label>
                    <textarea value={description} onChange={(e) => setDescription(e.target.value)} />
                </div>
                {error && <p style={{ color: "red" }}>{error}</p>}
                <button type="submit">Submit</button>
            </form>
            <Footer />
        </div>
    );
}

export default TicketSupport;
