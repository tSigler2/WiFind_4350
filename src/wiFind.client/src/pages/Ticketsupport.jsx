import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import Footer from "../components/Footer";
import TicketHeroSection from "../components/TicketHeroSection";
import "./TicketSupport.css";

function TicketSupport() {
  const [inputEmail, setEmail] = useState("");
  const [inputSubject, setSubject] = useState("");
  const [inputDescription, setDescription] = useState("");
  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!inputEmail || !inputSubject || !inputDescription) {
      setError("Please fill out all fields");
      return;
    }
      try {
          //const response = await fetch('https://localhost:7042/api/SupportTicket/submitticket', {
          //    method: 'POST',
          //    headers: {
          //        'Content-Type': 'application/json',
          //    },
          //    body: JSON.stringify({
          //        email: inputEmail,
          //        subject: inputSubject,
          //        description: inputDescription,
          //    }),
          //});
          //if (response.ok) {
          //    alert('Ticket was successfully submitted');
          //} else { alert('Error occured during ticket submission'); }
          let data = JSON.stringify({
              email: inputEmail,
              subject: inputSubject,
              description: inputDescription,
          });
          localStorage.setItem("submittedFb", data);
          alert("Submitted. check local storage with key submittedFb");
    } catch (error) {
      setError("Failed to submit ticket. Please try again later.");
    }
  };

  return (
    <div>
      <TicketHeroSection /> 
      <div className="ticket-support-container">
        <h1 className="ticket-support-title">Contact Support</h1>
        <form onSubmit={handleSubmit} className="ticket-support-form">
          <div className="form-group">
            <label htmlFor="username">Email:</label>
            <input
              type="text"
              id="email"
              value={inputEmail}
              onChange={(e) => setEmail(e.target.value)}
              placeholder="Enter your email" // Placeholder for email
            />
          </div>
          <div className="form-group">
            <label htmlFor="subject">Subject:</label>
            <input
              type="text"
              id="subject"
              value={inputSubject}
              onChange={(e) => setSubject(e.target.value)}
              placeholder="Enter the subject of your ticket" // Placeholder for subject
            />
          </div>
          <div className="form-group">
            <label htmlFor="description">Description:</label>
            <textarea
              id="description"
              value={inputDescription}
              onChange={(e) => setDescription(e.target.value)}
              placeholder="Enter the description of your issue" // Placeholder for description
            />
          </div>
          {error && <p className="error-message">{error}</p>}
          <button type="submit" className="submit-button">
            Submit
          </button>
        </form>
        <Footer />
      </div>
    </div>
  );
}

export default TicketSupport;
