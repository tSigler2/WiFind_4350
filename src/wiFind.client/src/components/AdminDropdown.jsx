import * as React from 'react';
import Box from '@mui/material/Box';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';

export default function BasicSelect() {
    const [age, setAge] = React.useState('');

    const handleChange = (event) => {
        setAge(event.target.value);
    };

    return (
        <Box sx={{ minWidth: 120 }}>
            <FormControl fullWidth>
                <InputLabel id="demo-simple-select-label">Restatus</InputLabel>
                <Select
                    labelId="demo-simple-select-label"
                    id="admin-chooser"
                    value={age}
                    label="Age"
                    onChange={handleChange}
                >
                    <MenuItem value={0}>Open</MenuItem>
                    <MenuItem value={1}>In Progress</MenuItem>
                    <MenuItem value={2}>Closed</MenuItem>
                </Select>
            </FormControl>
        </Box>
    );
}