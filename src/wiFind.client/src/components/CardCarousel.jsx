/* eslint-disable no-unused-vars */
import React from 'react';
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
    var items = Placeholders.allfeedbacks;

    return (
        <Carousel style={{ position: 'fixed', right: '5px', bottom: '20px'} }>
            {
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