/* eslint-disable no-unused-vars */
import React from 'react';
import Profile from './Profile.jsx';
import NewFeedback from '../components/FeedbackForm.jsx';
import NewPaymentInfo from '../components/PaymentInfoForm.jsx';
import PaymentInfoSaved from '../components/PaymentInfoSaved.jsx'
const ProfilePage = () => {

    return (
        <div style={{ display: 'block' }}>
            <div style={{ display: 'flex' }}>
                <Profile></Profile>
                <NewFeedback ></NewFeedback>
                <NewPaymentInfo></NewPaymentInfo>
            </div>
            <div style={{ display: 'flex' }}>
                <PaymentInfoSaved></PaymentInfoSaved>
            </div>
        </div>

    );
}

export default ProfilePage;