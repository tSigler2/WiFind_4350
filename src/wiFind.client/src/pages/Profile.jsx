import React, { useState, useEffect } from 'react';

const Profile = () => {
  const [userId, setUserId] = useState('');
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');

  useEffect(() => {
    const user = JSON.parse(localStorage.getItem('user'));
    if (user) {
      setUserId(user.user_id);
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
      },
      body: JSON.stringify({
        user_id:  "15ced7de-6cde-4d80-abc7-fb5d86179912",
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
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        First Name:
        <input type="text" value={firstName} onChange={(e) => setFirstName(e.target.value)} required />
      </label>
      <label>
        Last Name:
        <input type="text" value={lastName} onChange={(e) => setLastName(e.target.value)} required />
      </label>
      <label>
        Phone Number:
        <input type="text" value={phoneNumber} onChange={(e) => setPhoneNumber(e.target.value)} required />
      </label>
      <button type="submit">Update Profile</button>
    </form>
  );
};

export default Profile;