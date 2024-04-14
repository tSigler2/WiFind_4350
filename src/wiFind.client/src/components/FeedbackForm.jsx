import React, { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faComments } from '@fortawesome/free-solid-svg-icons';
import '../pages/Profile.css';

const NewFeedback = () => {
    const [subject, setSubject] = useState('[Max 30 characters]');
    const [description, setDescription] = useState('[Max 500 characters]');
    const [rating, setRating] = useState(10);

    const handleSubmit = async (e) => {
        e.preventDefault();

        const response = await fetch('https://localhost:7042/api/Feedback/submitfeedback', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem("token")
            },
            body: JSON.stringify({
                subject: subject,
                description: description,
                rating: rating,
            }),
        });

        if (response.ok) {
            alert('Feedback submitted');
        } else {
            alert('Error occured while submitting feedback');
        }
    };

    return (
        <div className="profile-container" >
            <div className="avatar">
                <FontAwesomeIcon icon={faComments} size="5x" />
            </div>
            <h2>Submit a Feedback</h2>
            <form onSubmit={handleSubmit} className="form">
                <div className="form-group">
                    <label htmlFor="subject">Subject:</label>
                    <input type="text" id="subject" value={subject} onChange={(e) => setSubject(e.target.value)} required />
                </div>
                <div className="form-group">
                    <label htmlFor="description">Description:</label>
                    <input type="text" id="description" value={description} onChange={(e) => setDescription(e.target.value)} required />
                </div>
                <div className="form-group">
                    <label htmlFor="rating">Rating:</label>
                    <input type="number" id="rating" min="1" max="10" value={rating} onChange={(e) => setRating(e.target.value)} required />
                </div>
                <button type="submit">Submit</button>
            </form>
        </div>
    );
};
export default NewFeedback;