import React, { Component } from 'react'
import { Box, Grid } from '@mui/material'
import AddAttendeeForm from './Forms/AddAttendeeForm'
import GetAttendees from './GetAttendees'

class Attendees extends Component {

    render() {
        return (
            <Box sx={{flexgrow: 1}}>
                <Grid container spacing={6}>
                    <Grid item xs={12} md={6}>
                        <AddAttendeeForm />
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <GetAttendees />
                    </Grid>
                </Grid>
            </Box>   
        )
    }
}

export default Attendees