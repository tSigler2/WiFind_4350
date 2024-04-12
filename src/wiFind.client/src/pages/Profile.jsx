import React, { useState, useEffect } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import './Profile.css';

const Profile = () => {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');

  useEffect(() => {
    const user = JSON.parse(localStorage.getItem('user'));
    if (user) {
      setFirstName(user.first_name);
      setLastName(user.last_name);
      setPhoneNumber(user.phone_number);
    }
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const response = await fetch('https://localhost:7042/api/User/updateprofile', {
      method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + localStorage.getItem("token")
      },
      body: JSON.stringify({
        username:  localStorage.getItem('username'),
        first_name: firstName,
        last_name: lastName,
        phone_number: phoneNumber,
      }),
    });

    if (response.ok) {
      alert('Profile updated successfully');
    } else {
      alert('Error updating profile');
      }
      //var data = JSON.stringify({
      //    username: localStorage.getItem('username'),
      //    first_name: firstName,
      //    last_name: lastName,
      //    phone_number: phoneNumber,
      //});
      //localStorage.setItem("updateUserItem", data);
      //alert("Check application local storage if this item was saved as updateUserItem");
  };

  return (
    <div className="profile-container">
      <div className="avatar">
        <FontAwesomeIcon icon={faUser} size="5x" />
      </div>
      <h2>Update Profile</h2>
      <form onSubmit={handleSubmit} className="form">
        <div className="form-group">
          <label htmlFor="firstName">First Name:</label>
          <input type="text" id="firstName" value={firstName} onChange={(e) => setFirstName(e.target.value)} required />
        </div>
        <div className="form-group">
          <label htmlFor="lastName">Last Name:</label>
          <input type="text" id="lastName" value={lastName} onChange={(e) => setLastName(e.target.value)} required />
        </div>
        <div className="form-group">
          <label htmlFor="phoneNumber">Phone Number:</label>
          <input type="text" id="phoneNumber" value={phoneNumber} onChange={(e) => setPhoneNumber(e.target.value)} required />
        </div>
        <button type="submit">Update Profile</button>
      </form>
    </div>
  );
};
export default Profile;

