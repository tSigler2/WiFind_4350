/* eslint-disable no-unused-vars */
export const wifilistings = [
    {
        "wifi_id": "1c243a97-b08d-4edb-b6e0-2fcadfe26c71",
        "wifi_name": "Wifi_4",
        "security": "WPA3",
        "download_speed": 100,
        "upload_speed": 50,
        "wifi_latitude": 100,
        "wifi_longitude": -100,
        "radius": 10,
        "wifi_source": "Starlink",
        "curr_rate": 20.99,
        "time_listed": "2024-04-11T01:43:50.886777",
        "owned_by": "user3",
        "max_users": 5
    },
    {
        "wifi_id": "1d475c5a-f088-48fc-bb73-e83c5cbd364a",
        "wifi_name": "Wifi_1",
        "security": "Unsecure",
        "download_speed": 300,
        "upload_speed": 300,
        "wifi_latitude": 0,
        "wifi_longitude": 0,
        "radius": 10,
        "wifi_source": "Fiber",
        "curr_rate": 2.00,
        "time_listed": "2024-04-11T01:43:50.8867762",
        "owned_by": "user1",
        "max_users": 50
    },
    {
        "wifi_id": "34f3fb03-d917-48d2-8cd9-1e30c085cfb2",
        "wifi_name": "Wifi_2",
        "security": "More Secure",
        "download_speed": 300,
        "upload_speed": 200,
        "wifi_latitude": 0,
        "wifi_longitude": 0,
        "radius": 10,
        "wifi_source": "Fiber",
        "curr_rate": 5.00,
        "time_listed": "2024-04-11T01:43:50.8867765",
        "owned_by": "user1",
        "max_users": 10
    },
    {
        "wifi_id": "8f704d7a-7de0-4b03-8230-36cdcc6f21d0",
        "wifi_name": "Wifi_5",
        "security": "Unsecured",
        "download_speed": 400,
        "upload_speed": 300,
        "wifi_latitude": 10,
        "wifi_longitude": -5,
        "radius": 10,
        "wifi_source": "Starlink",
        "curr_rate": 10.00,
        "time_listed": "2024-04-11T01:43:50.8867774",
        "owned_by": "user10",
        "max_users": 100
    },
    {
        "wifi_id": "91720bff-b076-4b89-9a6e-36eebd68403f",
        "wifi_name": "ItsWifi",
        "security": "SurpriseMe",
        "download_speed": 500,
        "upload_speed": 500,
        "wifi_latitude": 0,
        "wifi_longitude": 0,
        "radius": 10,
        "wifi_source": "HotSpot",
        "curr_rate": 0.50,
        "time_listed": "2024-04-11T01:43:50.8867715",
        "owned_by": "user9",
        "max_users": 10
    },
    {
        "wifi_id": "eca15f8b-ddfe-4109-bc9f-2e053e728c14",
        "wifi_name": "Wifi_3",
        "security": "WPA2",
        "download_speed": 450,
        "upload_speed": 444,
        "wifi_latitude": 10,
        "wifi_longitude": 10,
        "radius": 10,
        "wifi_source": "ATT Fiber",
        "curr_rate": 1.00,
        "time_listed": "2024-04-11T01:43:50.8867767",
        "owned_by": "user3",
        "max_users": 50
    }
]

export const allfeedbacks = [
    {
        "subject": "Feedback 1",
        "description": "WiFind funds my fun in wifi.",
        "rating": 10,
        "date_stamp": "2024-04-11"
    },
    {
        "subject": "My Genuine Unpaid Review",
        "description": "Useful. Try it.",
        "rating": 10,
        "date_stamp": "2024-04-11"
   },
    {
        "subject": "Feedback 2",
        "description": "Review bombing because I work here and need a raise.",
        "rating": 2,
        "date_stamp": "2024-04-11"
  }
]

export const user1loginSuccess = {
    "username": "user1",
    "user_role": "User",
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjE1Y2VkN2RlLTZjZGUtNGQ4MC1hYmM3LWZiNWQ4NjE3OTkxMiIsIm5iZiI6MTcxMjg2ODA1MiwiZXhwIjoxNzEzMTI3MjUyLCJpYXQiOjE3MTI4NjgwNTJ9.EJ0k_NyH9Wbm8D0Y-8ZBb4IBR4gZH-k9yUJ5iF6-BTI"
}

// User 6 is one of the few that actually IS renting wifi from other users
export const user6loginSucess = {
    "username": "user6",
     "user_role": "User",
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6ImY1N2QwZTA3LTkxN2EtNDdlYS04NmZjLWVlZWU4MGFlNWYxMyIsIm5iZiI6MTcxMjg2ODU0NCwiZXhwIjoxNzEzMTI3NzQ0LCJpYXQiOjE3MTI4Njg1NDR9._ZW8Zsp3ZJX0tlrQk4WwVSiRIqWIRB6LeDNBn_18trc"
}

export const user6rentedWifis = [
    {
        "rentID": "8a3c082c-d24e-4c40-842b-1b395ba32484",
        "wifiID": "91720bff-b076-4b89-9a6e-36eebd68403f",
        "start": "2024-04-11T01:13:50.8867801",
        "end": "0001-01-01T00:00:00",
        "locked_rate": 1.00,
        "guest_password": "surprised?"
    },
    {
        "rentID": "a8d15a9c-55fd-418e-bb02-c8084fab15d4",
        "wifiID": "8f704d7a-7de0-4b03-8230-36cdcc6f21d0",
        "start": "2024-04-11T01:43:50.8867797",
        "end": "0001-01-01T00:00:00",
        "locked_rate": 0.50,
        "guest_password": "abc123"
    }
]

// Renter View Endpoint is still in progress BUT these are the expected JSON Responses I'm aiming for
export const user10rentersView = [
    {
        "wifiID": "8f704d7a-7de0-4b03-8230-36cdcc6f21d0",
        "num_users_renting": 2
    }
]

export const user3rentersView = [
    {
        "wifiID": "1c243a97-b08d-4edb-b6e0-2fcadfe26c71",
        "num_users_renting": 1
    },
    {
        "wifiID": "eca15f8b-ddfe-4109-bc9f-2e053e728c14",
        "num_users_renting": 0
    }
]

export const adminonlyActionAllTickets = [
    {
        "email": "user1@example.com",
        "time_stamp": "2024-04-01T01:43:50.886786",
        "subject": "Concerned that TikTok is stealing my Wifi",
        "description": "Please do something about it. ASAP. Or else I will never come here again!",
        "status": 0,
        "assigned_to": null
    },
    {
        "email": "",
        "time_stamp": "2024-04-11T04:15:36.2411416",
        "subject": "testingtesting",
        "description": "does this work again?",
        "status": 0,
        "assigned_to": null
    },
    {
        "email": "",
        "time_stamp": "2024-04-11T04:14:49.1722406",
        "subject": "testingtesting",
        "description": "does this work?",
        "status": 0,
        "assigned_to": null
    },
    {
        "email": "user6@example.com",
        "time_stamp": "2024-04-09T01:43:50.8867864",
        "subject": "Contact with wifi renter",
        "description": "How do I contact the user renting out the StarLink wifi?",
        "status": 1,
        "assigned_to": "06ed4db9-5799-4f39-85ba-3ac9c7f28729"
    },
    {
        "email": "user3@example.com",
        "time_stamp": "2024-04-11T01:43:50.8867867",
        "subject": "need to see my profit",
        "description": "i need step by step with powerpoint slides on how to get to my revenue.",
        "status": 1,
        "assigned_to": "ea2cef69-f132-402a-a162-e7d774388a64"
    },
    {
        "email": "",
        "time_stamp": "2024-04-11T04:13:45.9651382",
        "subject": "testingtesting",
        "description": "does this work?",
        "status": 0,
        "assigned_to": null
    }
]