import { connect } from "react-redux";
import React, { useEffect } from "react";
import Page from 'components/Page';
import {
    Card,
    CardBody,
    CardHeader,
    Col,
    Row,
} from 'reactstrap';
import { getAppointmentSchedule } from "../actions/appointments";
import moment from 'moment';

const AppointmentsPage = (props) => {

    useEffect(() => {

        let dateOfBirth = moment(new Date()).format("YYYY-MM-DD");
        if (props.child.person && props.child.person.dateOfBirth) {
            dateOfBirth = props.child.person.dateOfBirth
        }
        console.log(dateOfBirth)
        props.fetchAppointments(dateOfBirth);
    }, []);

    return (
        <Page
            className="DashboardPage"
            title="Schedule Appointments"
            breadcrumbs={[{ name: 'Appointments', active: true }]}
        >
            <Row>
                <Col lg="12" md="12" sm="12" xs="12">
                    <Card>
                        <CardHeader>
                            Appointments Schedule
                        </CardHeader>
                        <CardBody>

                        </CardBody>
                    </Card>
                </Col>
            </Row>
        </Page>
    );
}

const mapStateToProps = (state) => {
    return {
        appointments: state.appointments.schedule,
        child: state.children.child,
    };
};

const mapActionToProps = {
    fetchAppointments: getAppointmentSchedule,
};

export default connect(mapStateToProps, mapActionToProps)(AppointmentsPage);
