/* eslint-disable no-unused-vars */
import React from 'react';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const Admin = () => {
    const notify = () => toast.success("Lazy to Customize This Before Tmrrw.",
        {
            position: "top-center",
            autoClose: 2000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: false,
            progress: undefined,
            theme: "light",
        });

    return (
        <div>Admin Page with Admin Options
            <button onClick={notify}>Test Toast</button>
            <ToastContainer/>
        </div>
    );
}

export default Admin;