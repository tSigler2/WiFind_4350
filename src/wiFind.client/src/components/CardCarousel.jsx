/* eslint-disable no-unused-vars */
import React, { useEffect, useState } from 'react';
import Carousel from 'react-material-ui-carousel';
import { Paper, Button } from '@mui/material';
import * as Placeholders from '../placeholders/placeholders.jsx';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faStar } from '@fortawesome/free-solid-svg-icons';

function CardCarousel(props) {
    var items = [{
        "subject": "Retrieving data...",
        "description": "",
        "rating": 10,
        "date_stamp": ""
    }];
    const [feedbacks, setFeedback] = useState();
    useEffect(() => {
        populateFeedbacks();
    }, []);

    async function populateFeedbacks() {
        const response = await fetch('https://localhost:7042/api/Feedback/allfeedbacks');
        if (!response.ok) {
            throw new Error('Could not retrieve feedbacks at this time');
        }

        const data = await response.json();
        setFeedback(data);
    }

    return (
        <Carousel style={{ position: 'fixed', right: '5px', bottom: '20px'} }>
            {
                feedbacks != null?
                    feedbacks.map((item, i) => <Item key={i} item={item} />) :
                    items.map((item, i) => <Item key={i} item={item} />)
            }
        </Carousel>
    )
}

function Item(props) {
    return (
        <Card sx={{ minWidth: 275 }}>
            <CardContent>
                <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
                    User Reviews
                </Typography>
                <Typography variant="p" component="div">
                    {props.item.rating} /10 <FontAwesomeIcon icon={faStar} />
                </Typography>
                <Typography color="text.secondary">
                    {props.item.subject}
                </Typography>
                <Typography variant="body2">
                    {props.item.description}
                    <br />
                    {props.item.date_stamp}
                </Typography>
            </CardContent>
        </Card>
    );
}
export default CardCarousel;